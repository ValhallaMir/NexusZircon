using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using C = Library.Network.ClientPackets;

namespace Client.Scenes.Views
{
    public sealed class RebirthDialog : DXWindow
    {
        #region Properties

        DXVScrollBar ScrollBar;


        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {

            if (IsVisible)
                BringToFront();

            if (Settings != null)
                Settings.Visible = nValue;

            base.OnIsVisibleChanged(oValue, nValue);
        }

        public override void OnLocationChanged(Point oValue, Point nValue)
        {
            base.OnLocationChanged(oValue, nValue);

            if (Settings != null && IsMoving)
                Settings.Location = nValue;
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (CloseButton.Visible)
                    {
                        CloseButton.InvokeMouseClick();
                        if (!Config.EscapeCloseAll)
                            e.Handled = true;
                    }
                    break;
            }
        }

        #endregion

        #region Settings

        public WindowSetting Settings;
        public override WindowType Type => WindowType.RebirthBox;

        public override bool CustomSize => false;
        public override bool AutomaticVisibility => true;

        public void LoadSettings()
        {
            if (Type == WindowType.None || !CEnvir.Loaded) return;

            Settings = CEnvir.WindowSettings.Binding.FirstOrDefault(x => x.Resolution == Config.GameSize && x.Window == Type);

            if (Settings != null)
            {
                ApplySettings();
                return;
            }

            Settings = CEnvir.WindowSettings.CreateNewObject();
            Settings.Resolution = Config.GameSize;
            Settings.Window = Type;
            Settings.Size = Size;
            Settings.Visible = Visible;
            Settings.Location = Location;
        }

        public void ApplySettings()
        {
            if (Settings == null) return;

            Location = Settings.Location;

            Visible = Settings.Visible;
        }


        #endregion

        public RebirthDialog()
        {
            Movable = true;
            Sort = true;
            DropShadow = true;

            TitleLabel.Text = "Rebirth System";

            SetClientSize(new Size(500, 500));

            #region Left Panel

            DXControl LeftPanel = new DXControl
            {
                Parent = this,
                Size = new Size(200, ClientArea.Height - 7),
                Location = new Point(ClientArea.Left, ClientArea.Top),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99)
            };

            DXLabel AvailableRBLabel = new DXLabel
            {
                Parent = LeftPanel,
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Available Rebirths",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            ScrollBar = new DXVScrollBar
            {
                Parent = LeftPanel,
                Location = new Point(LeftPanel.DisplayArea.Right - 30, 25),
                Size = new Size(14, LeftPanel.Size.Height - 30),
                VisibleSize = 10,
                Change = 1,
                MaxValue = Globals.RebirthLevels.Count,
                Visible = true
            };
            ScrollBar.ValueChanged += ScrollBar_ValueChanged;
            MouseWheel += ScrollBar.DoMouseWheel;

            #endregion Left Panel

            #region Right Panel

            DXControl RightPanel = new DXControl
            {
                Parent = this,
                Size = new Size(295, ClientArea.Height - 7),
                Location = new Point(LeftPanel.DisplayArea.Right + 5, ClientArea.Top),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99)
            };

            DXLabel RebirthDetailsLabel = new DXLabel
            {
                Parent = RightPanel,
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Rebirth Details",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            #endregion Right Panel
        }

        #region Methods

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion Methods

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (CloseButton != null)
                {
                    if (!CloseButton.IsDisposed)
                        CloseButton.Dispose();

                    CloseButton = null;
                }
            }
        }

        #endregion
    }
}