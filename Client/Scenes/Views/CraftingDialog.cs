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

namespace Client.Scenes.Views
{
    public sealed class CraftingDialog : DXWindow
    {
        private readonly List<RecipeRow> Rows = [];
        private readonly List<DXItemCell> RequirementItemCells = [];
        private readonly List<DXLabel> RequirementNameLabels = [];
        private readonly List<DXLabel> RequirementCountLabels = [];
        private readonly List<DXItemCell> CurrencyItemCells = [];
        private readonly List<DXLabel> CurrencyNameLabels = [];
        private readonly List<DXLabel> CurrencyCountLabels = [];

        private DXControl LeftPanel;
        private DXVScrollBar ScrollBar;
        private const int VisibleRowCount = 8;
        private RecipeRow SelectedRow;
        private DXLabel RecipeTitleLabel;
        private DXLabel SuccessChanceLabel;
        private DXLabel RequirementsLabel;
        private DXLabel RequiredItemsLabel;
        private DXLabel RequiredCurrenciesLabel;
        private DXControl RequiredItemsGridPanel;
        private DXControl RequiredCurrenciesGridPanel;
        private DXButton CraftNowButton;

        public WindowSetting Settings;
        public override WindowType Type => WindowType.CraftingBox;
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

        public CraftingDialog()
        {
            Movable = true;
            Sort = true;
            DropShadow = true;

            TitleLabel.Text = "Crafting";
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
                Text = "Available Recipes",
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
                Text = "Recipe Details",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            RecipeTitleLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(10, 40),
                Text = "Select a recipe",
                ForeColour = Color.White,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
            };

            SuccessChanceLabel = new DXLabel
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

            RequiredItemsLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(20, 115),
                Text = "Required Items:",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            RequiredItemsGridPanel = new DXControl
            {
                Parent = rightPanel,
                Location = new Point(15, 137),
                Size = new Size(DXItemCell.CellWidth * 5 + 8 * 4, DXItemCell.CellHeight * 2 + 8),
            };

            RequiredCurrenciesLabel = new DXLabel
            {
                Parent = rightPanel,
                AutoSize = true,
                Location = new Point(20, 230),
                Text = "Required Currencies:",
                ForeColour = Color.Goldenrod,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
            };

            RequiredCurrenciesGridPanel = new DXControl
            {
                Parent = rightPanel,
                Location = new Point(15, 252),
                Size = new Size(DXItemCell.CellWidth * 5 + 8 * 4, DXItemCell.CellHeight + 8),
            };

            CraftNowButton = new DXButton
            {
                Size = new Size(285, SmallButtonHeight),
                Parent = rightPanel,
                Label = { Text = "Craft Now" },
                GrayScale = true,
                Enabled = false,
                Location = new Point(5, 475),
                ButtonType = ButtonType.SmallButton
            };

            RefreshRows();
        }

        public void UpdateUI() => RefreshRows();

        private void RefreshRows()
        {
            RecipeInfo selectedRecipe = SelectedRow?.Recipe;

            foreach (RecipeRow row in Rows)
                row.Dispose();
            Rows.Clear();

            var recipes = Globals.RecipeInfoList?.Binding?.ToList() ?? [];
            ScrollBar.MaxValue = Math.Max(0, recipes.Count);
            ScrollBar.Value = Math.Min(ScrollBar.Value, Math.Max(0, ScrollBar.MaxValue - ScrollBar.VisibleSize));

            foreach (var recipe in recipes.Skip(ScrollBar.Value).Take(VisibleRowCount))
            {
                RecipeRow row = new RecipeRow
                {
                    Parent = LeftPanel,
                    Recipe = recipe,
                };
                row.MouseClick += Row_MouseClick;
                row.MouseWheel += ScrollBar.DoMouseWheel;
                Rows.Add(row);
            }

            SelectedRow = null;
            if (selectedRecipe != null)
                SelectedRow = Rows.FirstOrDefault(x => x.Recipe == selectedRecipe);
            if (SelectedRow == null && Rows.Count > 0)
                SelectedRow = Rows[0];
            if (SelectedRow != null)
                SelectedRow.Selected = true;

            UpdateRowLocations();
            UpdateSelection();
        }

