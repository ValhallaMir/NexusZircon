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
    public sealed class InventoryDialog : DXWindow
    {
        #region Properties

        public DXItemGrid Grid;

        public DXLabel PrimaryCurrencyLabel, SecondaryCurrencyLabel, PrimaryCurrencyTitle, SecondaryCurrencyTitle;
        public DXButton CloseButton, SortButton, TrashButton, SellButton;
        public DXVScrollBar InventoryScrollBar;

        public List<DXItemCell> SelectedItems = new();

        public List<ItemType> SellableItemTypes = new();

        #region PrimaryCurrency

        public CurrencyInfo PrimaryCurrency
        {
            get => _PrimaryCurrency;
            set
            {
                if (_PrimaryCurrency == value) return;

                CurrencyInfo oldValue = _PrimaryCurrency;
                _PrimaryCurrency = value;

                OnPrimaryCurrencyChanged(oldValue, value);
            }
        }
        private CurrencyInfo _PrimaryCurrency;

        public event EventHandler<EventArgs> PrimaryCurrencyChanged;
        public void OnPrimaryCurrencyChanged(CurrencyInfo oValue, CurrencyInfo nValue)
        {
            if (GameScene.Game.User == null)
                return;

            foreach (DXItemCell cell in Grid.Grid)
                cell.Selected = false;

            RefreshPrimaryCurrency();

            PrimaryCurrencyChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region SecondaryCurrency

        public CurrencyInfo SecondaryCurrency
        {
            get => _SecondaryCurrency;
            set
            {
                if (_SecondaryCurrency == value) return;

                CurrencyInfo oldValue = _SecondaryCurrency;
                _SecondaryCurrency = value;

                OnPrimaryCurrencyChanged(oldValue, value);
            }
        }
        private CurrencyInfo _SecondaryCurrency;

        public event EventHandler<EventArgs> SecondaryCurrencyChanged;
        public void OnSecondaryCurrencyChanged(CurrencyInfo oValue, CurrencyInfo nValue)
        {
            if (GameScene.Game.User == null)
                return;

            foreach (DXItemCell cell in Grid.Grid)
                cell.Selected = false;

            RefreshSecondaryCurrency();

            SecondaryCurrencyChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            if (!IsVisible)
                Grid.ClearLinks();

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
        public override WindowType Type => WindowType.InventoryBox;

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

        public InventoryDialog()
        {
            Movable = true;
            Sort = true;
            DropShadow = true;

            TitleLabel.Text = "Inventory";

            Grid = new DXItemGrid
            {
                GridSize = new Size(10, 20),
                VisibleHeight = 10,
                Parent = this,
                ItemGrid = GameScene.Game.Inventory,
                GridType = GridType.Inventory,
            };
            Grid.GridSizeChanged += Grid_GridSizeChanged;

            foreach (DXItemCell cell in Grid.Grid)
            {
                cell.SelectedChanged += Cell_SelectedChanged;
            }

            SetClientSize(new Size(Grid.Size.Width + 20, Grid.Size.Height + 45));
            Grid.Location = ClientArea.Location;

            CloseButton = new DXButton
            {
                Parent = this,
                Index = 15,
                LibraryFile = LibraryFile.Interface,
                Hint = CEnvir.Language.CommonControlClose,
                HintPosition = HintPosition.TopLeft
            };
            CloseButton.Location = new Point(DisplayArea.Width - CloseButton.Size.Width - 3, 3);
            CloseButton.MouseClick += (o, e) => Visible = false;

            PrimaryCurrencyTitle = new DXLabel
            {
                AutoSize = false,
                ForeColour = Color.Goldenrod,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Parent = this,
                Location = new Point(ClientArea.Left + 1, ClientArea.Bottom - 46),
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                Text = CEnvir.Language.InventoryDialogPrimaryCurrencyTitle,
                Size = new Size(69, 20),
                Border = true,
                BorderColour = Color.FromArgb(99, 83, 50),
            };

            PrimaryCurrencyLabel = new DXLabel
            {
                AutoSize = false,
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.VerticalCenter,
                Parent = this,
                Location = new Point(ClientArea.Left + 71, ClientArea.Bottom - 46),
                Text = "0",
                Size = new Size(ClientArea.Width - 162, 20),
                Border = true,
                BorderColour = Color.FromArgb(99, 83, 50),
            };
            PrimaryCurrencyLabel.MouseClick += PrimaryCurrencyLabel_MouseClick;

            SecondaryCurrencyTitle = new DXLabel
            {
                AutoSize = false,
                ForeColour = Color.DarkOrange,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Parent = this,
                Location = new Point(ClientArea.Left + 1, ClientArea.Bottom - 25),
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                Text = CEnvir.Language.InventoryDialogSecondaryCurrencyTitle,
                Size = new Size(69, 20),
                Border = true,
                BorderColour = Color.FromArgb(99, 83, 50),
            };

            SecondaryCurrencyLabel = new DXLabel
            {
                AutoSize = false,
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.VerticalCenter,
                Parent = this,
                Location = new Point(ClientArea.Left + 71, ClientArea.Bottom - 25),
                Text = "0",
                Size = new Size(ClientArea.Width - 162, 20),
                Border = true,
                BorderColour = Color.FromArgb(99, 83, 50),
            };
            SecondaryCurrencyLabel.MouseClick += SecondaryCurrencyLabel_MouseClick;

            SortButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 364,
                Parent = this,
                Location = new Point(308, 397),
                Hint = CEnvir.Language.InventoryDialogSortButtonHint,
            };
            SortButton.MouseClick += SortButton_MouseClick;

            TrashButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 358,
                Parent = this,
                Location = new Point(345, 397),
                Hint = CEnvir.Language.InventoryDialogTrashButtonHint,
            };
            TrashButton.MouseClick += TrashButton_MouseClick;

            SellButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 354,
                Parent = this,
                Location = new Point(345, 397),
                Hint = "Sell All",
                Enabled = true,
                Visible = false,
            };
            SellButton.MouseClick += SellButton_MouseClick;

            InventoryScrollBar = new DXVScrollBar
            {
                Parent = this,
                Location = new Point(ClientArea.Right - 15, Grid.Location.Y + 2),
                Size = new Size(14, Grid.Size.Height - 4),
                VisibleSize = 10,
                Change = 1,
                MaxValue = Grid.GridSize.Height,
                Visible = true
            };
            InventoryScrollBar.ValueChanged += InventoryScrollBar_ValueChanged;
            InventoryScrollBar.MaxValue = Grid.GridSize.Height;

            foreach (DXItemCell cell in Grid.Grid)
                cell.MouseWheel += InventoryScrollBar.DoMouseWheel;

            Grid.MouseWheel += InventoryScrollBar.DoMouseWheel;
            MouseWheel += InventoryScrollBar.DoMouseWheel;
        }

        private void InventoryScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Grid.ScrollValue = InventoryScrollBar.Value;
        }

        private void Grid_GridSizeChanged(object sender, EventArgs e)
        {
            if (InventoryScrollBar == null) return;

            InventoryScrollBar.MaxValue = Grid.GridSize.Height;
            InventoryScrollBar.VisibleSize = Grid.VisibleHeight;
            InventoryScrollBar.Visible = Grid.GridSize.Height > Grid.VisibleHeight;

            foreach (DXItemCell cell in Grid.Grid)
                cell.MouseWheel += InventoryScrollBar.DoMouseWheel;
        }

        private void SortButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.Observer) return;

            C.ItemSort packet = new C.ItemSort { Grid = GridType.Inventory };
            CEnvir.Enqueue(packet);
        }

        private void TrashButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.Observer) return;

            var cell = DXItemCell.SelectedCell;

            if (cell == null || cell.Item == null) return;
            if ((cell.Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return;
            if ((cell.Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound) return;
            if ((cell.Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return;

            if (cell.GridType != GridType.Inventory) return;

            cell.Locked = true;

            C.ItemDelete packet = new C.ItemDelete { Grid = cell.GridType, Slot = cell.Slot };

            CEnvir.Enqueue(packet);
        }

        private void Cell_SelectedChanged(object sender, EventArgs e)
        {
            var cell = sender as DXItemCell;

            if (InvMode == InventoryMode.Sell)
            {
                if (cell.Selected)
                {
                    if (cell.Item != null && (cell.Item.Flags & UserItemFlags.Locked) != UserItemFlags.Locked)
                    {
                        if (!SellableItemTypes.Contains(cell.Item.Info.ItemType))
                        {
                            GameScene.Game.ReceiveChat(string.Format(CEnvir.Language.UnableToSellHere, cell.Item.Info.ItemName), MessageType.System);
                            cell.Selected = false;
                            return;
                        }

                        SelectedItems.Add(cell);
                    }
                }
                else
                    SelectedItems.Remove(cell);

                long sum = 0;
                int count = 0;
                foreach (DXItemCell itemCell in SelectedItems)
                {
                    count++;
                    sum += (long)(itemCell.Item.Price(itemCell.Item.Count) * PrimaryCurrency.ExchangeRate);
                }

                SecondaryCurrencyLabel.Text = sum.ToString("#,##0");

                SellButton.Enabled = true;
                SellButton.Hint = count == 1 ? "Sell" : "Sell All";
            }
        }

        private void SellButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.Observer) return;

            var cell = DXItemCell.SelectedCell;

            if (cell != null && cell.Item != null && (cell.Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return;

            List<CellLinkInfo> links = new();

            if (SelectedItems.Count > 0)
            {
                foreach (DXItemCell itemCell in SelectedItems)
                {
                    if ((itemCell.Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) continue;

                    links.Add(new CellLinkInfo { Count = itemCell.Item.Count, GridType = GridType.Inventory, Slot = itemCell.Slot });
                }
            }
            else
            {
                //Sell all
                foreach (DXItemCell itemCell in Grid.Grid)
                {
                    if (itemCell.Item == null) continue;
                    if ((itemCell.Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) continue;

                    if (SellableItemTypes.Count > 0 && !SellableItemTypes.Contains(itemCell.Item.Info.ItemType)) continue;

                    links.Add(new CellLinkInfo { Count = itemCell.Item.Count, GridType = GridType.Inventory, Slot = itemCell.Slot });
                }
            }

            if (links.Count > 0)
            {
                CEnvir.Enqueue(new C.NPCSell { Links = links });
            }
        }

        private void PrimaryCurrencyLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.SelectedCell == null)
            {
                var userCurrency = GameScene.Game.User.GetCurrency(PrimaryCurrency);

                if (!userCurrency.CanPickup) return;
                DXSoundManager.Play(SoundIndex.GoldPickUp);

                if (GameScene.Game.CurrencyPickedUp == null && userCurrency.Amount > 0)
                    GameScene.Game.CurrencyPickedUp = userCurrency;
                else
                    GameScene.Game.CurrencyPickedUp = null;
            }
        }

        private void SecondaryCurrencyLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.SelectedCell == null)
            {
                var userCurrency = GameScene.Game.User.GetCurrency(SecondaryCurrency);

                if (!userCurrency.CanPickup) return;
                DXSoundManager.Play(SoundIndex.GoldPickUp);

                if (GameScene.Game.CurrencyPickedUp == null && userCurrency.Amount > 0)
                    GameScene.Game.CurrencyPickedUp = userCurrency;
                else
                    GameScene.Game.CurrencyPickedUp = null;
            }
        }

        #region Methods

        public void RefreshCurrency()
        {
            RefreshPrimaryCurrency();
            RefreshSecondaryCurrency();
        }

        private void SetPrimaryCurrency(CurrencyInfo currency)
        {
            PrimaryCurrency = currency ?? Globals.CurrencyInfoList.Binding.First(x => x.Type == CurrencyType.Gold);
        }

        private void RefreshPrimaryCurrency()
        {
            SetPrimaryCurrency(PrimaryCurrency);

            var userCurrency = GameScene.Game.User.GetCurrency(PrimaryCurrency);

            PrimaryCurrencyTitle.Text = userCurrency.Info.Abbreviation;
            PrimaryCurrencyLabel.Text = userCurrency.Amount.ToString("#,##0");
        }

        private void SetSecondaryCurrency(CurrencyInfo currency)
        {
            SecondaryCurrency = currency ?? Globals.CurrencyInfoList.Binding.First(x => x.Type == CurrencyType.GameGold);
        }

        private void RefreshSecondaryCurrency()
        {
            SetSecondaryCurrency(SecondaryCurrency);

            if (InvMode == InventoryMode.Sell) return;

            var userCurrency = GameScene.Game.User.GetCurrency(SecondaryCurrency);

            SecondaryCurrencyTitle.Text = userCurrency.Info.Abbreviation;
            SecondaryCurrencyTitle.ForeColour = Color.DarkOrange;
            SecondaryCurrencyLabel.Text = userCurrency.Amount.ToString("#,##0");
        }

        public void SellMode(CurrencyInfo currency, List<ItemType> sellableItemTypes)
        {
            SetPrimaryCurrency(currency);

            SellableItemTypes = sellableItemTypes;

            InvMode = InventoryMode.Sell;
        }

        public void NormalMode()
        {
            SetPrimaryCurrency(null);

            SellableItemTypes.Clear();

            InvMode = InventoryMode.Normal;
        }

        #region InventoryMode

        public InventoryMode InvMode
        {
            get => _InvMode;
            set
            {
                if (_InvMode == value) return;

                InventoryMode oldValue = _InvMode;
                _InvMode = value;

                OnInventoryModeChanged(oldValue, value);
            }
        }

        private InventoryMode _InvMode;
        public event EventHandler<EventArgs> InventoryModeChanged;
        public void OnInventoryModeChanged(InventoryMode oValue, InventoryMode nValue)
        {
            TrashButton.Visible = false;
            SellButton.Visible = false;

            DXItemCell.SelectedCell = null;

            switch (nValue)
            {
                case InventoryMode.Normal:
                    {
                        RefreshCurrency();

                        TrashButton.Visible = true;

                        TitleLabel.Text = CEnvir.Language.InventoryDialogTitle;
                        TitleLabel.Location = new Point((DisplayArea.Width - TitleLabel.Size.Width) / 2, 8);
                    }
                    break;
                case InventoryMode.Sell:
                    {
                        SecondaryCurrencyTitle.Text = "Total";
                        SecondaryCurrencyTitle.ForeColour = Color.CornflowerBlue;
                        SecondaryCurrencyLabel.Text = 0.ToString("#,##0");

                        SellButton.Visible = true;

                        TitleLabel.Text = CEnvir.Language.InventoryDialogTitle + " [Sell]";
                        TitleLabel.Location = new Point((DisplayArea.Width - TitleLabel.Size.Width) / 2, 8);
                    }
                    break;
            }

            InventoryModeChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (Grid != null)
                {
                    if (!Grid.IsDisposed)
                        Grid.Dispose();

                    Grid = null;
                }

                if (TitleLabel != null)
                {
                    if (!TitleLabel.IsDisposed)
                        TitleLabel.Dispose();

                    TitleLabel = null;
                }

                if (PrimaryCurrencyLabel != null)
                {
                    if (!PrimaryCurrencyLabel.IsDisposed)
                        PrimaryCurrencyLabel.Dispose();

                    PrimaryCurrencyLabel = null;
                }

                if (SecondaryCurrencyLabel != null)
                {
                    if (!SecondaryCurrencyLabel.IsDisposed)
                        SecondaryCurrencyLabel.Dispose();

                    SecondaryCurrencyLabel = null;
                }

                if (PrimaryCurrencyTitle != null)
                {
                    if (!PrimaryCurrencyTitle.IsDisposed)
                        PrimaryCurrencyTitle.Dispose();

                    PrimaryCurrencyTitle = null;
                }

                if (SecondaryCurrencyTitle != null)
                {
                    if (!SecondaryCurrencyTitle.IsDisposed)
                        SecondaryCurrencyTitle.Dispose();

                    SecondaryCurrencyTitle = null;
                }

                if (CloseButton != null)
                {
                    if (!CloseButton.IsDisposed)
                        CloseButton.Dispose();

                    CloseButton = null;
                }

                if (SortButton != null)
                {
                    if (!SortButton.IsDisposed)
                        SortButton.Dispose();

                    SortButton = null;
                }

                if (TrashButton != null)
                {
                    if (!TrashButton.IsDisposed)
                        TrashButton.Dispose();

                    TrashButton = null;
                }

                if (SellButton != null)
                {
                    if (!SellButton.IsDisposed)
                        SellButton.Dispose();

                    SellButton = null;
                }

                if (PrimaryCurrencyTitle != null)
                {
                    if (!PrimaryCurrencyTitle.IsDisposed)
                        PrimaryCurrencyTitle.Dispose();

                    SecondaryCurrencyTitle = null;
                }

                if (SecondaryCurrencyTitle != null)
                {
                    if (!SecondaryCurrencyTitle.IsDisposed)
                        SecondaryCurrencyTitle.Dispose();

                    SecondaryCurrencyTitle = null;
                }
            }
        }

        #endregion
    }
}