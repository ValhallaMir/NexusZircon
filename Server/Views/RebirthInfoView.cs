using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Library;
using Library.SystemModels;
using System;

namespace Server.Views
{
    public partial class RebirthInfoView : RibbonForm
    {
        public RebirthInfoView()
        {
            InitializeComponent();
            RebirthGridControl.DataSource = SMain.Session.GetCollection<RebirthInfo>().Binding;
            ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            StatImageComboBox.Items.AddEnum<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(RebirthGridView);
            SMain.SetUpView(BenefitsGridView);
            SMain.SetUpView(RewardsGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            JsonImporter.Import<RebirthInfo>();
        }

        private void ExportButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            JsonExporter.Export<RebirthInfo>(RebirthGridView);
        }
    }
}
