using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class ConfigForm : DevExpress.XtraEditors.XtraForm
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void CleanFiles_pb_Click(object sender, EventArgs e)
        {
            Program.PForm.CheckPatch(true);
        }

        private void CleanFiles_pb_MouseDown(object sender, MouseEventArgs e)
        {
            CleanFiles_pb.Image = Properties.Resources.CheckF_Pressed;
        }

        private void CleanFiles_pb_MouseEnter(object sender, EventArgs e)
        {
            CleanFiles_pb.Image = Properties.Resources.CheckF_Hover;
        }

        private void CleanFiles_pb_MouseLeave(object sender, EventArgs e)
        {
            CleanFiles_pb.Image = Properties.Resources.CheckF_Base2;
        }

        private void CleanFiles_pb_MouseUp(object sender, MouseEventArgs e)
        {
            CleanFiles_pb.Image = Properties.Resources.CheckF_Hover;
        }

        private void DebugCheckBox_Click(object sender, EventArgs e)
        {
            if (!Config.DebugMode)
            {
                DebugCheckBox.Image = Properties.Resources.Config_Check_On;
                Config.DebugMode = true;

                Program.PForm.Main_browser.SendToBack();
                Program.PForm.OutputTextBox.BringToFront();
            }
            else
            {
                DebugCheckBox.Image = Properties.Resources.Config_Check_Off1;
                Config.DebugMode = false;

                Program.PForm.OutputTextBox.SendToBack();
                Program.PForm.Main_browser.BringToFront();
                Program.PForm.Main_browser.Focus();
            }

            ConfigReader.Save();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            if (Config.DebugMode)
            {
                DebugCheckBox.Image = Properties.Resources.Config_Check_On;
            }
            else
            {
                DebugCheckBox.Image = Properties.Resources.Config_Check_Off1;
            }
        }
    }
}