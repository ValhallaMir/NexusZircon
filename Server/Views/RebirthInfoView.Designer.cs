namespace Server.Views
{
    partial class RebirthInfoView
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RebirthInfoView));
            RewardsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRewardItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            colRewardCount = new DevExpress.XtraGrid.Columns.GridColumn();
            BenefitsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBenefitStatName = new DevExpress.XtraGrid.Columns.GridColumn();
            colBenefitRate = new DevExpress.XtraGrid.Columns.GridColumn();
            StatImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ItemInfoLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            RebirthGridControl = new DevExpress.XtraGrid.GridControl();
            RebirthGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            colRequiredLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            colResetToLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ImportButton = new DevExpress.XtraBars.BarButtonItem();
            ExportButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            JsonGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)RewardsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BenefitsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StatImageComboBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemInfoLookUpEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // RewardsGridView
            // 
            RewardsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRewardItemName, colRewardCount });
            RewardsGridView.DetailHeight = 475;
            RewardsGridView.GridControl = RebirthGridControl;
            RewardsGridView.Name = "RewardsGridView";
            RewardsGridView.OptionsEditForm.PopupEditFormWidth = 1200;
            RewardsGridView.OptionsView.EnableAppearanceEvenRow = true;
            RewardsGridView.OptionsView.EnableAppearanceOddRow = true;
            RewardsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            RewardsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            RewardsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colRewardItemName
            // 
            colRewardItemName.ColumnEdit = ItemInfoLookUpEdit;
            colRewardItemName.Caption = "Item Name";
            colRewardItemName.FieldName = "ItemName";
            colRewardItemName.MinWidth = 25;
            colRewardItemName.Name = "colRewardItemName";
            colRewardItemName.Visible = true;
            colRewardItemName.VisibleIndex = 0;
            colRewardItemName.Width = 96;
            // 
            // colRewardCount
            // 
            colRewardCount.Caption = "Count";
            colRewardCount.FieldName = "Count";
            colRewardCount.MinWidth = 25;
            colRewardCount.Name = "colRewardCount";
            colRewardCount.Visible = true;
            colRewardCount.VisibleIndex = 1;
            colRewardCount.Width = 96;
            // 
            // BenefitsGridView
            // 
            BenefitsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBenefitStatName, colBenefitRate });
            BenefitsGridView.DetailHeight = 475;
            BenefitsGridView.GridControl = RebirthGridControl;
            BenefitsGridView.Name = "BenefitsGridView";
            BenefitsGridView.OptionsEditForm.PopupEditFormWidth = 1200;
            BenefitsGridView.OptionsView.EnableAppearanceEvenRow = true;
            BenefitsGridView.OptionsView.EnableAppearanceOddRow = true;
            BenefitsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            BenefitsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            BenefitsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colBenefitStatName
            // 
            colBenefitStatName.ColumnEdit = StatImageComboBox;
            colBenefitStatName.Caption = "Stat Name";
            colBenefitStatName.FieldName = "StatName";
            colBenefitStatName.MinWidth = 25;
            colBenefitStatName.Name = "colBenefitStatName";
            colBenefitStatName.Visible = true;
            colBenefitStatName.VisibleIndex = 0;
            colBenefitStatName.Width = 96;
            // 
            // colBenefitRate
            // 
            colBenefitRate.Caption = "Rate";
            colBenefitRate.FieldName = "Rate";
            colBenefitRate.MinWidth = 25;
            colBenefitRate.Name = "colBenefitRate";
            colBenefitRate.Visible = true;
            colBenefitRate.VisibleIndex = 1;
            colBenefitRate.Width = 96;
            // 
            // StatImageComboBox
            // 
            StatImageComboBox.AutoHeight = false;
            StatImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StatImageComboBox.Name = "StatImageComboBox";
            // 
            // ItemInfoLookUpEdit
            // 
            ItemInfoLookUpEdit.AutoHeight = false;
            ItemInfoLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ItemInfoLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            ItemInfoLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size")
            });
            ItemInfoLookUpEdit.DisplayMember = "ItemName";
            ItemInfoLookUpEdit.Name = "ItemInfoLookUpEdit";
            ItemInfoLookUpEdit.NullText = "[Item is null]";
            ItemInfoLookUpEdit.UseCtrlScroll = false;
            // 
            // RebirthGridControl
            // 
            RebirthGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            RebirthGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.LevelTemplate = BenefitsGridView;
            gridLevelNode1.RelationName = "Benefits";
            gridLevelNode2.LevelTemplate = RewardsGridView;
            gridLevelNode2.RelationName = "Rewards";
            RebirthGridControl.Location = new System.Drawing.Point(0, 209);
            RebirthGridControl.MainView = RebirthGridView;
            RebirthGridControl.Margin = new System.Windows.Forms.Padding(4);
            RebirthGridControl.MenuManager = ribbon;
            RebirthGridControl.Name = "RebirthGridControl";
            RebirthGridControl.ShowOnlyPredefinedDetails = true;
            RebirthGridControl.Size = new System.Drawing.Size(2358, 463);
            RebirthGridControl.TabIndex = 2;
            RebirthGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1, gridLevelNode2 });
            RebirthGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { StatImageComboBox, ItemInfoLookUpEdit });
            RebirthGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { RebirthGridView, RewardsGridView, BenefitsGridView });
            // 
            // RebirthGridView
            // 
            RebirthGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTitle, colOrder, colRequiredLevel, colResetToLevel, colDescription });
            RebirthGridView.DetailHeight = 475;
            RebirthGridView.GridControl = RebirthGridControl;
            RebirthGridView.Name = "RebirthGridView";
            RebirthGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            RebirthGridView.OptionsEditForm.PopupEditFormWidth = 1200;
            RebirthGridView.OptionsView.EnableAppearanceEvenRow = true;
            RebirthGridView.OptionsView.EnableAppearanceOddRow = true;
            RebirthGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            RebirthGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            RebirthGridView.OptionsView.ShowGroupPanel = false;
            RebirthGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            // 
            // colTitle
            // 
            colTitle.Caption = "Title";
            colTitle.FieldName = "Title";
            colTitle.MinWidth = 25;
            colTitle.Name = "colTitle";
            colTitle.OptionsEditForm.Caption = "Rebirth Title";
            colTitle.Visible = true;
            colTitle.VisibleIndex = 0;
            colTitle.Width = 96;
            // 
            // colOrder
            // 
            colOrder.Caption = "Order";
            colOrder.FieldName = "Order";
            colOrder.MinWidth = 25;
            colOrder.Name = "colOrder";
            colOrder.Visible = true;
            colOrder.VisibleIndex = 1;
            colOrder.Width = 96;
            // 
            // colRequiredLevel
            // 
            colRequiredLevel.Caption = "Required Level";
            colRequiredLevel.FieldName = "RequiredLevel";
            colRequiredLevel.MinWidth = 25;
            colRequiredLevel.Name = "colRequiredLevel";
            colRequiredLevel.Visible = true;
            colRequiredLevel.VisibleIndex = 2;
            colRequiredLevel.Width = 96;
            // 
            // colResetToLevel
            // 
            colResetToLevel.Caption = "Reset to Level";
            colResetToLevel.FieldName = "ResetToLevel";
            colResetToLevel.MinWidth = 25;
            colResetToLevel.Name = "colResetToLevel";
            colResetToLevel.Visible = true;
            colResetToLevel.VisibleIndex = 3;
            colResetToLevel.Width = 96;
            // 
            // colDescription
            // 
            colDescription.Caption = "Description";
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 4;
            colDescription.Width = 96;
            // 
            // ribbon
            // 
            ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(39, 41, 39, 41);
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, SaveButton, ImportButton, ExportButton });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.Margin = new System.Windows.Forms.Padding(4);
            ribbon.MaxItemId = 5;
            ribbon.Name = "ribbon";
            ribbon.OptionsMenuMinWidth = 424;
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new System.Drawing.Size(2358, 209);
            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save Database";
            SaveButton.Id = 1;
            SaveButton.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("SaveButton.ImageOptions.Image");
            SaveButton.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("SaveButton.ImageOptions.LargeImage");
            SaveButton.LargeWidth = 60;
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += SaveButton_ItemClick;
            // 
            // ImportButton
            // 
            ImportButton.Caption = "Import";
            ImportButton.Id = 2;
            ImportButton.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("ImportButton.ImageOptions.Image");
            ImportButton.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("ImportButton.ImageOptions.LargeImage");
            ImportButton.Name = "ImportButton";
            ImportButton.ItemClick += ImportButton_ItemClick;
            // 
            // ExportButton
            // 
            ExportButton.Caption = "Export";
            ExportButton.Id = 3;
            ExportButton.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("ExportButton.ImageOptions.Image");
            ExportButton.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("ExportButton.ImageOptions.LargeImage");
            ExportButton.Name = "ExportButton";
            ExportButton.ItemClick += ExportButton_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, JsonGroup });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(SaveButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Saving";
            // 
            // JsonGroup
            // 
            JsonGroup.ItemLinks.Add(ImportButton);
            JsonGroup.ItemLinks.Add(ExportButton);
            JsonGroup.Name = "JsonGroup";
            JsonGroup.Text = "Json";
            // 
            // RebirthInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2358, 672);
            Controls.Add(RebirthGridControl);
            Controls.Add(ribbon);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "RebirthInfoView";
            Ribbon = ribbon;
            Text = "Rebirth";
            ((System.ComponentModel.ISupportInitialize)RewardsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)BenefitsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)StatImageComboBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemInfoLookUpEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraBars.BarButtonItem ImportButton;
        private DevExpress.XtraBars.BarButtonItem ExportButton;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup JsonGroup;
        private DevExpress.XtraGrid.GridControl RebirthGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView RebirthGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView RewardsGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView BenefitsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colResetToLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colRewardItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colRewardCount;
        private DevExpress.XtraGrid.Columns.GridColumn colBenefitStatName;
        private DevExpress.XtraGrid.Columns.GridColumn colBenefitRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox StatImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemInfoLookUpEdit;
    }
}
