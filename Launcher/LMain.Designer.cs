namespace Launcher
{
    partial class LMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LMain));
            DLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            StatusLabel = new DevExpress.XtraEditors.LabelControl();
            DownloadSizeLabel = new DevExpress.XtraEditors.LabelControl();
            DownloadSpeedLabel = new DevExpress.XtraEditors.LabelControl();
            Movement_panel = new System.Windows.Forms.Panel();
            Version_label = new System.Windows.Forms.Label();
            Credit_label = new DevExpress.XtraEditors.LabelControl();
            Config_pb = new System.Windows.Forms.PictureBox();
            Close_pb = new System.Windows.Forms.PictureBox();
            Launch_pb = new System.Windows.Forms.PictureBox();
            OutputTextBox = new System.Windows.Forms.TextBox();
            Main_browser = new Microsoft.Web.WebView2.WinForms.WebView2();
            TotalPercent_label = new DevExpress.XtraEditors.LabelControl();
            CurrentPercent_label = new DevExpress.XtraEditors.LabelControl();
            ProgressCurrent_pb = new System.Windows.Forms.PictureBox();
            TotalProg_pb = new System.Windows.Forms.PictureBox();
            Movement_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Config_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Launch_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Main_browser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProgressCurrent_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TotalProg_pb).BeginInit();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            StatusLabel.Appearance.ForeColor = System.Drawing.Color.Gray;
            StatusLabel.Appearance.Options.UseForeColor = true;
            StatusLabel.Location = new System.Drawing.Point(100, 363);
            StatusLabel.Margin = new System.Windows.Forms.Padding(4);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(41, 13);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "<None>";
            // 
            // DownloadSizeLabel
            // 
            DownloadSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            DownloadSizeLabel.Appearance.ForeColor = System.Drawing.Color.Gray;
            DownloadSizeLabel.Appearance.Options.UseForeColor = true;
            DownloadSizeLabel.Location = new System.Drawing.Point(497, 363);
            DownloadSizeLabel.Margin = new System.Windows.Forms.Padding(4);
            DownloadSizeLabel.Name = "DownloadSizeLabel";
            DownloadSizeLabel.Size = new System.Drawing.Size(41, 13);
            DownloadSizeLabel.TabIndex = 5;
            DownloadSizeLabel.Text = "<None>";
            // 
            // DownloadSpeedLabel
            // 
            DownloadSpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DownloadSpeedLabel.Appearance.ForeColor = System.Drawing.Color.Gray;
            DownloadSpeedLabel.Appearance.Options.UseForeColor = true;
            DownloadSpeedLabel.Location = new System.Drawing.Point(418, 364);
            DownloadSpeedLabel.Margin = new System.Windows.Forms.Padding(4);
            DownloadSpeedLabel.Name = "DownloadSpeedLabel";
            DownloadSpeedLabel.Size = new System.Drawing.Size(41, 13);
            DownloadSpeedLabel.TabIndex = 7;
            DownloadSpeedLabel.Text = "<None>";
            // 
            // Movement_panel
            // 
            Movement_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            Movement_panel.Controls.Add(Version_label);
            Movement_panel.Controls.Add(Credit_label);
            Movement_panel.Controls.Add(Config_pb);
            Movement_panel.Controls.Add(Close_pb);
            Movement_panel.Location = new System.Drawing.Point(19, 22);
            Movement_panel.Name = "Movement_panel";
            Movement_panel.Size = new System.Drawing.Size(754, 41);
            Movement_panel.TabIndex = 16;
            Movement_panel.MouseClick += Movement_panel_MouseClick;
            Movement_panel.MouseDown += Movement_panel_MouseClick;
            Movement_panel.MouseMove += Movement_panel_MouseMove;
            Movement_panel.MouseUp += Movement_panel_MouseUp;
            // 
            // Version_label
            // 
            Version_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            Version_label.BackColor = System.Drawing.Color.Transparent;
            Version_label.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Version_label.ForeColor = System.Drawing.Color.Gray;
            Version_label.Location = new System.Drawing.Point(523, 9);
            Version_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Version_label.Name = "Version_label";
            Version_label.Size = new System.Drawing.Size(166, 13);
            Version_label.TabIndex = 32;
            Version_label.Text = "Build: TestBranch-V0.0.0.1";
            // 
            // Credit_label
            // 
            Credit_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            Credit_label.Appearance.ForeColor = System.Drawing.Color.Gray;
            Credit_label.Appearance.Options.UseForeColor = true;
            Credit_label.Location = new System.Drawing.Point(18, 9);
            Credit_label.Margin = new System.Windows.Forms.Padding(4);
            Credit_label.Name = "Credit_label";
            Credit_label.Size = new System.Drawing.Size(166, 13);
            Credit_label.TabIndex = 17;
            Credit_label.Text = "NexusMir - Powered by Carbon M3";
            Credit_label.Click += Credit_label_Click;
            // 
            // Config_pb
            // 
            Config_pb.Image = Properties.Resources.Config_Normal;
            Config_pb.Location = new System.Drawing.Point(693, 5);
            Config_pb.Name = "Config_pb";
            Config_pb.Size = new System.Drawing.Size(27, 22);
            Config_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Config_pb.TabIndex = 11;
            Config_pb.TabStop = false;
            Config_pb.Click += Config_pb_Click;
            Config_pb.MouseDown += Config_pb_MouseDown;
            Config_pb.MouseEnter += Config_pb_MouseEnter;
            Config_pb.MouseLeave += Config_pb_MouseLeave;
            Config_pb.MouseUp += Config_pb_MouseUp;
            // 
            // Close_pb
            // 
            Close_pb.Image = (System.Drawing.Image)resources.GetObject("Close_pb.Image");
            Close_pb.Location = new System.Drawing.Point(722, 5);
            Close_pb.Name = "Close_pb";
            Close_pb.Size = new System.Drawing.Size(27, 22);
            Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Close_pb.TabIndex = 10;
            Close_pb.TabStop = false;
            Close_pb.Click += Close_pb_Click;
            Close_pb.MouseDown += Close_pb_MouseDown;
            Close_pb.MouseEnter += Close_pb_MouseEnter;
            Close_pb.MouseLeave += Close_pb_MouseLeave;
            Close_pb.MouseUp += Close_pb_MouseUp;
            // 
            // Launch_pb
            // 
            Launch_pb.Image = Properties.Resources.Start_Normal;
            Launch_pb.Location = new System.Drawing.Point(681, 367);
            Launch_pb.Name = "Launch_pb";
            Launch_pb.Size = new System.Drawing.Size(74, 24);
            Launch_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Launch_pb.TabIndex = 33;
            Launch_pb.TabStop = false;
            Launch_pb.Click += Launch_pb_Click;
            Launch_pb.MouseDown += Launch_pb_MouseDown;
            Launch_pb.MouseEnter += Launch_pb_MouseEnter;
            Launch_pb.MouseLeave += Launch_pb_MouseLeave;
            Launch_pb.MouseUp += Launch_pb_MouseUp;
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            OutputTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            OutputTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            OutputTextBox.Location = new System.Drawing.Point(167, 64);
            OutputTextBox.Multiline = true;
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            OutputTextBox.Size = new System.Drawing.Size(592, 293);
            OutputTextBox.TabIndex = 34;
            // 
            // Main_browser
            // 
            Main_browser.AllowExternalDrop = true;
            Main_browser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            Main_browser.CreationProperties = null;
            Main_browser.DefaultBackgroundColor = System.Drawing.Color.White;
            Main_browser.Location = new System.Drawing.Point(167, 64);
            Main_browser.Name = "Main_browser";
            Main_browser.Size = new System.Drawing.Size(592, 293);
            Main_browser.TabIndex = 35;
            Main_browser.ZoomFactor = 1D;
            // 
            // TotalPercent_label
            // 
            TotalPercent_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            TotalPercent_label.Appearance.ForeColor = System.Drawing.Color.Gray;
            TotalPercent_label.Appearance.Options.UseForeColor = true;
            TotalPercent_label.Location = new System.Drawing.Point(631, 363);
            TotalPercent_label.Margin = new System.Windows.Forms.Padding(4);
            TotalPercent_label.Name = "TotalPercent_label";
            TotalPercent_label.Size = new System.Drawing.Size(29, 13);
            TotalPercent_label.TabIndex = 36;
            TotalPercent_label.Text = "100%";
            // 
            // CurrentPercent_label
            // 
            CurrentPercent_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CurrentPercent_label.Appearance.ForeColor = System.Drawing.Color.Gray;
            CurrentPercent_label.Appearance.Options.UseForeColor = true;
            CurrentPercent_label.Location = new System.Drawing.Point(310, 363);
            CurrentPercent_label.Margin = new System.Windows.Forms.Padding(4);
            CurrentPercent_label.Name = "CurrentPercent_label";
            CurrentPercent_label.Size = new System.Drawing.Size(29, 13);
            CurrentPercent_label.TabIndex = 37;
            CurrentPercent_label.Text = "100%";
            // 
            // ProgressCurrent_pb
            // 
            ProgressCurrent_pb.Image = Properties.Resources.Current;
            ProgressCurrent_pb.Location = new System.Drawing.Point(96, 384);
            ProgressCurrent_pb.Name = "ProgressCurrent_pb";
            ProgressCurrent_pb.Size = new System.Drawing.Size(250, 9);
            ProgressCurrent_pb.TabIndex = 38;
            ProgressCurrent_pb.TabStop = false;
            // 
            // TotalProg_pb
            // 
            TotalProg_pb.Image = Properties.Resources.Total;
            TotalProg_pb.Location = new System.Drawing.Point(417, 384);
            TotalProg_pb.Name = "TotalProg_pb";
            TotalProg_pb.Size = new System.Drawing.Size(250, 9);
            TotalProg_pb.TabIndex = 39;
            TotalProg_pb.TabStop = false;
            // 
            // LMain
            // 
            Appearance.BackColor = System.Drawing.Color.Transparent;
            Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            BackgroundImageStore = (System.Drawing.Image)resources.GetObject("$this.BackgroundImageStore");
            ClientSize = new System.Drawing.Size(794, 422);
            ControlBox = false;
            Controls.Add(TotalProg_pb);
            Controls.Add(ProgressCurrent_pb);
            Controls.Add(CurrentPercent_label);
            Controls.Add(TotalPercent_label);
            Controls.Add(Main_browser);
            Controls.Add(OutputTextBox);
            Controls.Add(Launch_pb);
            Controls.Add(Movement_panel);
            Controls.Add(DownloadSpeedLabel);
            Controls.Add(DownloadSizeLabel);
            Controls.Add(StatusLabel);
            DoubleBuffered = true;
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("LMain.IconOptions.Icon");
            LookAndFeel.SkinName = "Visual Studio 2013 Light";
            LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            LookAndFeel.UseDefaultLookAndFeel = false;
            Margin = new System.Windows.Forms.Padding(4);
            MinimizeBox = false;
            Name = "LMain";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NexusMir | Launcher";
            TransparencyKey = System.Drawing.Color.Black;
            FormClosed += LMain_FormClosed;
            Load += LMain_Load;
            Movement_panel.ResumeLayout(false);
            Movement_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Config_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)Close_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)Launch_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)Main_browser).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProgressCurrent_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)TotalProg_pb).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel DLookAndFeel;
        private DevExpress.XtraEditors.LabelControl StatusLabel;
        private DevExpress.XtraEditors.LabelControl DownloadSizeLabel;
        private DevExpress.XtraEditors.LabelControl DownloadSpeedLabel;
        private System.Windows.Forms.Panel Movement_panel;
        private System.Windows.Forms.PictureBox Close_pb;
        private System.Windows.Forms.PictureBox Config_pb;
        private DevExpress.XtraEditors.LabelControl Credit_label;
        private System.Windows.Forms.Label Version_label;
        private System.Windows.Forms.PictureBox Launch_pb;
        public Microsoft.Web.WebView2.WinForms.WebView2 Main_browser;
        public System.Windows.Forms.TextBox OutputTextBox;
        private DevExpress.XtraEditors.LabelControl TotalPercent_label;
        private DevExpress.XtraEditors.LabelControl CurrentPercent_label;
        private System.Windows.Forms.PictureBox ProgressCurrent_pb;
        private System.Windows.Forms.PictureBox TotalProg_pb;
    }
}

