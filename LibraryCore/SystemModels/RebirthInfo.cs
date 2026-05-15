using MirDB;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.SystemModels
{
    public sealed class RebirthInfo : DBObject
    {
        [IsIdentity]
        public int Order
        {
            get { return _Order; }
            set
            {
                if (_Order == value) return;
                var oldValue = _Order;
                _Order = value;
                OnChanged(oldValue, value, "Order");
            }
        }
        private int _Order;

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value) return;
                var oldValue = _Title;
                _Title = value;
                OnChanged(oldValue, value, "Title");
            }
        }
        private string _Title;

        public int RequiredLevel
        {
            get { return _RequiredLevel; }
            set
            {
                if (_RequiredLevel == value) return;
                var oldValue = _RequiredLevel;
                _RequiredLevel = value;
                OnChanged(oldValue, value, "RequiredLevel");
            }
        }
        private int _RequiredLevel;

        public int ResetToLevel
        {
            get { return _ResetToLevel; }
            set
            {
                if (_ResetToLevel == value) return;
                var oldValue = _ResetToLevel;
                _ResetToLevel = value;
                OnChanged(oldValue, value, "ResetToLevel");
            }
        }
        private int _ResetToLevel;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description == value) return;
                var oldValue = _Description;
                _Description = value;
                OnChanged(oldValue, value, "Description");
            }
        }
        private string _Description;

        [Association("Rebirth", true)]
        public DBBindingList<RebirthReward> Rewards { get; set; }

        [Association("Rebirth", true)]
        public DBBindingList<RebirthBenefit> Benefits { get; set; }
    }

    public sealed class RebirthReward : DBObject
    {
        [Association("Rebirth")]
        public RebirthInfo Rebirth
        {
            get { return _Rebirth; }
            set
            {
                if (_Rebirth == value) return;
                var oldValue = _Rebirth;
                _Rebirth = value;
                OnChanged(oldValue, value, "Rebirth");
            }
        }
        private RebirthInfo _Rebirth;

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

    public sealed class RebirthBenefit : DBObject
    {
        [Association("Rebirth")]
        public RebirthInfo Rebirth
        {
            get { return _Rebirth; }
            set
            {
                if (_Rebirth == value) return;
                var oldValue = _Rebirth;
                _Rebirth = value;
                OnChanged(oldValue, value, "Rebirth");
            }
        }
        private RebirthInfo _Rebirth;

        public Stat StatName
        {
            get { return _StatName; }
            set
            {
                if (_StatName == value) return;
                var oldValue = _StatName;
                _StatName = value;
                OnChanged(oldValue, value, "StatName");
            }
        }
        private Stat _StatName;

        public int Rate
        {
            get { return _Rate; }
            set
            {
                if (_Rate == value) return;
                var oldValue = _Rate;
                _Rate = value;
                OnChanged(oldValue, value, "Rate");
            }
        }
        private int _Rate;
    }
}