        private void Row_MouseClick(object sender, MouseEventArgs e) => SetSelectedRow((RecipeRow)sender);

        private void SetSelectedRow(RecipeRow row)
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

            foreach (RecipeRow row in Rows)
            {
                row.Location = new Point(7, y);
                row.Visible = row.Location.Y + row.Size.Height > 25 && row.Location.Y < LeftPanel.Size.Height;
                y += RecipeRow.RowHeight + 8;
            }
        }

        private void UpdateSelection()
        {
            var recipe = SelectedRow?.Recipe;

            ClearDynamicLabels();

            if (recipe == null)
            {
                RecipeTitleLabel.Text = "Select a recipe";
                SuccessChanceLabel.Text = string.Empty;
                CraftNowButton.Enabled = false;
                CraftNowButton.GrayScale = true;
                return;
            }

            RecipeTitleLabel.Text = recipe.MainItem?.ItemName ?? "Unnamed Recipe";
            SuccessChanceLabel.Text = $"Success Chance: {recipe.Chance}%";
            RequirementsLabel.Text = $"Requirements: {GetRequiredItemsProgress(recipe):0}%";

            RenderRequirementCells(recipe);

            bool canCraft = HasAllRequiredItems(recipe);
            CraftNowButton.Enabled = canCraft;
            CraftNowButton.GrayScale = !canCraft;
        }

        private void RenderRequirementCells(RecipeInfo recipe)
        {
            ClearDynamicItemCells();

            if (recipe.RequiredItems != null)
            {
                for (int i = 0; i < Math.Min(10, recipe.RequiredItems.Count); i++)
                {
                    int row = i;
                    var item = recipe.RequiredItems[i];
                    int cellX = RequiredItemsGridPanel.Location.X;
                    int cellY = RequiredItemsGridPanel.Location.Y + row * (DXItemCell.CellHeight + 8);
                    int textX = cellX + DXItemCell.CellWidth + 10;

                    DXItemCell cell = new DXItemCell
                    {
                        Parent = RequiredItemsGridPanel,
                        Location = new Point(0, row * (DXItemCell.CellHeight + 8)),
                        Size = new Size(DXItemCell.CellWidth, DXItemCell.CellHeight),
                        Border = true,
                        FixedBorder = true,
                        FixedBorderColour = true,
                        BorderColour = Color.FromArgb(198, 166, 99),
                        GridType = GridType.None,
                        ItemGrid = new ClientUserItem[1],
                        Slot = 0,
                        ReadOnly = true,
                        GrayScale = false,
                        Opacity = 1F,
                    };

                    if (item.ItemName != null)
                        cell.ItemGrid[0] = new ClientUserItem(item.ItemName, item.Count);

                    RequirementItemCells.Add(cell);

                    RequirementNameLabels.Add(new DXLabel
                    {
                        Parent = RequiredItemsGridPanel.Parent,
                        AutoSize = true,
                        Location = new Point(textX, cellY + 2),
                        Text = item.ItemName?.ItemName ?? "Unknown",
                        ForeColour = Color.WhiteSmoke,
                    });

                    RequirementCountLabels.Add(new DXLabel
                    {
                        Parent = RequiredItemsGridPanel.Parent,
                        AutoSize = true,
                        Location = new Point(textX, cellY + 18),
                        Text = $"{GetInventoryCount(item.ItemName)}/{item.Count}",
                        ForeColour = GetInventoryCount(item.ItemName) >= item.Count ? Color.LimeGreen : Color.OrangeRed,
                    });
                }
            }

            if (recipe.RequiredCurrencies != null)
            {
                for (int i = 0; i < Math.Min(10, recipe.RequiredCurrencies.Count); i++)
                {
                    int row = i;
                    var currency = recipe.RequiredCurrencies[i];
                    int cellX = RequiredCurrenciesGridPanel.Location.X;
                    int cellY = RequiredCurrenciesGridPanel.Location.Y + row * (DXItemCell.CellHeight + 8);
                    int textX = cellX + DXItemCell.CellWidth + 10;

                    DXItemCell cell = new DXItemCell
                    {
                        Parent = RequiredCurrenciesGridPanel,
                        Location = new Point(0, row * (DXItemCell.CellHeight + 8)),
                        Size = new Size(DXItemCell.CellWidth, DXItemCell.CellHeight),
                        Border = true,
                        FixedBorder = true,
                        FixedBorderColour = true,
                        BorderColour = Color.FromArgb(198, 166, 99),
                        GridType = GridType.None,
                        ItemGrid = new ClientUserItem[1],
                        Slot = 0,
                        ReadOnly = true,
                        GrayScale = false,
                        Opacity = 1F,
                    };

                    if (currency.CurrencyName?.DropItem != null)
                        cell.ItemGrid[0] = new ClientUserItem(currency.CurrencyName.DropItem, currency.Count);

                    CurrencyItemCells.Add(cell);

                    CurrencyNameLabels.Add(new DXLabel
                    {
                        Parent = RequiredCurrenciesGridPanel.Parent,
                        AutoSize = true,
                        Location = new Point(textX, cellY + 2),
                        Text = currency.CurrencyName?.Name ?? "Unknown",
                        ForeColour = Color.WhiteSmoke,
                    });

                    CurrencyCountLabels.Add(new DXLabel
                    {
                        Parent = RequiredCurrenciesGridPanel.Parent,
                        AutoSize = true,
                        Location = new Point(textX, cellY + 18),
                        Text = $"{GetInventoryCount(currency.CurrencyName?.DropItem)}/{currency.Count}",
                        ForeColour = GetInventoryCount(currency.CurrencyName?.DropItem) >= currency.Count ? Color.LimeGreen : Color.OrangeRed,
                    });
                }
            }
        }

        private void ClearDynamicItemCells()
        {
            foreach (var cell in RequirementItemCells)
                if (cell != null && !cell.IsDisposed)
                    cell.Dispose();
            RequirementItemCells.Clear();

            foreach (var label in RequirementNameLabels)
                if (label != null && !label.IsDisposed)
                    label.Dispose();
            RequirementNameLabels.Clear();

            foreach (var label in RequirementCountLabels)
                if (label != null && !label.IsDisposed)
                    label.Dispose();
            RequirementCountLabels.Clear();

            foreach (var cell in CurrencyItemCells)
                if (cell != null && !cell.IsDisposed)
                    cell.Dispose();
            CurrencyItemCells.Clear();

            foreach (var label in CurrencyNameLabels)
                if (label != null && !label.IsDisposed)
                    label.Dispose();
            CurrencyNameLabels.Clear();

            foreach (var label in CurrencyCountLabels)
                if (label != null && !label.IsDisposed)
                    label.Dispose();
            CurrencyCountLabels.Clear();
        }

        private void ClearDynamicLabels()
        {
            return;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                base.Dispose(disposing);
                return;
            }

            foreach (var row in Rows)
                if (row != null && !row.IsDisposed)
                    row.Dispose();
            Rows.Clear();

            ClearDynamicItemCells();
            ClearDynamicLabels();

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

            if (RecipeTitleLabel != null)
            {
                if (!RecipeTitleLabel.IsDisposed)
                    RecipeTitleLabel.Dispose();
                RecipeTitleLabel = null;
            }

            if (SuccessChanceLabel != null)
            {
                if (!SuccessChanceLabel.IsDisposed)
                    SuccessChanceLabel.Dispose();
                SuccessChanceLabel = null;
            }

            if (RequirementsLabel != null)
            {
                if (!RequirementsLabel.IsDisposed)
                    RequirementsLabel.Dispose();
                RequirementsLabel = null;
            }

            if (RequiredItemsLabel != null)
            {
                if (!RequiredItemsLabel.IsDisposed)
                    RequiredItemsLabel.Dispose();
                RequiredItemsLabel = null;
            }

            if (RequiredItemsGridPanel != null)
            {
                if (!RequiredItemsGridPanel.IsDisposed)
                    RequiredItemsGridPanel.Dispose();
                RequiredItemsGridPanel = null;
            }

            if (RequiredCurrenciesLabel != null)
            {
                if (!RequiredCurrenciesLabel.IsDisposed)
                    RequiredCurrenciesLabel.Dispose();
                RequiredCurrenciesLabel = null;
            }

            if (RequiredCurrenciesGridPanel != null)
            {
                if (!RequiredCurrenciesGridPanel.IsDisposed)
                    RequiredCurrenciesGridPanel.Dispose();
                RequiredCurrenciesGridPanel = null;
            }

            if (CraftNowButton != null)
            {
                if (!CraftNowButton.IsDisposed)
                    CraftNowButton.Dispose();
                CraftNowButton = null;
            }

            SelectedRow = null;

            base.Dispose(disposing);
        }

        private sealed class RecipeRow : DXControl
        {
            public const int RowHeight = 50;

            public RecipeInfo Recipe
            {
                get => _Recipe;
                set
                {
                    if (_Recipe == value) return;
                    _Recipe = value;
                    UpdateText();
                }
            }
            private RecipeInfo _Recipe;

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
            private readonly DXItemCell Cell;

            public RecipeRow()
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
                    Location = new Point(52, 8),
                    ForeColour = Color.LimeGreen,
                    Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                    IsControl = false,
                };

                SubtitleLabel = new DXLabel
                {
                    Parent = this,
                    AutoSize = true,
                    Location = new Point(52, 20),
                    ForeColour = Color.WhiteSmoke,
                    Font = new Font(Config.FontName, CEnvir.FontSize(7F)),
                    IsControl = false,
                };

                Cell = new DXItemCell
                {
                    Parent = this,
                    Location = new Point(6, 6),
                    Size = new Size(38, 38),
                    Border = true,
                    FixedBorder = true,
                    FixedBorderColour = true,
                    BorderColour = Color.FromArgb(198, 166, 99),
                    BackColour = Color.Empty,
                    IsControl = false,
                    GridType = GridType.None,
                    ItemGrid = new ClientUserItem[1],
                    Slot = 0,
                    ReadOnly = true,
                    GrayScale = false,
                    Opacity = 1F,
                };
            }

            public void UpdateText()
            {
                if (Recipe == null)
                {
                    TitleLabel.Text = string.Empty;
                    SubtitleLabel.Text = string.Empty;
                    Cell.ItemGrid[0] = null;
                    return;
                }

                TitleLabel.Text = Recipe.MainItem?.ItemName ?? "Unnamed Recipe";
                SubtitleLabel.Text = $"{GetRequiredItemsProgress(Recipe):0}%";

                if (Recipe.MainItem != null)
                    Cell.ItemGrid[0] = new ClientUserItem(Recipe.MainItem, 1);
                else
                    Cell.ItemGrid[0] = null;
            }
        }

        private static int GetRequiredItemsProgress(RecipeInfo recipe)
        {
            if (recipe?.RequiredItems == null || recipe.RequiredItems.Count == 0)
                return 100;

            long requiredTotal = 0;
            long availableTotal = 0;

            foreach (var requirement in recipe.RequiredItems)
            {
                if (requirement?.ItemName == null || requirement.Count <= 0)
                    continue;

                requiredTotal += requirement.Count;
                availableTotal += GetInventoryCount(requirement.ItemName);
            }

            if (requiredTotal <= 0)
                return 100;

            return (int)Math.Min(100, Math.Floor(availableTotal * 100M / requiredTotal));
        }

        private bool HasAllRequiredItems(RecipeInfo recipe)
        {
            if (recipe?.RequiredItems == null || recipe.RequiredItems.Count == 0)
                return true;

            foreach (var requirement in recipe.RequiredItems)
            {
                if (requirement?.ItemName == null || requirement.Count <= 0)
                    continue;

                if (GetInventoryCount(requirement.ItemName) < requirement.Count)
                    return false;
            }

            return true;
        }

        private static long GetInventoryCount(ItemInfo item)
        {
            if (GameScene.Game?.Inventory == null || item == null)
                return 0;

            long count = 0;
            foreach (ClientUserItem inventoryItem in GameScene.Game.Inventory)
            {
                if (inventoryItem?.Info == item)
                    count += inventoryItem.Count;
            }

            return count;
        }
    }
}
