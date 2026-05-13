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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RebirthInfoView));
            InfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            RebirthGridControl = new DevExpress.XtraGrid.GridControl();
            RebirthGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ImportButton = new DevExpress.XtraBars.BarButtonItem();
            ExportButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            JsonGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ItemGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            ((System.ComponentModel.ISupportInitialize)InfoGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemMemoEdit).BeginInit();
            SuspendLayout();
            // 
            // InfoGridView
            // 
            InfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn6, gridColumn7, gridColumn9 });
            InfoGridView.DetailHeight = 475;
            InfoGridView.GridControl = RebirthGridControl;
            InfoGridView.LevelIndent = 0;
            InfoGridView.Name = "InfoGridView";
            InfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            InfoGridView.OptionsEditForm.PopupEditFormWidth = 1200;
            InfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            InfoGridView.OptionsView.EnableAppearanceOddRow = true;
            InfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            InfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            InfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Title";
            gridColumn6.FieldName = "Title";
            gridColumn6.MinWidth = 25;
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 0;
            gridColumn6.Width = 96;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "Order";
            gridColumn7.FieldName = "Order";
            gridColumn7.MinWidth = 25;
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 1;
            gridColumn7.Width = 96;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "Items";
            gridColumn9.FieldName = "Items";
            gridColumn9.MinWidth = 25;
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Width = 96;
            // 
            // RebirthGridControl
            // 
            RebirthGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            RebirthGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.LevelTemplate = InfoGridView;
            gridLevelNode1.RelationName = "Benefits";
            RebirthGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            RebirthGridControl.Location = new System.Drawing.Point(0, 209);
            RebirthGridControl.MainView = RebirthGridView;
            RebirthGridControl.Margin = new System.Windows.Forms.Padding(4);
            RebirthGridControl.MenuManager = ribbon;
            RebirthGridControl.Name = "RebirthGridControl";
            RebirthGridControl.ShowOnlyPredefinedDetails = true;
            RebirthGridControl.Size = new System.Drawing.Size(2358, 463);
            RebirthGridControl.TabIndex = 2;
            RebirthGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { RebirthGridView, ItemGridView, InfoGridView });
            // 
            // RebirthGridView
            // 
            RebirthGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTitle, colOrder, colDescription });
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
            // colDescription
            // 
            colDescription.Caption = "Description";
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 2;
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
            // ItemGridView
            // 
            ItemGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn10, gridColumn11, gridColumn13 });
            ItemGridView.DetailHeight = 475;
            ItemGridView.GridControl = RebirthGridControl;
            ItemGridView.Name = "ItemGridView";
            ItemGridView.OptionsDetail.EnableMasterViewMode = false;
            ItemGridView.OptionsEditForm.PopupEditFormWidth = 1200;
            ItemGridView.OptionsView.EnableAppearanceEvenRow = true;
            ItemGridView.OptionsView.EnableAppearanceOddRow = true;
            ItemGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            ItemGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ItemGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            gridColumn10.Caption = "Title";
            gridColumn10.FieldName = "Title";
            gridColumn10.MinWidth = 25;
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 0;
            gridColumn10.Width = 96;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "Order";
            gridColumn11.FieldName = "Order";
            gridColumn11.MinWidth = 25;
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 1;
            gridColumn11.Width = 96;
            // 
            // gridColumn13
            // 
            gridColumn13.Caption = "Content";
            gridColumn13.ColumnEdit = ItemMemoEdit;
            gridColumn13.FieldName = "Content";
            gridColumn13.MinWidth = 25;
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 2;
            gridColumn13.Width = 96;
            // 
            // ItemMemoEdit
            // 
            ItemMemoEdit.AutoHeight = false;
            ItemMemoEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ItemMemoEdit.Name = "ItemMemoEdit";
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
            ((System.ComponentModel.ISupportInitialize)InfoGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)RebirthGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemMemoEdit).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView InfoGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit ItemMemoEdit;
    }
}