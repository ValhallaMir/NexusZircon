namespace LibraryEditor
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
            MainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            functionsToolStripMenuItem = new ToolStripMenuItem();
            copyToToolStripMenuItem = new ToolStripMenuItem();
            countBlanksToolStripMenuItem = new ToolStripMenuItem();
            removeBlanksToolStripMenuItem = new ToolStripMenuItem();
            safeToolStripMenuItem = new ToolStripMenuItem();
            convertToolStripMenuItem = new ToolStripMenuItem();
            skinToolStripMenuItem = new ToolStripMenuItem();
            MainSplitContainer = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer1 = new SplitContainer();
            TreeBrowser = new TreeView();
            SearchButton = new Button();
            PathTxtBox = new TextBox();
            label3 = new Label();
            BtnXMinusTen = new Button();
            InsertBlankButton = new Button();
            label2 = new Label();
            AddBlankButton = new Button();
            panel1 = new Panel();
            radioButtonOverlay = new RadioButton();
            radioButtonShadow = new RadioButton();
            radioButtonImage = new RadioButton();
            nudJump = new NumericUpDown();
            ShadowTypeLabel = new Label();
            buttonSkipPrevious = new Button();
            checkBoxPreventAntiAliasing = new CheckBox();
            buttonSkipNext = new Button();
            checkBoxQuality = new CheckBox();
            buttonReplace = new Button();
            pictureBox = new PictureBox();
            ExportButton = new Button();
            HeightLabel = new Label();
            mergeBtn = new Button();
            label1 = new Label();
            InsertImageButton = new Button();
            WidthLabel = new Label();
            DeleteButton = new Button();
            label6 = new Label();
            AddButton = new Button();
            ZoomTrackBar = new TrackBar();
            OffSetXTextBox = new TextBox();
            label8 = new Label();
            label10 = new Label();
            OffSetYTextBox = new TextBox();
            panel = new Panel();
            ImageBox = new PictureBox();
            PreviewListView = new FixedListView();
            ImageList = new ImageList(components);
            OpenLibraryDialog = new OpenFileDialog();
            SaveLibraryDialog = new SaveFileDialog();
            ImportImageDialog = new OpenFileDialog();
            OpenWeMadeDialog = new OpenFileDialog();
            OpenMergeDialog = new OpenFileDialog();
            toolTip = new ToolTip(components);
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripProgressBar = new ToolStripProgressBar();
            BtnXMinusFive = new Button();
            BtnXMinusOne = new Button();
            BtnXPlusTen = new Button();
            BtnXPlusFive = new Button();
            BtnXPlusOne = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudJump).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZoomTrackBar).BeginInit();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.ImageScalingSize = new Size(24, 24);
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, functionsToolStripMenuItem, skinToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new Padding(7, 2, 0, 2);
            MainMenu.RenderMode = ToolStripRenderMode.Professional;
            MainMenu.Size = new Size(1350, 32);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripMenuItem1, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem2, closeToolStripMenuItem });
            fileToolStripMenuItem.Image = (Image)resources.GetObject("fileToolStripMenuItem.Image");
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(61, 28);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.ToolTipText = "New .Lib";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.ToolTipText = "Open Shanda or Wemade files.";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.ToolTipText = "Saves currently open .Lib";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = (Image)resources.GetObject("saveAsToolStripMenuItem.Image");
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.ToolTipText = ".Lib Only.";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(111, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Image = (Image)resources.GetObject("closeToolStripMenuItem.Image");
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(114, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.ToolTipText = "Exit Application.";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // functionsToolStripMenuItem
            // 
            functionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToToolStripMenuItem, countBlanksToolStripMenuItem, removeBlanksToolStripMenuItem, convertToolStripMenuItem });
            functionsToolStripMenuItem.Image = (Image)resources.GetObject("functionsToolStripMenuItem.Image");
            functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            functionsToolStripMenuItem.Size = new Size(95, 28);
            functionsToolStripMenuItem.Text = "Functions";
            // 
            // copyToToolStripMenuItem
            // 
            copyToToolStripMenuItem.Image = (Image)resources.GetObject("copyToToolStripMenuItem.Image");
            copyToToolStripMenuItem.Name = "copyToToolStripMenuItem";
            copyToToolStripMenuItem.Size = new Size(154, 22);
            copyToToolStripMenuItem.Text = "Copy To..";
            copyToToolStripMenuItem.ToolTipText = "Copy to a new .Lib or to the end of an exsisting one.";
            copyToToolStripMenuItem.Visible = false;
            copyToToolStripMenuItem.Click += copyToToolStripMenuItem_Click;
            // 
            // countBlanksToolStripMenuItem
            // 
            countBlanksToolStripMenuItem.Image = (Image)resources.GetObject("countBlanksToolStripMenuItem.Image");
            countBlanksToolStripMenuItem.Name = "countBlanksToolStripMenuItem";
            countBlanksToolStripMenuItem.Size = new Size(154, 22);
            countBlanksToolStripMenuItem.Text = "Count Blanks";
            countBlanksToolStripMenuItem.ToolTipText = "Counts the blank images in the .Lib";
            countBlanksToolStripMenuItem.Visible = false;
            countBlanksToolStripMenuItem.Click += countBlanksToolStripMenuItem_Click;
            // 
            // removeBlanksToolStripMenuItem
            // 
            removeBlanksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { safeToolStripMenuItem });
            removeBlanksToolStripMenuItem.Image = (Image)resources.GetObject("removeBlanksToolStripMenuItem.Image");
            removeBlanksToolStripMenuItem.Name = "removeBlanksToolStripMenuItem";
            removeBlanksToolStripMenuItem.Size = new Size(154, 22);
            removeBlanksToolStripMenuItem.Text = "Remove Blanks";
            removeBlanksToolStripMenuItem.ToolTipText = "Quick removal of blanks.";
            removeBlanksToolStripMenuItem.Click += removeBlanksToolStripMenuItem_Click;
            // 
            // safeToolStripMenuItem
            // 
            safeToolStripMenuItem.Image = (Image)resources.GetObject("safeToolStripMenuItem.Image");
            safeToolStripMenuItem.Name = "safeToolStripMenuItem";
            safeToolStripMenuItem.Size = new Size(96, 22);
            safeToolStripMenuItem.Text = "Safe";
            safeToolStripMenuItem.ToolTipText = "Use the safe method of removing blanks.";
            safeToolStripMenuItem.Click += safeToolStripMenuItem_Click;
            // 
            // convertToolStripMenuItem
            // 
            convertToolStripMenuItem.Image = (Image)resources.GetObject("convertToolStripMenuItem.Image");
            convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            convertToolStripMenuItem.Size = new Size(154, 22);
            convertToolStripMenuItem.Text = "Converter";
            convertToolStripMenuItem.ToolTipText = "Convert Wil/Wzl/Miz to .Lib";
            convertToolStripMenuItem.Click += convertToolStripMenuItem_Click;
            // 
            // skinToolStripMenuItem
            // 
            skinToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            skinToolStripMenuItem.Image = (Image)resources.GetObject("skinToolStripMenuItem.Image");
            skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            skinToolStripMenuItem.Size = new Size(65, 28);
            skinToolStripMenuItem.Text = "Skin";
            skinToolStripMenuItem.Visible = false;
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.BorderStyle = BorderStyle.FixedSingle;
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.FixedPanel = FixedPanel.Panel1;
            MainSplitContainer.Location = new Point(0, 32);
            MainSplitContainer.Margin = new Padding(4, 3, 4, 3);
            MainSplitContainer.Name = "MainSplitContainer";
            MainSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(splitContainer2);
            MainSplitContainer.Panel1MinSize = 325;
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(PreviewListView);
            MainSplitContainer.Size = new Size(1350, 674);
            MainSplitContainer.SplitterDistance = 477;
            MainSplitContainer.SplitterWidth = 5;
            MainSplitContainer.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel1.ForeColor = Color.Black;
            splitContainer2.Panel1MinSize = 240;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel);
            splitContainer2.Size = new Size(1350, 477);
            splitContainer2.SplitterDistance = 555;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TreeBrowser);
            splitContainer1.Panel1.Controls.Add(SearchButton);
            splitContainer1.Panel1.Controls.Add(PathTxtBox);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(checkBoxPreventAntiAliasing);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(checkBoxQuality);
            splitContainer1.Panel2.Controls.Add(ZoomTrackBar);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(button6);
            splitContainer1.Panel2.Controls.Add(BtnXPlusTen);
            splitContainer1.Panel2.Controls.Add(BtnXPlusFive);
            splitContainer1.Panel2.Controls.Add(BtnXPlusOne);
            splitContainer1.Panel2.Controls.Add(BtnXMinusOne);
            splitContainer1.Panel2.Controls.Add(BtnXMinusFive);
            splitContainer1.Panel2.Controls.Add(BtnXMinusTen);
            splitContainer1.Panel2.Controls.Add(InsertBlankButton);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(AddBlankButton);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(nudJump);
            splitContainer1.Panel2.Controls.Add(ShadowTypeLabel);
            splitContainer1.Panel2.Controls.Add(buttonSkipPrevious);
            splitContainer1.Panel2.Controls.Add(buttonSkipNext);
            splitContainer1.Panel2.Controls.Add(buttonReplace);
            splitContainer1.Panel2.Controls.Add(pictureBox);
            splitContainer1.Panel2.Controls.Add(ExportButton);
            splitContainer1.Panel2.Controls.Add(HeightLabel);
            splitContainer1.Panel2.Controls.Add(mergeBtn);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(InsertImageButton);
            splitContainer1.Panel2.Controls.Add(WidthLabel);
            splitContainer1.Panel2.Controls.Add(DeleteButton);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(AddButton);
            splitContainer1.Panel2.Controls.Add(OffSetXTextBox);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Panel2.Controls.Add(OffSetYTextBox);
            splitContainer1.Size = new Size(555, 477);
            splitContainer1.SplitterDistance = 303;
            splitContainer1.TabIndex = 4;
            // 
            // TreeBrowser
            // 
            TreeBrowser.Dock = DockStyle.Bottom;
            TreeBrowser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TreeBrowser.HotTracking = true;
            TreeBrowser.Location = new Point(0, 34);
            TreeBrowser.Name = "TreeBrowser";
            TreeBrowser.Size = new Size(301, 441);
            TreeBrowser.TabIndex = 3;
            TreeBrowser.AfterSelect += TreeBrowser_AfterSelect;
            TreeBrowser.KeyDown += TreeBrowser_KeyDown;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(233, 5);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(65, 23);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // PathTxtBox
            // 
            PathTxtBox.Location = new Point(54, 5);
            PathTxtBox.Name = "PathTxtBox";
            PathTxtBox.Size = new Size(173, 23);
            PathTxtBox.TabIndex = 1;
            PathTxtBox.Text = "C:\\Users\\SBerr\\Desktop\\Nexus Zircon\\Debug\\Client\\Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 9);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 0;
            label3.Text = "Path :";
            // 
            // BtnXMinusTen
            // 
            BtnXMinusTen.Location = new Point(16, 109);
            BtnXMinusTen.Name = "BtnXMinusTen";
            BtnXMinusTen.Size = new Size(35, 25);
            BtnXMinusTen.TabIndex = 27;
            BtnXMinusTen.Text = "-10";
            BtnXMinusTen.UseVisualStyleBackColor = true;
            // 
            // InsertBlankButton
            // 
            InsertBlankButton.ForeColor = SystemColors.ControlText;
            InsertBlankButton.Image = (Image)resources.GetObject("InsertBlankButton.Image");
            InsertBlankButton.ImageAlign = ContentAlignment.MiddleRight;
            InsertBlankButton.Location = new Point(124, 308);
            InsertBlankButton.Margin = new Padding(4, 3, 4, 3);
            InsertBlankButton.Name = "InsertBlankButton";
            InsertBlankButton.Size = new Size(108, 30);
            InsertBlankButton.TabIndex = 24;
            InsertBlankButton.Tag = "";
            InsertBlankButton.Text = "Insert Blanks";
            InsertBlankButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            InsertBlankButton.UseVisualStyleBackColor = true;
            InsertBlankButton.Click += InsertBlanksButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(3, 65);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 26;
            label2.Text = "Shadow Type:";
            // 
            // AddBlankButton
            // 
            AddBlankButton.ForeColor = SystemColors.ControlText;
            AddBlankButton.Image = (Image)resources.GetObject("AddBlankButton.Image");
            AddBlankButton.ImageAlign = ContentAlignment.MiddleRight;
            AddBlankButton.Location = new Point(15, 308);
            AddBlankButton.Margin = new Padding(4, 3, 4, 3);
            AddBlankButton.Name = "AddBlankButton";
            AddBlankButton.Size = new Size(108, 30);
            AddBlankButton.TabIndex = 23;
            AddBlankButton.Tag = "";
            AddBlankButton.Text = "Add Blanks";
            AddBlankButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddBlankButton.UseVisualStyleBackColor = true;
            AddBlankButton.Click += AddBlanksButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonOverlay);
            panel1.Controls.Add(radioButtonShadow);
            panel1.Controls.Add(radioButtonImage);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 32);
            panel1.TabIndex = 3;
            // 
            // radioButtonOverlay
            // 
            radioButtonOverlay.AutoSize = true;
            radioButtonOverlay.Enabled = false;
            radioButtonOverlay.Location = new Point(166, 6);
            radioButtonOverlay.Margin = new Padding(4, 3, 4, 3);
            radioButtonOverlay.Name = "radioButtonOverlay";
            radioButtonOverlay.Size = new Size(65, 19);
            radioButtonOverlay.TabIndex = 2;
            radioButtonOverlay.Text = "Overlay";
            radioButtonOverlay.UseVisualStyleBackColor = true;
            radioButtonOverlay.CheckedChanged += radioButtonOverlay_CheckedChanged;
            // 
            // radioButtonShadow
            // 
            radioButtonShadow.AutoSize = true;
            radioButtonShadow.Enabled = false;
            radioButtonShadow.Location = new Point(84, 6);
            radioButtonShadow.Margin = new Padding(4, 3, 4, 3);
            radioButtonShadow.Name = "radioButtonShadow";
            radioButtonShadow.Size = new Size(67, 19);
            radioButtonShadow.TabIndex = 1;
            radioButtonShadow.Text = "Shadow";
            radioButtonShadow.UseVisualStyleBackColor = true;
            radioButtonShadow.CheckedChanged += radioButtonShadow_CheckedChanged;
            // 
            // radioButtonImage
            // 
            radioButtonImage.AutoSize = true;
            radioButtonImage.Checked = true;
            radioButtonImage.Enabled = false;
            radioButtonImage.Location = new Point(15, 6);
            radioButtonImage.Margin = new Padding(4, 3, 4, 3);
            radioButtonImage.Name = "radioButtonImage";
            radioButtonImage.Size = new Size(58, 19);
            radioButtonImage.TabIndex = 0;
            radioButtonImage.TabStop = true;
            radioButtonImage.Text = "Image";
            radioButtonImage.UseVisualStyleBackColor = true;
            radioButtonImage.CheckedChanged += radioButtonImage_CheckedChanged;
            // 
            // nudJump
            // 
            nudJump.BorderStyle = BorderStyle.FixedSingle;
            nudJump.Font = new Font("Segoe UI", 12F);
            nudJump.Location = new Point(59, 344);
            nudJump.Margin = new Padding(4, 3, 4, 3);
            nudJump.Maximum = new decimal(new int[] { 650000, 0, 0, 0 });
            nudJump.Name = "nudJump";
            nudJump.Size = new Size(130, 29);
            nudJump.TabIndex = 21;
            nudJump.ValueChanged += nudJump_ValueChanged;
            nudJump.KeyDown += nudJump_KeyDown;
            // 
            // ShadowTypeLabel
            // 
            ShadowTypeLabel.AutoSize = true;
            ShadowTypeLabel.ForeColor = SystemColors.ControlText;
            ShadowTypeLabel.Location = new Point(90, 65);
            ShadowTypeLabel.Margin = new Padding(4, 0, 4, 0);
            ShadowTypeLabel.Name = "ShadowTypeLabel";
            ShadowTypeLabel.Size = new Size(75, 15);
            ShadowTypeLabel.TabIndex = 25;
            ShadowTypeLabel.Text = "<No Image>";
            // 
            // buttonSkipPrevious
            // 
            buttonSkipPrevious.ForeColor = SystemColors.ControlText;
            buttonSkipPrevious.Image = (Image)resources.GetObject("buttonSkipPrevious.Image");
            buttonSkipPrevious.Location = new Point(16, 344);
            buttonSkipPrevious.Margin = new Padding(4, 3, 4, 3);
            buttonSkipPrevious.Name = "buttonSkipPrevious";
            buttonSkipPrevious.Size = new Size(35, 30);
            buttonSkipPrevious.TabIndex = 17;
            buttonSkipPrevious.Tag = "";
            buttonSkipPrevious.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonSkipPrevious.UseVisualStyleBackColor = true;
            buttonSkipPrevious.Click += buttonSkipPrevious_Click;
            // 
            // checkBoxPreventAntiAliasing
            // 
            checkBoxPreventAntiAliasing.AutoSize = true;
            checkBoxPreventAntiAliasing.Location = new Point(119, 431);
            checkBoxPreventAntiAliasing.Margin = new Padding(4, 3, 4, 3);
            checkBoxPreventAntiAliasing.Name = "checkBoxPreventAntiAliasing";
            checkBoxPreventAntiAliasing.Size = new Size(112, 19);
            checkBoxPreventAntiAliasing.TabIndex = 20;
            checkBoxPreventAntiAliasing.Text = "No Anti-aliasing";
            checkBoxPreventAntiAliasing.UseVisualStyleBackColor = true;
            checkBoxPreventAntiAliasing.CheckedChanged += checkBoxPreventAntiAliasing_CheckedChanged;
            // 
            // buttonSkipNext
            // 
            buttonSkipNext.ForeColor = SystemColors.ControlText;
            buttonSkipNext.Image = (Image)resources.GetObject("buttonSkipNext.Image");
            buttonSkipNext.Location = new Point(197, 344);
            buttonSkipNext.Margin = new Padding(4, 3, 4, 3);
            buttonSkipNext.Name = "buttonSkipNext";
            buttonSkipNext.Size = new Size(35, 30);
            buttonSkipNext.TabIndex = 16;
            buttonSkipNext.Tag = "";
            buttonSkipNext.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonSkipNext.UseVisualStyleBackColor = true;
            buttonSkipNext.Click += buttonSkipNext_Click;
            // 
            // checkBoxQuality
            // 
            checkBoxQuality.AutoSize = true;
            checkBoxQuality.Location = new Point(16, 431);
            checkBoxQuality.Margin = new Padding(4, 3, 4, 3);
            checkBoxQuality.Name = "checkBoxQuality";
            checkBoxQuality.Size = new Size(87, 19);
            checkBoxQuality.TabIndex = 19;
            checkBoxQuality.Text = "No Blurring";
            checkBoxQuality.UseVisualStyleBackColor = true;
            checkBoxQuality.CheckedChanged += checkBoxQuality_CheckedChanged;
            // 
            // buttonReplace
            // 
            buttonReplace.ForeColor = SystemColors.ControlText;
            buttonReplace.Image = (Image)resources.GetObject("buttonReplace.Image");
            buttonReplace.ImageAlign = ContentAlignment.MiddleRight;
            buttonReplace.Location = new Point(15, 236);
            buttonReplace.Margin = new Padding(4, 3, 4, 3);
            buttonReplace.Name = "buttonReplace";
            buttonReplace.Size = new Size(108, 30);
            buttonReplace.TabIndex = 15;
            buttonReplace.Tag = "";
            buttonReplace.Text = "Replace Image";
            buttonReplace.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonReplace.UseVisualStyleBackColor = true;
            buttonReplace.Click += buttonReplace_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(216, 38);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(16, 16);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 14;
            pictureBox.TabStop = false;
            toolTip.SetToolTip(pictureBox, "Switch from Black to White background.");
            pictureBox.Click += pictureBox_Click;
            // 
            // ExportButton
            // 
            ExportButton.ForeColor = SystemColors.ControlText;
            ExportButton.Image = (Image)resources.GetObject("ExportButton.Image");
            ExportButton.ImageAlign = ContentAlignment.MiddleRight;
            ExportButton.Location = new Point(124, 272);
            ExportButton.Margin = new Padding(4, 3, 4, 3);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(108, 30);
            ExportButton.TabIndex = 3;
            ExportButton.Tag = "";
            ExportButton.Text = "Export Images";
            ExportButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += ExportButton_Click;
            // 
            // HeightLabel
            // 
            HeightLabel.AutoSize = true;
            HeightLabel.ForeColor = SystemColors.ControlText;
            HeightLabel.Location = new Point(90, 50);
            HeightLabel.Margin = new Padding(4, 0, 4, 0);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(75, 15);
            HeightLabel.TabIndex = 10;
            HeightLabel.Text = "<No Image>";
            // 
            // mergeBtn
            // 
            mergeBtn.ForeColor = SystemColors.ControlText;
            mergeBtn.Image = (Image)resources.GetObject("mergeBtn.Image");
            mergeBtn.ImageAlign = ContentAlignment.MiddleRight;
            mergeBtn.Location = new Point(16, 272);
            mergeBtn.Margin = new Padding(4, 3, 4, 3);
            mergeBtn.Name = "mergeBtn";
            mergeBtn.Size = new Size(107, 30);
            mergeBtn.TabIndex = 22;
            mergeBtn.Tag = "";
            mergeBtn.Text = "Merge Libs";
            mergeBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            mergeBtn.UseVisualStyleBackColor = true;
            mergeBtn.Click += MergeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(40, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 7;
            label1.Text = "Width:";
            // 
            // InsertImageButton
            // 
            InsertImageButton.ForeColor = SystemColors.ControlText;
            InsertImageButton.Image = (Image)resources.GetObject("InsertImageButton.Image");
            InsertImageButton.ImageAlign = ContentAlignment.MiddleRight;
            InsertImageButton.Location = new Point(124, 236);
            InsertImageButton.Margin = new Padding(4, 3, 4, 3);
            InsertImageButton.Name = "InsertImageButton";
            InsertImageButton.Size = new Size(108, 30);
            InsertImageButton.TabIndex = 1;
            InsertImageButton.Tag = "";
            InsertImageButton.Text = "Insert Images";
            InsertImageButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            InsertImageButton.UseVisualStyleBackColor = true;
            InsertImageButton.Click += InsertImageButton_Click;
            // 
            // WidthLabel
            // 
            WidthLabel.AutoSize = true;
            WidthLabel.ForeColor = SystemColors.ControlText;
            WidthLabel.Location = new Point(90, 35);
            WidthLabel.Margin = new Padding(4, 0, 4, 0);
            WidthLabel.Name = "WidthLabel";
            WidthLabel.Size = new Size(75, 15);
            WidthLabel.TabIndex = 8;
            WidthLabel.Text = "<No Image>";
            // 
            // DeleteButton
            // 
            DeleteButton.ForeColor = SystemColors.ControlText;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageAlign = ContentAlignment.MiddleRight;
            DeleteButton.Location = new Point(124, 200);
            DeleteButton.Margin = new Padding(4, 3, 4, 3);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(108, 30);
            DeleteButton.TabIndex = 2;
            DeleteButton.Tag = "";
            DeleteButton.Text = "Delete Images";
            DeleteButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(36, 50);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 9;
            label6.Text = "Height:";
            // 
            // AddButton
            // 
            AddButton.ForeColor = SystemColors.ControlText;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.ImageAlign = ContentAlignment.MiddleRight;
            AddButton.Location = new Point(15, 200);
            AddButton.Margin = new Padding(4, 3, 4, 3);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(108, 30);
            AddButton.TabIndex = 0;
            AddButton.Tag = "";
            AddButton.Text = "Add Images";
            AddButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // ZoomTrackBar
            // 
            ZoomTrackBar.LargeChange = 1;
            ZoomTrackBar.Location = new Point(15, 380);
            ZoomTrackBar.Margin = new Padding(4, 3, 4, 3);
            ZoomTrackBar.Minimum = 1;
            ZoomTrackBar.Name = "ZoomTrackBar";
            ZoomTrackBar.Size = new Size(217, 45);
            ZoomTrackBar.TabIndex = 4;
            ZoomTrackBar.TickStyle = TickStyle.TopLeft;
            ZoomTrackBar.Value = 1;
            ZoomTrackBar.Scroll += ZoomTrackBar_Scroll;
            // 
            // OffSetXTextBox
            // 
            OffSetXTextBox.Location = new Point(87, 83);
            OffSetXTextBox.Margin = new Padding(4, 3, 4, 3);
            OffSetXTextBox.Name = "OffSetXTextBox";
            OffSetXTextBox.Size = new Size(75, 23);
            OffSetXTextBox.TabIndex = 5;
            OffSetXTextBox.TextChanged += OffSetXTextBox_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(26, 91);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 11;
            label8.Text = "OffSet X:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(26, 143);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 12;
            label10.Text = "OffSet Y:";
            // 
            // OffSetYTextBox
            // 
            OffSetYTextBox.Location = new Point(87, 140);
            OffSetYTextBox.Margin = new Padding(4, 3, 4, 3);
            OffSetYTextBox.Name = "OffSetYTextBox";
            OffSetYTextBox.Size = new Size(75, 23);
            OffSetYTextBox.TabIndex = 6;
            OffSetYTextBox.TextChanged += OffSetYTextBox_TextChanged;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.BackColor = Color.Black;
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Controls.Add(ImageBox);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(4, 3, 4, 3);
            panel.Name = "panel";
            panel.Size = new Size(788, 475);
            panel.TabIndex = 1;
            // 
            // ImageBox
            // 
            ImageBox.BackColor = Color.Transparent;
            ImageBox.Location = new Point(-2, -1);
            ImageBox.Margin = new Padding(4, 3, 4, 3);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(64, 64);
            ImageBox.SizeMode = PictureBoxSizeMode.AutoSize;
            ImageBox.TabIndex = 0;
            ImageBox.TabStop = false;
            // 
            // PreviewListView
            // 
            PreviewListView.Activation = ItemActivation.OneClick;
            PreviewListView.BackColor = Color.GhostWhite;
            PreviewListView.Dock = DockStyle.Fill;
            PreviewListView.ForeColor = Color.FromArgb(142, 152, 156);
            PreviewListView.LargeImageList = ImageList;
            PreviewListView.Location = new Point(0, 0);
            PreviewListView.Margin = new Padding(4, 3, 4, 3);
            PreviewListView.Name = "PreviewListView";
            PreviewListView.Size = new Size(1348, 190);
            PreviewListView.TabIndex = 0;
            PreviewListView.UseCompatibleStateImageBehavior = false;
            PreviewListView.VirtualMode = true;
            PreviewListView.RetrieveVirtualItem += PreviewListView_RetrieveVirtualItem;
            PreviewListView.SelectedIndexChanged += PreviewListView_SelectedIndexChanged;
            PreviewListView.VirtualItemsSelectionRangeChanged += PreviewListView_VirtualItemsSelectionRangeChanged;
            // 
            // ImageList
            // 
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
            ImageList.ImageSize = new Size(64, 64);
            ImageList.TransparentColor = Color.Transparent;
            // 
            // OpenLibraryDialog
            // 
            OpenLibraryDialog.Filter = "Zircon Library|*.Zl";
            OpenLibraryDialog.FileOk += OpenLibraryDialog_FileOk;
            // 
            // SaveLibraryDialog
            // 
            SaveLibraryDialog.Filter = "Zircon Library|*.Zl";
            // 
            // ImportImageDialog
            // 
            ImportImageDialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            ImportImageDialog.Multiselect = true;
            // 
            // OpenWeMadeDialog
            // 
            OpenWeMadeDialog.Filter = "WeMade|*.Wil;*.Wtl|Shanda|*.Wzl;*.Miz|Lib|*.Lib";
            OpenWeMadeDialog.Multiselect = true;
            // 
            // OpenMergeDialog
            // 
            OpenMergeDialog.Filter = "Zircon Library|*.Zl|WeMade|*.Wil;*.Wtl|Shanda|*.Wzl;*.Miz|Lib|*.Lib";
            OpenMergeDialog.Multiselect = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripProgressBar });
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip.Location = new Point(0, 706);
            statusStrip.MaximumSize = new Size(9999, 23);
            statusStrip.MinimumSize = new Size(1350, 23);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1350, 23);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(90, 18);
            toolStripStatusLabel.Text = "Selected Image:";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(233, 17);
            toolStripProgressBar.Step = 1;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // BtnXMinusFive
            // 
            BtnXMinusFive.Location = new Point(52, 109);
            BtnXMinusFive.Name = "BtnXMinusFive";
            BtnXMinusFive.Size = new Size(35, 25);
            BtnXMinusFive.TabIndex = 28;
            BtnXMinusFive.Text = "-5";
            BtnXMinusFive.UseVisualStyleBackColor = true;
            // 
            // BtnXMinusOne
            // 
            BtnXMinusOne.Location = new Point(88, 109);
            BtnXMinusOne.Name = "BtnXMinusOne";
            BtnXMinusOne.Size = new Size(35, 25);
            BtnXMinusOne.TabIndex = 29;
            BtnXMinusOne.Text = "-1";
            BtnXMinusOne.UseVisualStyleBackColor = true;
            // 
            // BtnXPlusTen
            // 
            BtnXPlusTen.Location = new Point(196, 109);
            BtnXPlusTen.Name = "BtnXPlusTen";
            BtnXPlusTen.Size = new Size(35, 25);
            BtnXPlusTen.TabIndex = 32;
            BtnXPlusTen.Text = "+10";
            BtnXPlusTen.UseVisualStyleBackColor = true;
            // 
            // BtnXPlusFive
            // 
            BtnXPlusFive.Location = new Point(160, 109);
            BtnXPlusFive.Name = "BtnXPlusFive";
            BtnXPlusFive.Size = new Size(35, 25);
            BtnXPlusFive.TabIndex = 31;
            BtnXPlusFive.Text = "+5";
            BtnXPlusFive.UseVisualStyleBackColor = true;
            // 
            // BtnXPlusOne
            // 
            BtnXPlusOne.Location = new Point(124, 109);
            BtnXPlusOne.Name = "BtnXPlusOne";
            BtnXPlusOne.Size = new Size(35, 25);
            BtnXPlusOne.TabIndex = 30;
            BtnXPlusOne.Text = "+1";
            BtnXPlusOne.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(196, 169);
            button1.Name = "button1";
            button1.Size = new Size(35, 25);
            button1.TabIndex = 38;
            button1.Text = "+10";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(160, 169);
            button2.Name = "button2";
            button2.Size = new Size(35, 25);
            button2.TabIndex = 37;
            button2.Text = "+5";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(124, 169);
            button3.Name = "button3";
            button3.Size = new Size(35, 25);
            button3.TabIndex = 36;
            button3.Text = "+1";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(88, 169);
            button4.Name = "button4";
            button4.Size = new Size(35, 25);
            button4.TabIndex = 35;
            button4.Text = "-1";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(52, 169);
            button5.Name = "button5";
            button5.Size = new Size(35, 25);
            button5.TabIndex = 34;
            button5.Text = "-5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(16, 169);
            button6.Name = "button6";
            button6.Size = new Size(35, 25);
            button6.TabIndex = 33;
            button6.Text = "-10";
            button6.UseVisualStyleBackColor = true;
            // 
            // LMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(MainSplitContainer);
            Controls.Add(statusStrip);
            Controls.Add(MainMenu);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1366, 768);
            Name = "LMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zircon Library Editor";
            WindowState = FormWindowState.Maximized;
            Resize += LMain_Resize;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudJump).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZoomTrackBar).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FixedListView PreviewListView;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenLibraryDialog;
        private System.Windows.Forms.SaveFileDialog SaveLibraryDialog;
        private System.Windows.Forms.OpenFileDialog ImportImageDialog;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.OpenFileDialog OpenWeMadeDialog;
        private System.Windows.Forms.OpenFileDialog OpenMergeDialog;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBlanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countBlanksToolStripMenuItem;
        private System.Windows.Forms.TextBox OffSetYTextBox;
        private System.Windows.Forms.TextBox OffSetXTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button InsertImageButton;
        private System.Windows.Forms.Button mergeBtn;
        private System.Windows.Forms.ToolStripMenuItem safeToolStripMenuItem;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem skinToolStripMenuItem;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonSkipPrevious;
        private System.Windows.Forms.Button buttonSkipNext;
        private System.Windows.Forms.CheckBox checkBoxQuality;
        private System.Windows.Forms.CheckBox checkBoxPreventAntiAliasing;
        private System.Windows.Forms.NumericUpDown nudJump;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonOverlay;
        private System.Windows.Forms.RadioButton radioButtonShadow;
        private System.Windows.Forms.RadioButton radioButtonImage;
        private System.Windows.Forms.Button InsertBlankButton;
        private System.Windows.Forms.Button AddBlankButton;
        private System.Windows.Forms.Label ShadowTypeLabel;
        private System.Windows.Forms.Label label2;
        private SplitContainer splitContainer1;
        private Label label3;
        private Button SearchButton;
        private TextBox PathTxtBox;
        private TreeView TreeBrowser;
        private Button BtnXMinusTen;
        private Button BtnXPlusTen;
        private Button BtnXPlusFive;
        private Button BtnXPlusOne;
        private Button BtnXMinusOne;
        private Button BtnXMinusFive;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}

