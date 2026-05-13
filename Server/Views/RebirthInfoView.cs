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

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            JsonImporter.Import<HelpInfo>();
        }

        private void ExportButton_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}