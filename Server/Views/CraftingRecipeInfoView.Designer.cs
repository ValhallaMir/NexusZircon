namespace Server.Views
{
    partial class CraftingRecipeInfoView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CraftingRecipeInfoView));
            RequiredItemsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRequiredItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemInfoLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colRequiredItemCount = new DevExpress.XtraGrid.Columns.GridColumn();
            CraftingRecipeGridControl = new DevExpress.XtraGrid.GridControl();
            RequiredCurrenciesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRequiredCurrencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            CurrencyLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colRequiredCurrencyCount = new DevExpress.XtraGrid.Columns.GridColumn();
            CraftingRecipeGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            colMainItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colChance = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ImportButton = new DevExpress.XtraBars.BarButtonItem();
            ExportButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            JsonGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)RequiredItemsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemInfoLookUpEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CraftingRecipeGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RequiredCurrenciesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrencyLookUpEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CraftingRecipeGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // RequiredItemsGridView
            // 
            RequiredItemsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRequiredItemName, colRequiredItemCount });
            RequiredItemsGridView.DetailHeight = 361;
            RequiredItemsGridView.GridControl = CraftingRecipeGridControl;
            RequiredItemsGridView.Name = "RequiredItemsGridView";
            RequiredItemsGridView.OptionsEditForm.PopupEditFormWidth = 1080;
            RequiredItemsGridView.OptionsView.EnableAppearanceEvenRow = true;
            RequiredItemsGridView.OptionsView.EnableAppearanceOddRow = true;
            RequiredItemsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            RequiredItemsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            RequiredItemsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colRequiredItemName
            // 
            colRequiredItemName.Caption = "Item Name";
            colRequiredItemName.ColumnEdit = ItemInfoLookUpEdit;
            colRequiredItemName.FieldName = "ItemName";
            colRequiredItemName.MinWidth = 22;
            colRequiredItemName.Name = "colRequiredItemName";
            colRequiredItemName.Visible = true;
            colRequiredItemName.VisibleIndex = 0;
            colRequiredItemName.Width = 144;
            // 
            // ItemInfoLookUpEdit
            // 
            ItemInfoLookUpEdit.AutoHeight = false;
            ItemInfoLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ItemInfoLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ItemInfoLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            ItemInfoLookUpEdit.DisplayMember = "ItemName";
            ItemInfoLookUpEdit.Name = "ItemInfoLookUpEdit";
            ItemInfoLookUpEdit.NullText = "[Item is null]";
            ItemInfoLookUpEdit.UseCtrlScroll = false;
            // 
            // colRequiredItemCount
            // 
            colRequiredItemCount.Caption = "Count";
            colRequiredItemCount.FieldName = "Count";
            colRequiredItemCount.MinWidth = 22;
            colRequiredItemCount.Name = "colRequiredItemCount";
            colRequiredItemCount.Visible = true;
            colRequiredItemCount.VisibleIndex = 1;
            colRequiredItemCount.Width = 86;
            // 
            // CraftingRecipeGridControl
            // 
            CraftingRecipeGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            CraftingRecipeGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridLevelNode1.LevelTemplate = RequiredItemsGridView;
            gridLevelNode1.RelationName = "RequiredItems";
            gridLevelNode2.LevelTemplate = RequiredCurrenciesGridView;
            gridLevelNode2.RelationName = "RequiredCurrencies";
            CraftingRecipeGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1, gridLevelNode2 });
            CraftingRecipeGridControl.Location = new System.Drawing.Point(0, 209);
            CraftingRecipeGridControl.MainView = CraftingRecipeGridView;
            CraftingRecipeGridControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CraftingRecipeGridControl.MenuManager = ribbon;
            CraftingRecipeGridControl.Name = "CraftingRecipeGridControl";
            CraftingRecipeGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ItemInfoLookUpEdit, CurrencyLookUpEdit });
            CraftingRecipeGridControl.ShowOnlyPredefinedDetails = true;
            CraftingRecipeGridControl.Size = new System.Drawing.Size(2210, 642);
            CraftingRecipeGridControl.TabIndex = 2;
            CraftingRecipeGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { RequiredCurrenciesGridView, CraftingRecipeGridView, RequiredItemsGridView });
            // 
            // RequiredCurrenciesGridView
            // 
            RequiredCurrenciesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRequiredCurrencyName, colRequiredCurrencyCount });
            RequiredCurrenciesGridView.DetailHeight = 361;
            RequiredCurrenciesGridView.GridControl = CraftingRecipeGridControl;
            RequiredCurrenciesGridView.Name = "RequiredCurrenciesGridView";
            RequiredCurrenciesGridView.OptionsEditForm.PopupEditFormWidth = 1080;
            RequiredCurrenciesGridView.OptionsView.EnableAppearanceEvenRow = true;
            RequiredCurrenciesGridView.OptionsView.EnableAppearanceOddRow = true;
            RequiredCurrenciesGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            RequiredCurrenciesGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            RequiredCurrenciesGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colRequiredCurrencyName
            // 
            colRequiredCurrencyName.Caption = "Currency Name";
            colRequiredCurrencyName.ColumnEdit = CurrencyLookUpEdit;
            colRequiredCurrencyName.FieldName = "CurrencyName";
            colRequiredCurrencyName.MinWidth = 22;
            colRequiredCurrencyName.Name = "colRequiredCurrencyName";
            colRequiredCurrencyName.Visible = true;
            colRequiredCurrencyName.VisibleIndex = 0;
            colRequiredCurrencyName.Width = 144;
            // 
            // CurrencyLookUpEdit
            // 
            CurrencyLookUpEdit.AutoHeight = false;
            CurrencyLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            CurrencyLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            CurrencyLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Abbreviation", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Type", "Type", 18, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            CurrencyLookUpEdit.DisplayMember = "Name";
            CurrencyLookUpEdit.Name = "CurrencyLookUpEdit";
            CurrencyLookUpEdit.NullText = "[Currency is null]";
            CurrencyLookUpEdit.UseCtrlScroll = false;
            // 
            // colRequiredCurrencyCount
            // 
            colRequiredCurrencyCount.Caption = "Count";
            colRequiredCurrencyCount.FieldName = "Count";
            colRequiredCurrencyCount.MinWidth = 22;
            colRequiredCurrencyCount.Name = "colRequiredCurrencyCount";
            colRequiredCurrencyCount.Visible = true;
            colRequiredCurrencyCount.VisibleIndex = 1;
            colRequiredCurrencyCount.Width = 86;
            // 
            // CraftingRecipeGridView
            // 
            CraftingRecipeGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIndex, colMainItem, colChance });
            CraftingRecipeGridView.DetailHeight = 361;
            CraftingRecipeGridView.GridControl = CraftingRecipeGridControl;
            CraftingRecipeGridView.Name = "CraftingRecipeGridView";
            CraftingRecipeGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            CraftingRecipeGridView.OptionsEditForm.PopupEditFormWidth = 1080;
            CraftingRecipeGridView.OptionsView.EnableAppearanceEvenRow = true;
            CraftingRecipeGridView.OptionsView.EnableAppearanceOddRow = true;
            CraftingRecipeGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            CraftingRecipeGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            CraftingRecipeGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colIndex
            // 
            colIndex.Caption = "Index";
            colIndex.FieldName = "Index";
            colIndex.MinWidth = 22;
            colIndex.Name = "colIndex";
            colIndex.Visible = true;
            colIndex.VisibleIndex = 0;
            colIndex.Width = 86;
            // 
            // colMainItem
            // 
            colMainItem.Caption = "Main Item";
            colMainItem.ColumnEdit = ItemInfoLookUpEdit;
            colMainItem.FieldName = "MainItem";
            colMainItem.MinWidth = 22;
            colMainItem.Name = "colMainItem";
            colMainItem.Visible = true;
            colMainItem.VisibleIndex = 1;
            colMainItem.Width = 144;
            // 
            // colChance
            // 
            colChance.Caption = "Chance";
            colChance.FieldName = "Chance";
            colChance.MinWidth = 22;
            colChance.Name = "colChance";
            colChance.Visible = true;
            colChance.VisibleIndex = 2;
            colChance.Width = 86;
            // 
            // ribbon
            // 
            ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 31, 35, 31);
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, SaveButton, ImportButton, ExportButton });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ribbon.MaxItemId = 5;
            ribbon.Name = "ribbon";
            ribbon.OptionsMenuMinWidth = 382;
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new System.Drawing.Size(2210, 209);
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
            // CraftingRecipeInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2210, 851);
            Controls.Add(CraftingRecipeGridControl);
            Controls.Add(ribbon);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "CraftingRecipeInfoView";
            Ribbon = ribbon;
            Text = "Crafting Recipes";
            ((System.ComponentModel.ISupportInitialize)RequiredItemsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemInfoLookUpEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)CraftingRecipeGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)RequiredCurrenciesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrencyLookUpEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)CraftingRecipeGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraBars.BarButtonItem ImportButton;
        private DevExpress.XtraBars.BarButtonItem ExportButton;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup JsonGroup;
        private DevExpress.XtraGrid.GridControl CraftingRecipeGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView CraftingRecipeGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView RequiredItemsGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView RequiredCurrenciesGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemInfoLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit CurrencyLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMainItem;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredItemCount;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredCurrencyName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredCurrencyCount;
        private DevExpress.XtraGrid.Columns.GridColumn colChance;
    }
}
