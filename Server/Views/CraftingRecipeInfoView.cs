using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Library;
using Library.SystemModels;
using System;

namespace Server.Views
{
    public partial class CraftingRecipeInfoView : RibbonForm
    {
        public CraftingRecipeInfoView()
        {
            InitializeComponent();
            CraftingRecipeGridControl.DataSource = SMain.Session.GetCollection<RecipeInfo>().Binding;
            ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            CurrencyLookUpEdit.DataSource = SMain.Session.GetCollection<CurrencyInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(CraftingRecipeGridView);
            SMain.SetUpView(RequiredItemsGridView);
            SMain.SetUpView(RequiredCurrenciesGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e) => SMain.Session.Save(true);

        private void ImportButton_ItemClick(object sender, ItemClickEventArgs e) => JsonImporter.Import<RecipeInfo>();

        private void ExportButton_ItemClick(object sender, ItemClickEventArgs e) => JsonExporter.Export<RecipeInfo>(CraftingRecipeGridView);
    }
}
