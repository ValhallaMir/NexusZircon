using DevExpress.XtraSpreadsheet.Commands;
using Library;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Launcher
{
    public partial class LMain : DevExpress.XtraEditors.XtraForm
    {
        public const string PListFileName = "PList.Bin";
        public const string ClientPath = ".\\";
        public const string ClientFileName = "Zircon.exe";

        public DateTime LastSpeedCheck;
        public long TotalDownload, TotalProgress, CurrentProgress, LastDownloadProcess;
        public long ActiveDownloadTotal;
        public bool NeedUpdate;

        public static bool HasError;
        private HttpClient _httpClient;
        private System.Windows.Forms.Timer _uiTimer;

        public bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private ConfigForm ConfigForm = new ConfigForm();

        public LMain()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls12;

            ServicePointManager.DefaultConnectionLimit = Math.Max(8, Config.Concurrent * 4);

            InitializeComponent();

            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(30);

            if (Config.UseLogin)
            {
                var byteArray = Encoding.ASCII.GetBytes($"{Config.Username}:{Config.Password}");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }

            _uiTimer = new System.Windows.Forms.Timer();
            _uiTimer.Interval = 10;
            _uiTimer.Tick += (s, e) => CreateSizeLabel();
        }
        private void LMain_Load(object sender, EventArgs e)
        {
            var envir = CoreWebView2Environment.CreateAsync(null, Config.ResourcePath).Result;
            Main_browser.EnsureCoreWebView2Async(envir);

            Main_browser.NavigationCompleted += Main_browser_NavigationCompleted;
            Main_browser.Source = new Uri("https://nexusmir.com/");
            Main_browser.ExecuteScriptAsync("window.scrollTo(0,20)");

            ProgressCurrent_pb.Width = 5;
            TotalProg_pb.Width = 5;
            CurrentPercent_label.Text = "0%";
            TotalPercent_label.Text = "0%";

            CheckPatch(false);

            ToggleMode();
        }
        private void Main_browser_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (Main_browser.Source.AbsolutePath != "blank") Main_browser.Visible = true;

            if (e.IsSuccess)
            {
                Main_browser.ExecuteScriptAsync("document.querySelector('body').style.overflow='scroll';var style=document.createElement('style');style.type='text/css';style.innerHTML='::-webkit-scrollbar{display:none}';document.getElementsByTagName('body')[0].appendChild(style)");
                Main_browser.ExecuteScriptAsync("window.scrollTo(0,20)");

            }
        }

        public void ToggleMode()
        {
            if (Config.DebugMode)
            {
                Main_browser.SendToBack();
                OutputTextBox.BringToFront();
            }
            else
            {
                OutputTextBox.SendToBack();
                Main_browser.BringToFront();
                Main_browser.Focus();
            }
        }

        public async void CheckPatch(bool repair)
        {
            HasError = false;
            Launch_pb.Enabled = false;
            Launch_pb.Image = Properties.Resources.Start_Greyscale;
            TotalDownload = 0;
            TotalProgress = 0;
            CurrentProgress = 0;
            ActiveDownloadTotal = 0;
            LastDownloadProcess = 0;
            ProgressCurrent_pb.Width = 0;
            TotalProg_pb.Width = 0;
            CurrentPercent_label.Text = "0%";
            TotalPercent_label.Text = "0%";
            LastSpeedCheck = Time.Now;
            NeedUpdate = false;
            OutputTextBox.Text = string.Empty;

            _uiTimer.Start();

            Progress<string> progress = new Progress<string>(s => StatusLabel.Text = s);

            List<PatchInformation> liveVersion = await GetPatchInformation(progress);

            if (liveVersion == null)
            {
                DownloadSizeLabel.Text = "Downloading failed.";
                OutputTextBox.AppendText($"Downloading failed.\r\n");

                ProgressCurrent_pb.Width = 5;
                TotalProg_pb.Width = 5;
                CurrentPercent_label.Text = "Failed";
                TotalPercent_label.Text = "Failed";

                Launch_pb.Enabled = true;
                _uiTimer.Stop();
                return;
            }

            List<PatchInformation> currentVersion = repair ? null : await LoadVersion(progress);
            List<PatchInformation> patch = await CalculatePatch(liveVersion, currentVersion, progress);

            StatusLabel.Text = "Downloading";
            OutputTextBox.AppendText($"Total files to download: {patch.Count}\r\n");
            CreateSizeLabel();

            await DownloadPatch(patch, progress);

            CreateSizeLabel();

            if (HasError)
            {
                _uiTimer.Stop();
                StatusLabel.Text = "Patch failed";
                OutputTextBox.AppendText($"Patch failed.\r\n");
                ProgressCurrent_pb.Width = 5;
                TotalProg_pb.Width = 5;
                CurrentPercent_label.Text = "Failed";
                TotalPercent_label.Text = "Failed";
                Launch_pb.Enabled = true;
                Launch_pb.Image = Properties.Resources.Start_Normal;
                return;
            }

            SaveVersion(liveVersion);

            StatusLabel.Text = "Complete";
            DownloadSizeLabel.Text = "Complete.";
            DownloadSpeedLabel.Text = "Complete.";
            OutputTextBox.AppendText($"Patch complete. Total files downloaded: {patch.Count}\r\n");

            ProgressCurrent_pb.Width = 250;
            TotalProg_pb.Width = 252;
            CurrentPercent_label.Text = "100%";
            TotalPercent_label.Text = "100%";

            if (Directory.Exists(ClientPath + "Patch\\"))
                Directory.Delete(ClientPath + "Patch\\", true);

            if (NeedUpdate)
            {
                File.WriteAllBytes(Program.PatcherFileName, Properties.Resources.Patcher);
                Process.Start(Program.PatcherFileName, $"\"{Application.ExecutablePath}.tmp\" \"{Application.ExecutablePath}\"");
                Environment.Exit(0);
            }

            try
            {
                if (File.Exists(Program.PatcherFileName))
                    File.Delete(Program.PatcherFileName);
            }
            catch (Exception) { }

            _uiTimer.Stop();
            Launch_pb.Enabled = true;
            Launch_pb.Image = Properties.Resources.Start_Normal;
        }
        private void CreateSizeLabel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CreateSizeLabel));
                return;
            }

            const decimal KB = 1024m;
            const decimal MB = KB * 1024m;
            const decimal GB = MB * 1024m;

            long totalProgress = Interlocked.Read(ref TotalProgress);
            long currentProgress = Interlocked.Read(ref CurrentProgress);
            long totalDownload = Interlocked.Read(ref TotalDownload);
            long activeDownloadTotal = Interlocked.Read(ref ActiveDownloadTotal);

            long overallProgress = totalProgress + currentProgress;

            // Size label
            StringBuilder text = new StringBuilder();

            if (overallProgress >= GB)
                text.Append($"{overallProgress / GB:#,##0.0}GB");
            else if (overallProgress >= MB)
                text.Append($"{overallProgress / MB:#,##0.0}MB");
            else if (overallProgress >= KB)
                text.Append($"{overallProgress / KB:#,##0}KB");
            else
                text.Append($"{overallProgress:#,##0}B");

            if (totalDownload >= GB)
                text.Append($" / {totalDownload / GB:#,##0.0}GB");
            else if (totalDownload >= MB)
                text.Append($" / {totalDownload / MB:#,##0.0}MB");
            else if (totalDownload >= KB)
                text.Append($" / {totalDownload / KB:#,##0}KB");
            else
                text.Append($" / {totalDownload:#,##0}B");

            DownloadSizeLabel.Text = text.ToString();

            // TOTAL %
            int totalPercent = 0;
            if (totalDownload > 0)
                totalPercent = (int)((overallProgress * 100L) / totalDownload);

            totalPercent = Math.Max(0, Math.Min(100, totalPercent));

            TotalPercent_label.Text = $"{totalPercent}%";

            // IMPORTANT: use actual max width of your bar container
            int totalBarMaxWidth = 252;
            TotalProg_pb.Width = (totalBarMaxWidth * totalPercent) / 100;

            // CURRENT %
            int currentPercent = 0;

            if (Config.Concurrent > 1)
            {
                currentPercent = activeDownloadTotal > 0 ? 100 : 0;
            }
            else if (activeDownloadTotal > 0)
            {
                currentPercent = (int)((currentProgress * 100L) / activeDownloadTotal);
                currentPercent = Math.Max(0, Math.Min(100, currentPercent));
            }

            CurrentPercent_label.Text = $"{currentPercent}%";

            int currentBarMaxWidth = 250;
            ProgressCurrent_pb.Width = (currentBarMaxWidth * currentPercent) / 100;

            // Speed
            long nowTicks = Time.Now.Ticks;
            long lastTicks = LastSpeedCheck.Ticks;
            long tickDiff = nowTicks - lastTicks;

            if (tickDiff > 0)
            {
                long speed = (overallProgress - LastDownloadProcess) * TimeSpan.TicksPerSecond / tickDiff;
                LastDownloadProcess = overallProgress;

                if (speed >= GB)
                    DownloadSpeedLabel.Text = $"{speed / GB:#,##0.0}GBps";
                else if (speed >= MB)
                    DownloadSpeedLabel.Text = $"{speed / MB:#,##0.0}MBps";
                else if (speed >= KB)
                    DownloadSpeedLabel.Text = $"{speed / KB:#,##0}KBps";
                else
                    DownloadSpeedLabel.Text = $"{speed:#,##0}Bps";
            }

            LastSpeedCheck = Time.Now;
        }

        private async Task<List<PatchInformation>> LoadVersion(IProgress<string> progress)
        {
            List<PatchInformation> list = new List<PatchInformation>();

            try
            {
                if (File.Exists(ClientPath + "Version.bin"))
                {
                    using (MemoryStream mStream = new MemoryStream(await File.ReadAllBytesAsync(ClientPath + "Version.bin")))
                    using (BinaryReader reader = new BinaryReader(mStream))
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                            list.Add(new PatchInformation(reader));

                    progress.Report("Calculating Patch.");
                    OutputTextBox.AppendText($"Calculating Patch.\r\n");
                    return list;
                }

                progress.Report("Version Info is missing, Running Repairing");
            }
            catch (Exception ex)
            {
                progress.Report(ex.ToString());
            }

            return null;
        }
        private async Task<List<PatchInformation>> GetPatchInformation(IProgress<string> progress)
        {
            try
            {
                progress.Report("Downloading Patch Information");
                OutputTextBox.AppendText($"Downloading Patch Information.\r\n");

                using (HttpResponseMessage response = await _httpClient.GetAsync(
                    Config.Host + PListFileName + "?nocache=" + Guid.NewGuid().ToString("N")))
                {
                    response.EnsureSuccessStatusCode();

                    byte[] data = await response.Content.ReadAsByteArrayAsync();

                    using (MemoryStream contentStream = new MemoryStream(data))
                    using (BinaryReader reader = new BinaryReader(contentStream))
                    {
                        List<PatchInformation> list = new List<PatchInformation>();

                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                            list.Add(new PatchInformation(reader));

                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                progress.Report(ex.ToString());
            }

            return null;
        }
        private async Task<List<PatchInformation>> CalculatePatch(IReadOnlyList<PatchInformation> list, List<PatchInformation> current, IProgress<string> progress)
        {
            List<PatchInformation> patch = new List<PatchInformation>();

            if (list == null) return patch;

            for (int i = 0; i < list.Count; i++)
            {
                progress.Report($"Files Checked: {i + 1} of {list.Count}");

                PatchInformation file = list[i];
                if (current != null && current.Any(x => x.FileName == file.FileName && IsMatch(x.CheckSum, file.CheckSum))) continue;

                if (File.Exists(ClientPath + file.FileName))
                {
                    byte[] CheckSum;
                    using (MD5 md5 = MD5.Create())
                    {
                        using (FileStream stream = File.OpenRead(ClientPath + file.FileName))
                            CheckSum = md5.ComputeHash(stream);
                    }

                    if (IsMatch(CheckSum, file.CheckSum))
                        continue;
                }

                patch.Add(file);
                Interlocked.Add(ref TotalDownload, file.CompressedLength);
            }
            OutputTextBox.AppendText($"Total Files Checked: {list.Count}\r\n");

            return patch;
        }

        public bool IsMatch(byte[] a, byte[] b, long offSet = 0)
        {
            if (b == null || a == null || b.Length + offSet > a.Length || offSet < 0) return false;

            for (int i = 0; i < b.Length; i++)
                if (a[offSet + i] != b[i])
                    return false;

            return true;
        }

        private void SaveVersion(List<PatchInformation> version)
        {
            using (FileStream fStream = File.Create(ClientPath + "Version.bin"))
            using (BinaryWriter writer = new BinaryWriter(fStream))
            {
                foreach (PatchInformation info in version)
                    info.Save(writer);
            }

        }

        private async Task DownloadPatch(List<PatchInformation> patch, IProgress<string> progress)
        {
            if (patch == null || patch.Count == 0) return;

            int concurrent = Math.Max(1, Config.Concurrent);
            using (SemaphoreSlim downloadLimiter = new SemaphoreSlim(concurrent))
            {
                List<Task> workers = new List<Task>();

                foreach (PatchInformation file in patch)
                {
                    workers.Add(ProcessPatchFile(file, downloadLimiter));
                }

                if (concurrent > 1)
                {
                    progress.Report($"Downloading ({concurrent} at a time)...");
                }
                await Task.WhenAll(workers);
            }
        }

        private async Task ProcessPatchFile(PatchInformation file, SemaphoreSlim downloadLimiter)
        {
            await downloadLimiter.WaitAsync();

            Interlocked.Add(ref ActiveDownloadTotal, file.CompressedLength);

            try
            {
                bool ok = await Download(file);
                if (!ok) return;
            }
            finally
            {
                Interlocked.Add(ref ActiveDownloadTotal, -file.CompressedLength);
                downloadLimiter.Release();
            }

            await Extract(file);
        }

        private async Task<bool> Download(PatchInformation file)
        {
            string webFileName = file.FileName.Replace("\\", "-") + ".gz";
            string patchDir = Path.Combine(ClientPath, "Patch");
            string patchFile = Path.Combine(patchDir, webFileName);

            long downloadedForThisFile = 0;

            try
            {
                if (!Directory.Exists(patchDir))
                    Directory.CreateDirectory(patchDir);

                using (HttpResponseMessage response = await _httpClient.GetAsync(
                    Config.Host + webFileName,
                    HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    OutputTextBox.AppendText($"Downloading {file.FileName}\r\n");
                    StatusLabel.Text = $"Downloading {file.FileName}";

                    long contentLength = response.Content.Headers.ContentLength ?? file.CompressedLength;
                    Interlocked.Exchange(ref ActiveDownloadTotal, contentLength);
                    Interlocked.Exchange(ref CurrentProgress, 0);

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    using (FileStream fileStream = new FileStream(
                        patchFile,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None,
                        64 * 1024,
                        true))
                    {
                        byte[] buffer = new byte[64 * 1024];
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            downloadedForThisFile += bytesRead;
                            Interlocked.Add(ref CurrentProgress, bytesRead);
                        }
                    }
                }

                Interlocked.Add(ref TotalProgress, downloadedForThisFile);
                Interlocked.Exchange(ref CurrentProgress, 0);
                Interlocked.Exchange(ref ActiveDownloadTotal, 0);

                return true;
            }
            catch (Exception ex)
            {
                Interlocked.Exchange(ref CurrentProgress, 0);
                Interlocked.Exchange(ref ActiveDownloadTotal, 0);
                file.CheckSum = new byte[8];

                if (!HasError)
                {
                    HasError = true;
                    BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(
                            $"Failed downloading {file.FileName}\n\n{ex}",
                            "Download Error",
                            MessageBoxButtons.OK);
                    }));
                }

                return false;
            }
        }

        private async Task Extract(PatchInformation file)
        {
            string webFileName = file.FileName.Replace("\\", "-") + ".gz";

            try
            {
                string toPath = ClientPath + file.FileName;

                if (Application.ExecutablePath.EndsWith(file.FileName, StringComparison.OrdinalIgnoreCase))
                {
                    toPath += ".tmp";
                    NeedUpdate = true;
                }

                if (File.Exists(toPath))
                    File.Delete(toPath);

                await Decompress($"{ClientPath}Patch\\{webFileName}", toPath);
            }
            catch (UnauthorizedAccessException ex)
            {
                file.CheckSum = new byte[8];

                if (HasError) return;
                HasError = true;

                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                        ex.Message + "\n\nFile might be in use, please make sure the game is closed.",
                        "File Error",
                        MessageBoxButtons.OK);
                }));
            }
            catch (InvalidDataException ex)
            {
                file.CheckSum = new byte[8];

                if (HasError) return;
                HasError = true;

                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                        $"Invalid compressed patch file for {file.FileName}\n\n{ex.Message}",
                        "Patch Error",
                        MessageBoxButtons.OK);
                }));
            }
            catch (Exception ex)
            {
                file.CheckSum = new byte[8];

                if (HasError) return;
                HasError = true;

                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                        $"Failed extracting {file.FileName}\n\n{ex.Message}",
                        "Extract Error",
                        MessageBoxButtons.OK);
                }));
            }
        }
        private static async Task Decompress(string sourceFile, string destFile)
        {
            if (!Directory.Exists(Path.GetDirectoryName(destFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(destFile));

            using (FileStream tofile = File.Create(destFile))
            using (FileStream fromfile = File.OpenRead(sourceFile))
            using (GZipStream gStream = new GZipStream(fromfile, CompressionMode.Decompress))
            {
                await gStream.CopyToAsync(tofile);
            }
        }

        private void LMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfigReader.Save();
            _uiTimer?.Stop();
            _uiTimer?.Dispose();
            _httpClient?.Dispose();
        }

        private void Movement_panel_MouseClick(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Movement_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
                ConfigForm.Location = new Point(Location.X + 30, Location.Y + 62);
            }
        }

        private void Movement_panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Close_pb_Click(object sender, EventArgs e)
        {
            //if (ConfigForm.Visible) ConfigForm.Visible = false;
            Close();
        }

        private void Close_pb_MouseDown(object sender, MouseEventArgs e)
        {
            Close_pb.Image = Properties.Resources.Close_Clicked;
        }

        private void Close_pb_MouseEnter(object sender, EventArgs e)
        {
            Close_pb.Image = Properties.Resources.Close_Hover;
        }

        private void Close_pb_MouseLeave(object sender, EventArgs e)
        {
            Close_pb.Image = Properties.Resources.Close_Normal;
        }

        private void Close_pb_MouseUp(object sender, MouseEventArgs e)
        {
            Close_pb.Image = Properties.Resources.Close_Normal;
        }

        private void Config_pb_Click(object sender, EventArgs e)
        {
            if (ConfigForm.Visible) ConfigForm.Hide();
            else ConfigForm.Show(this);
            ConfigForm.Location = new Point(Location.X + 30, Location.Y + 62);
        }

        private void Config_pb_MouseDown(object sender, MouseEventArgs e)
        {
            Config_pb.Image = Properties.Resources.Config_Clicked;
        }

        private void Config_pb_MouseEnter(object sender, EventArgs e)
        {
            Config_pb.Image = Properties.Resources.Config_Hover;
        }

        private void Config_pb_MouseLeave(object sender, EventArgs e)
        {
            Config_pb.Image = Properties.Resources.Config_Normal;
        }

        private void Config_pb_MouseUp(object sender, MouseEventArgs e)
        {
            Config_pb.Image = Properties.Resources.Config_Hover;
        }

        private void Credit_label_Click(object sender, EventArgs e)
        {
            if (Credit_label.Text == "NexusMir - Powered by Carbon M3") Credit_label.Text = "Designed by Valhalla @ LOMCN";
            else Credit_label.Text = "NexusMir - Powered by Carbon M3";
        }

        private void Launch_pb_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(ClientPath + ClientFileName);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Launch_pb_MouseDown(object sender, MouseEventArgs e)
        {
            Launch_pb.Image = Properties.Resources.Start_Clicked;
        }

        private void Launch_pb_MouseEnter(object sender, EventArgs e)
        {
            Launch_pb.Image = Properties.Resources.Start_Hover;
        }

        private void Launch_pb_MouseLeave(object sender, EventArgs e)
        {
            Launch_pb.Image = Properties.Resources.Start_Normal;
        }

        private void Launch_pb_MouseUp(object sender, MouseEventArgs e)
        {
            Launch_pb.Image = Properties.Resources.Start_Hover;
        }
    }
}
