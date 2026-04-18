using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Launcher
{
    public partial class LMain : DevExpress.XtraEditors.XtraForm
    {
        public const string PListFileName = "PList.Bin";
        public const string ClientPath = ".\\";
        public const string ClientFileName = "Zircon.exe";

        public DateTime LastSpeedCheck;
        public long TotalDownload, TotalProgress, CurrentProgress, LastDownloadProcess;
        public bool NeedUpdate;

        public static bool HasError;
        private HttpClient _httpClient;
        private System.Windows.Forms.Timer _uiTimer;

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
            _uiTimer.Interval = 500;
            _uiTimer.Tick += (s, e) => CreateSizeLabel();
        }
        private void LMain_Load(object sender, EventArgs e)
        {
            CheckPatch(false);
        }

        private void PatchNotesHyperlinkControl_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            PatchNotesHyperlinkControl.LinkVisited = true;
            Process.Start(e.Link);
        }

        private void RepairButton_Click(object sender, EventArgs e)
        {
            CheckPatch(true);
        }



        private async void CheckPatch(bool repair)
        {
            HasError = false;
            RepairButton.Enabled = false;
            StartGameButton.Enabled = false;
            TotalDownload = 0;
            TotalProgress = 0;
            CurrentProgress = 0;
            TotalProgressBar.EditValue = 0;
            LastSpeedCheck = Time.Now;
            NeedUpdate = false;

            _uiTimer.Start();

            Progress<string> progress = new Progress<string>(s => StatusLabel.Text = s);

            List<PatchInformation> liveVersion = await GetPatchInformation(progress);

            if (liveVersion == null)
            {
                DownloadSizeLabel.Text = "Downloading failed.";
                RepairButton.Enabled = true;
                StartGameButton.Enabled = true;
                _uiTimer.Stop();
                return;
            }

            List<PatchInformation> currentVersion = repair ? null : await LoadVersion(progress);
            List<PatchInformation> patch = await CalculatePatch(liveVersion, currentVersion, progress);

            StatusLabel.Text = "Downloading";
            CreateSizeLabel();

            await DownloadPatch(patch, progress);

            CreateSizeLabel();

            if (HasError)
            {
                _uiTimer.Stop();
                StatusLabel.Text = "Patch failed";
                RepairButton.Enabled = true;
                StartGameButton.Enabled = true;
                return;
            }

            SaveVersion(liveVersion);

            StatusLabel.Text = "Complete";
            DownloadSizeLabel.Text = "Complete.";
            DownloadSpeedLabel.Text = "Complete.";

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
            RepairButton.Enabled = true;
            StartGameButton.Enabled = true;
        }
        private void CreateSizeLabel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CreateSizeLabel));
                return;
            }

            const decimal KB = 1024;
            const decimal MB = KB * 1024;
            const decimal GB = MB * 1024;

            long totalProgress = Interlocked.Read(ref TotalProgress);
            long currentProgress = Interlocked.Read(ref CurrentProgress);
            long totalDownload = Interlocked.Read(ref TotalDownload);

            long progress = totalProgress + currentProgress;

            StringBuilder text = new StringBuilder();

            if (progress >= GB)
                text.Append($"{progress / GB:#,##0.0}GB");
            else if (progress >= MB)
                text.Append($"{progress / MB:#,##0.0}MB");
            else if (progress >= KB)
                text.Append($"{progress / KB:#,##0}KB");
            else
                text.Append($"{progress:#,##0}B");

            if (totalDownload >= GB)
                text.Append($" / {totalDownload / GB:#,##0.0}GB");
            else if (totalDownload >= MB)
                text.Append($" / {totalDownload / MB:#,##0.0}MB");
            else if (totalDownload >= KB)
                text.Append($" / {totalDownload / KB:#,##0}KB");
            else
                text.Append($" / {totalDownload:#,##0}B");

            DownloadSizeLabel.Text = text.ToString();

            if (totalDownload > 0)
                TotalProgressBar.EditValue = Math.Max(0, Math.Min(100, (int)(progress * 100 / totalDownload)));
            else
                TotalProgressBar.EditValue = 0;

            long nowTicks = Time.Now.Ticks;
            long lastTicks = LastSpeedCheck.Ticks;
            long tickDiff = nowTicks - lastTicks;

            if (tickDiff > 0)
            {
                long speed = (progress - LastDownloadProcess) * TimeSpan.TicksPerSecond / tickDiff;
                LastDownloadProcess = progress;

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

                progress.Report($"Downloading ({concurrent} at a time)...");
                await Task.WhenAll(workers);
            }
        }

        private async Task ProcessPatchFile(PatchInformation file, SemaphoreSlim downloadLimiter)
        {
            await downloadLimiter.WaitAsync();
            try
            {
                bool ok = await Download(file);
                if (!ok) return;
            }
            finally
            {
                downloadLimiter.Release();
            }

            await Extract(file);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
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

                using (HttpResponseMessage response = await _httpClient.GetAsync(Config.Host + webFileName))
                {
                    response.EnsureSuccessStatusCode();

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

                Interlocked.Add(ref CurrentProgress, -downloadedForThisFile);
                Interlocked.Add(ref TotalProgress, downloadedForThisFile);
                return true;
            }
            catch (Exception ex)
            {
                Interlocked.Add(ref CurrentProgress, -downloadedForThisFile);
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
            _uiTimer?.Stop();
            _uiTimer?.Dispose();
            _httpClient?.Dispose();
        }
    }
}
