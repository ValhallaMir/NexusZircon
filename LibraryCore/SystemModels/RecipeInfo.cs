using MirDB;

namespace Library.SystemModels
{
    public sealed class RecipeInfo : DBObject
    {
        [IsIdentity]
        public int Index
        {
            get { return _Index; }
            set
            {
                if (_Index == value) return;
                var oldValue = _Index;
                _Index = value;
                OnChanged(oldValue, value, "Index");
            }
        }
        private int _Index;

        public ItemInfo MainItem
        {
            get { return _MainItem; }
            set
            {
                if (_MainItem == value) return;
                var oldValue = _MainItem;
                _MainItem = value;
                OnChanged(oldValue, value, "MainItem");
            }
        }
        private ItemInfo _MainItem;

        public int Chance
        {
            get { return _Chance; }
            set
            {
                if (_Chance == value) return;
                var oldValue = _Chance;
                _Chance = value;
                OnChanged(oldValue, value, "Chance");
            }
        }
        private int _Chance;

        [Association("Recipe", true)]
        public DBBindingList<RecipeRequiredItem> RequiredItems { get; set; }

        [Association("Recipe", true)]
        public DBBindingList<RecipeRequiredCurrency> RequiredCurrencies { get; set; }
    }

    public sealed class RecipeRequiredItem : DBObject
    {
        [Association("Recipe")]
        public RecipeInfo Recipe
        {
            get { return _Recipe; }
            set
            {
                if (_Recipe == value) return;
                var oldValue = _Recipe;
                _Recipe = value;
                OnChanged(oldValue, value, "Recipe");
            }
        }
        private RecipeInfo _Recipe;

        public ItemInfo ItemName
        {
            get { return _ItemName; }
            set
            {
                if (_ItemName == value) return;
                var oldValue = _ItemName;
                _ItemName = value;
                OnChanged(oldValue, value, "ItemName");
            }
        }
        private ItemInfo _ItemName;

        public int Count
        {
            get { return _Count; }
            set
            {
                if (_Count == value) return;
                var oldValue = _Count;
                _Count = value;
                OnChanged(oldValue, value, "Count");
            }
        }
        private int _Count;
    }

    public sealed class RecipeRequiredCurrency : DBObject
    {
        [Association("Recipe")]
        public RecipeInfo Recipe
        {
            get { return _Recipe; }
            set
            {
                if (_Recipe == value) return;
                var oldValue = _Recipe;
                _Recipe = value;
                OnChanged(oldValue, value, "Recipe");
            }
        }
        private RecipeInfo _Recipe;

        public CurrencyInfo CurrencyName
        {
            get { return _CurrencyName; }
            set
            {
                if (_CurrencyName == value) return;
                var oldValue = _CurrencyName;
                _CurrencyName = value;
                OnChanged(oldValue, value, "CurrencyName");
            }
        }
        private CurrencyInfo _CurrencyName;

        public int Count
        {
            get { return _Count; }
            set
            {
                if (_Count == value) return;
                var oldValue = _Count;
                _Count = value;
                OnChanged(oldValue, value, "Count");
            }
        }
        private int _Count;
    }
}
