using Client.Controls;
using Client.Envir;
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

        private readonly List<RebirthRow> Rows = [];
        private DXControl LeftPanel;
        private DXVScrollBar ScrollBar;
        private const int VisibleRowCount = 8;
        private RebirthRow SelectedRow;
        private DXLabel RebirthTitleLabel;
        private DXLabel RebirthDescriptionLabel;
        private DXLabel RequirementsLabel;
        private DXLabel RewardsLabel;
        private DXLabel BenefitsLabel;
        private DXLabel RequiredLevelLabel;
        private DXLabel DowngradeLevelLabel;
        private readonly List<DXLabel> BenefitValueLabels = [];
        private DXControl RewardsGridPanel;
        private readonly List<DXItemCell> RewardCells = [];

        private DXButton RebirthNowButton;

        public WindowSetting Settings;
        public override WindowType Type => WindowType.RebirthBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisibility => false;

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            if (IsVisible)
            {
                BringToFront();
                UpdateUI();
            }

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

            if (e.KeyCode == Keys.Escape && CloseButton.Visible)
            {
                CloseButton.InvokeMouseClick();
                if (!Config.EscapeCloseAll)
                    e.Handled = true;
            }
        }

        #endregion Properties

        public RebirthDialog()
        {
            Movable = true;
            Sort = true;
            DropShadow = true;

            TitleLabel.Text = "Rebirth System";
            SetClientSize(new Size(500, 500));

            LeftPanel = new DXControl
            {
                Parent = this,
                Size = new Size(200, ClientArea.Height - 7),
                Location = new Point(ClientArea.Left, ClientArea.Top),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99)
            };

            new DXLabel
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
                Location = new Point(LeftPanel.DisplayArea.Right - 30, 35),
                Size = new Size(14, LeftPanel.Size.Height - 43),
                VisibleSize = VisibleRowCount,
                Change = 1,
                Visible = true
            };
            ScrollBar.ValueChanged += (o, e) => RefreshRows();
            MouseWheel += ScrollBar.DoMouseWheel;

            DXControl rightPanel = new DXControl
            {
                Parent = this,
                Size = new Size(295, ClientArea.Height - 7),
                Location = new Point(LeftPanel.DisplayArea.Right + 5, ClientArea.Top),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99)
            };

            new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Rebirth Details",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            RebirthTitleLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 40),
                Text = "Select a rebirth",
                ForeColour = Color.White,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
            };

            RebirthDescriptionLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = false,
                Location = new Point(10, 58),
                Size = new Size(rightPanel.Size.Width - 20, 35),
                Text = string.Empty,
                ForeColour = Color.WhiteSmoke,
            };

            RequirementsLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 95),
                Text = "Requirements:",
                ForeColour = Color.WhiteSmoke,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
            };

            RequiredLevelLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(20, 115),
                Text = "Required Level:",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            DowngradeLevelLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(20, 130),
                Text = "Reset to Level:",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            BenefitsLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 170),
                Text = "Rebirth Benefits:",
                ForeColour = Color.WhiteSmoke,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
            };

            RewardsLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 280),
                Text = "Rewards:",
                ForeColour = Color.WhiteSmoke,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
            };

            RewardsGridPanel = new DXControl
            {
                Parent = rightPanel,
                Location = new Point(15, 302),
                Size = new Size(DXItemCell.CellWidth * 5 + 8 * 4, DXItemCell.CellHeight * 3 + 8 * 2),
            };

            RebirthNowButton = new DXButton
            {
                Size = new Size(285, SmallButtonHeight),
                Parent = rightPanel,
                Label = { Text = "Rebirth Now", },
                GrayScale = true,
                Enabled = false,
                Location = new Point(5, 475),
                ButtonType = ButtonType.SmallButton
            };
            RebirthNowButton.MouseClick += (o, e) =>
            {
                if (SelectedRow.Rebirth.Order < GameScene.Game.User.Rebirth)
                {
                    GameScene.Game.ReceiveChat("You have already completed this rebirth.", MessageType.System);
                    return;
                }
                else if (SelectedRow.Rebirth.RequiredLevel > GameScene.Game.User.Level)
                {
                    GameScene.Game.ReceiveChat($"You need to be level {SelectedRow.Rebirth.RequiredLevel} to rebirth.", MessageType.System);
                    return;
                }
                else if (SelectedRow.Rebirth.Order > GameScene.Game.User.Rebirth)
                {
                    GameScene.Game.ReceiveChat("You must complete previous rebirths before attempting this one.", MessageType.System);
                    return;
                }

                CEnvir.Enqueue (new C.RebirthRequest
                {
                    RebirthIndex = SelectedRow.Rebirth.Order
                });

                RefreshRows();
            };

            RefreshRows();
        }

        public void UpdateUI()
        {
            RefreshRows();
        }

        private void RefreshRows()
        {
            RebirthInfo selectedRebirth = SelectedRow?.Rebirth;
            int currentRebirth = GameScene.Game?.User?.Rebirth ?? 0;

            foreach (RebirthRow row in Rows)
                row.Dispose();

            Rows.Clear();

            var rebirths = Globals.RebirthInfoList?.Binding?.ToList() ?? [];

            ScrollBar.MaxValue = Math.Max(0, rebirths.Count);
            ScrollBar.Value = Math.Min(ScrollBar.Value, Math.Max(0, ScrollBar.MaxValue - ScrollBar.VisibleSize));

            foreach (var rebirth in rebirths.Skip(ScrollBar.Value).Take(VisibleRowCount))
            {
                RebirthRow row = new RebirthRow
                {
                    Parent = LeftPanel,
                    Rebirth = rebirth,
                };
                row.UpdateText(currentRebirth);
                row.MouseClick += Row_MouseClick;
                row.MouseWheel += ScrollBar.DoMouseWheel;
                Rows.Add(row);
            }

            SelectedRow = null;

            if (selectedRebirth != null)
                SelectedRow = Rows.FirstOrDefault(x => x.Rebirth == selectedRebirth);

            if (SelectedRow == null && Rows.Count > 0)
                SelectedRow = Rows[0];

            if (SelectedRow != null)
                SelectedRow.Selected = true;

            UpdateRowLocations();
            UpdateSelection();
        }

        private void Row_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelectedRow((RebirthRow)sender);
        }

        private void SetSelectedRow(RebirthRow row)
        {
            if (SelectedRow == row) return;

            if (SelectedRow != null)
                SelectedRow.Selected = false;

            SelectedRow = row;

            if (SelectedRow != null)
                SelectedRow.Selected = true;

            UpdateSelection();
        }

        private void UpdateRowLocations()
        {
            int y = 35;

            foreach (RebirthRow row in Rows)
            {
                row.Location = new Point(7, y);
                row.Visible = row.Location.Y + row.Size.Height > 25 && row.Location.Y < LeftPanel.Size.Height;
                y += RebirthRow.RowHeight + 8;
            }
        }

        private void UpdateSelection()
        {
            var rebirth = SelectedRow?.Rebirth;

            if (rebirth == null)
            {
                RebirthTitleLabel.Text = "Select a rebirth";
                RequirementsLabel.Text = "Requirements:";
                RewardsLabel.Text = "Rewards:";
                BenefitsLabel.Text = "Benefits:";
                ClearRewardCells();
                RebirthNowButton.Enabled = false;
                RebirthNowButton.GrayScale = true;
                return;
            }

            RebirthTitleLabel.Text = rebirth.Title;
            RebirthDescriptionLabel.Text = rebirth.Description ?? string.Empty;
            RequiredLevelLabel.Text = $"Required Level: {rebirth.RequiredLevel}";
            DowngradeLevelLabel.Text = $"Reset to Level: {rebirth.ResetToLevel}";

            foreach (DXLabel label in BenefitValueLabels)
                label.Dispose();

            BenefitValueLabels.Clear();

            BenefitsLabel.Text = "Rebirth Benefits:";

            int benefitY = BenefitsLabel.Location.Y + 22;

            if (rebirth.Benefits.Count == 0)
            {
                DXLabel label = new DXLabel
                {
                    Parent = BenefitsLabel.Parent,
                    AutoSize = true,
                    Location = new Point(20, benefitY),
                    Text = "None",
                    ForeColour = Color.Gray,
                };

                BenefitValueLabels.Add(label);
            }
            else
            {
                Color[] benefitColours =
                {
                    Color.LimeGreen,
                    Color.Gold,
                    Color.Orange,
                    Color.DeepSkyBlue,
                    Color.Orchid,
                    Color.Tomato,
                };

                for (int i = 0; i < rebirth.Benefits.Count; i++)
                {
                    var benefit = rebirth.Benefits[i];

                    DXLabel label = new DXLabel
                    {
                        Parent = BenefitsLabel.Parent,
                        AutoSize = true,
                        Location = new Point(20, benefitY + i * 16),
                        Text = $"{benefit.StatName} +{benefit.Rate:0.##}%",
                        ForeColour = benefitColours[i % benefitColours.Length],
                        Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                    };

                    BenefitValueLabels.Add(label);
                }
            }

            RewardsLabel.Text = "Rewards:";

            int currentRebirth = GameScene.Game?.User?.Rebirth ?? 0;
            UpdateRewardCells(rebirth, rebirth.Order < currentRebirth);

            RebirthNowButton.Enabled = true;
            RebirthNowButton.GrayScale = false;

            if (rebirth.Order > currentRebirth || rebirth.RequiredLevel > GameScene.Game?.User?.Level || rebirth.Order < currentRebirth)
            {
                RebirthNowButton.Enabled = false;
                RebirthNowButton.GrayScale = true;
            }
        }

        private void ClearRewardCells()
        {
            foreach (DXItemCell cell in RewardCells)
            {
                if (cell != null && !cell.IsDisposed)
                    cell.Dispose();
            }

            RewardCells.Clear();
        }

        private void UpdateRewardCells(RebirthInfo rebirth, bool grayScale)
        {
            ClearRewardCells();

            if (rebirth?.Rewards == null || rebirth.Rewards.Count == 0)
                return;

            int count = Math.Min(15, rebirth.Rewards.Count);

            for (int i = 0; i < count; i++)
            {
                int column = i % 5;
                int row = i / 5;
                var reward = rebirth.Rewards[i];

                DXItemCell cell = new DXItemCell
                {
                    Parent = RewardsGridPanel,
                    Location = new Point(column * (DXItemCell.CellWidth + 8), row * (DXItemCell.CellHeight + 8)),
                    Size = new Size(DXItemCell.CellWidth, DXItemCell.CellHeight),
                    Border = true,
                    FixedBorder = true,
                    FixedBorderColour = true,
                    BorderColour = Color.FromArgb(198, 166, 99),
                    GridType = GridType.None,
                    ItemGrid = new ClientUserItem[1],
                    Slot = 0,
                    ReadOnly = true,
                    GrayScale = grayScale,
                    Opacity = grayScale ? 0.2F : 1F,
                };

                if (reward.ItemName != null)
                    cell.ItemGrid[0] = new ClientUserItem(reward.ItemName, reward.Count);

                RewardCells.Add(cell);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                base.Dispose(disposing);
                return;
            }

            // Rows
            foreach (var row in Rows)
            {
                if (row != null && !row.IsDisposed)
                    row.Dispose();
            }
            Rows.Clear();

            // Benefit labels
            foreach (var label in BenefitValueLabels)
            {
                if (label != null && !label.IsDisposed)
                    label.Dispose();
            }
            BenefitValueLabels.Clear();

            ClearRewardCells();

            // Controls
            if (ScrollBar != null)
            {
                if (!ScrollBar.IsDisposed)
                    ScrollBar.Dispose();
                ScrollBar = null;
            }

            if (LeftPanel != null)
            {
                if (!LeftPanel.IsDisposed)
                    LeftPanel.Dispose();
                LeftPanel = null;
            }

            if (RebirthTitleLabel != null)
            {
                if (!RebirthTitleLabel.IsDisposed)
                    RebirthTitleLabel.Dispose();
                RebirthTitleLabel = null;
            }

            if (RebirthDescriptionLabel != null)
            {
                if (!RebirthDescriptionLabel.IsDisposed)
                    RebirthDescriptionLabel.Dispose();
                RebirthDescriptionLabel = null;
            }

            if (RequirementsLabel != null)
            {
                if (!RequirementsLabel.IsDisposed)
                    RequirementsLabel.Dispose();
                RequirementsLabel = null;
            }

            if (RewardsLabel != null)
            {
                if (!RewardsLabel.IsDisposed)
                    RewardsLabel.Dispose();
                RewardsLabel = null;
            }

            if (BenefitsLabel != null)
            {
                if (!BenefitsLabel.IsDisposed)
                    BenefitsLabel.Dispose();
                BenefitsLabel = null;
            }

            if (RequiredLevelLabel != null)
            {
                if (!RequiredLevelLabel.IsDisposed)
                    RequiredLevelLabel.Dispose();
                RequiredLevelLabel = null;
            }

            if (DowngradeLevelLabel != null)
            {
                if (!DowngradeLevelLabel.IsDisposed)
                    DowngradeLevelLabel.Dispose();
                DowngradeLevelLabel = null;
            }

            if (RewardsGridPanel != null)
            {
                if (!RewardsGridPanel.IsDisposed)
                    RewardsGridPanel.Dispose();
                RewardsGridPanel = null;
            }

            if (RebirthNowButton != null)
            {
                if (!RebirthNowButton.IsDisposed)
                    RebirthNowButton.Dispose();
                RebirthNowButton = null;
            }

            SelectedRow = null;

            base.Dispose(disposing);
        }

        private sealed class RebirthRow : DXControl
        {
            public const int RowHeight = 50;

            public RebirthInfo Rebirth
            {
                get => _Rebirth;
                set
                {
                    if (_Rebirth == value) return;
                    _Rebirth = value;
                }
            }
            private RebirthInfo _Rebirth;

            public bool Selected
            {
                get => _Selected;
                set
                {
                    if (_Selected == value) return;
                    _Selected = value;
                    BackColour = _Selected ? Color.FromArgb(40, 255, 220, 0) : Color.Empty;
                }
            }
            private bool _Selected;

            private readonly DXLabel TitleLabel;
            private readonly DXLabel SubtitleLabel;

            public RebirthRow()
            {
                Size = new Size(165, RowHeight);
                DrawTexture = true;
                Border = true;
                BorderColour = Color.FromArgb(198, 166, 99);
                BackColour = Color.Empty;

                TitleLabel = new DXLabel
                {
                    Parent = this,
                    AutoSize = true,
                    Location = new Point(8, 8),
                    ForeColour = Color.LimeGreen,
                    Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                    IsControl = false,
                };

                SubtitleLabel = new DXLabel
                {
                    Parent = this,
                    AutoSize = true,
                    Location = new Point(8, 20),
                    ForeColour = Color.WhiteSmoke,
                    Font = new Font(Config.FontName, CEnvir.FontSize(7F)),
                    IsControl = false,
                };
            }

            public void UpdateText(int currentRebirth)
            {
                if (Rebirth == null)
                {
                    TitleLabel.Text = string.Empty;
                    SubtitleLabel.Text = string.Empty;
                    return;
                }

                TitleLabel.Text = Rebirth.Title;

                if (Rebirth.Order < currentRebirth)
                {
                    TitleLabel.ForeColour = Color.Lime;
                    SubtitleLabel.ForeColour = Color.Gray;
                    SubtitleLabel.Text = "Completed";
                    return;
                }

                if (Rebirth.Order == currentRebirth)
                {
                    TitleLabel.ForeColour = Color.Lime;
                    SubtitleLabel.ForeColour = Color.Gray;
                }
                else
                {
                    TitleLabel.ForeColour = Color.Gray;
                    SubtitleLabel.ForeColour = Color.Gray;
                }

                SubtitleLabel.Text = $"Requires Level {Rebirth.RequiredLevel}";
            }
        }
    }
}
