namespace Launcher
{
    partial class ConfigForm
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
            CleanFiles_pb = new System.Windows.Forms.PictureBox();
            DebugCheckBox = new System.Windows.Forms.PictureBox();
            UseDebugLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)CleanFiles_pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DebugCheckBox).BeginInit();
            SuspendLayout();
            // 
            // CleanFiles_pb
            // 
            CleanFiles_pb.Image = Properties.Resources.CheckF_Base2;
            CleanFiles_pb.Location = new System.Drawing.Point(34, 266);
            CleanFiles_pb.Name = "CleanFiles_pb";
            CleanFiles_pb.Size = new System.Drawing.Size(67, 23);
            CleanFiles_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CleanFiles_pb.TabIndex = 0;
            CleanFiles_pb.TabStop = false;
            CleanFiles_pb.Click += CleanFiles_pb_Click;
            CleanFiles_pb.MouseDown += CleanFiles_pb_MouseDown;
            CleanFiles_pb.MouseEnter += CleanFiles_pb_MouseEnter;
            CleanFiles_pb.MouseLeave += CleanFiles_pb_MouseLeave;
            CleanFiles_pb.MouseUp += CleanFiles_pb_MouseUp;
            // 
            // DebugCheckBox
            // 
            DebugCheckBox.Image = Properties.Resources.Config_Check_Off1;
            DebugCheckBox.Location = new System.Drawing.Point(23, 242);
            DebugCheckBox.Name = "DebugCheckBox";
            DebugCheckBox.Size = new System.Drawing.Size(12, 12);
            DebugCheckBox.TabIndex = 1;
            DebugCheckBox.TabStop = false;
            DebugCheckBox.Click += DebugCheckBox_Click;
            // 
            // UseDebugLabel
            // 
            UseDebugLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            UseDebugLabel.Appearance.ForeColor = System.Drawing.Color.Gray;
            UseDebugLabel.Appearance.Options.UseForeColor = true;
            UseDebugLabel.Location = new System.Drawing.Point(42, 241);
            UseDebugLabel.Margin = new System.Windows.Forms.Padding(4);
            UseDebugLabel.Name = "UseDebugLabel";
            UseDebugLabel.Size = new System.Drawing.Size(60, 13);
            UseDebugLabel.TabIndex = 4;
            UseDebugLabel.Text = "Debug Mode";
            // 
            // ConfigForm
            // 
            Appearance.BackColor = System.Drawing.Color.Black;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            BackgroundImageStore = Properties.Resources.Config;
            ClientSize = new System.Drawing.Size(137, 297);
            ControlBox = false;
            Controls.Add(UseDebugLabel);
            Controls.Add(DebugCheckBox);
            Controls.Add(CleanFiles_pb);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ConfigForm";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Config";
            TransparencyKey = System.Drawing.Color.Black;
            Load += ConfigForm_Load;
            ((System.ComponentModel.ISupportInitialize)CleanFiles_pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)DebugCheckBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox CleanFiles_pb;
        private System.Windows.Forms.PictureBox DebugCheckBox;
        private DevExpress.XtraEditors.LabelControl UseDebugLabel;
    }
}