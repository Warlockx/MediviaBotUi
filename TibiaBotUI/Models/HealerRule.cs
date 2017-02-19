using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TibiaBotUI.Models
{
    public class HealerRule : INotifyPropertyChanged
    {
        private string _name;
        private Spell _spell;
        private HealItem _healItem;
        private string _triggerType = "hp";
        private int? _minTrigger;
        private int? _maxTrigger;
        private string _triggerSplitter = "~";
        private string _triggerDecoration = "%";
        private int _priority;
        private int _triggerLimit = int.MaxValue;
        private HealerConditions _condition;
        private int _minSpamRate;
        private int _maxSpamRate;
        

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public Spell Spell
        {
            get { return _spell; }
            set
            {
                if (value == _spell) return;
                _spell = value;
                OnPropertyChanged();
            }
        }
        public int? MinTrigger
        {
            get { return _minTrigger; }
            set
            {
                if (value == _minTrigger) return;
                TriggerSplitter = value == null ?  "" :  "~";
                _minTrigger = value;
                OnPropertyChanged();
            }
        }
        public int? MaxTrigger
        {
            get { return _maxTrigger; }
            set
            {
                if (value == _maxTrigger) return;
                TriggerSplitter = value == null ? "" : "~";
                _maxTrigger = value;
                OnPropertyChanged();
            }
        }
        public int Priority
        {
            get { return _priority; }
            set
            {
                if (value == _priority) return;
                _priority = value;
                OnPropertyChanged();
            }
        }
        public string TriggerType
        {
            get
            {
                return _getTriggerType(Condition);
            }
            set
            {
                if (value == _triggerType) return;
                _triggerType = value;
                OnPropertyChanged();
            }
        }
        public HealerConditions Condition
        {
            get { return _condition; }
            set
            {
                if(value == _condition ) return;
                string valueString = value.ToString();
                TriggerLimit = valueString.Contains("Percent") ? 100 : int.MaxValue;
                TriggerDecoration = valueString.Contains("Percent") ? "%" : "";
                _condition = value;
                OnPropertyChanged();
            }
        }
        public int TriggerLimit
        {
            get { return _triggerLimit; }
            set
            {
                if(value == _triggerLimit) return;
                
                _triggerLimit = value;
                OnPropertyChanged();
            }
        }
        public int MinSpamRate
        {
            get { return _minSpamRate; }
            set
            {
                if(value == _minSpamRate) return;
                _minSpamRate = value;
                OnPropertyChanged();
            }
        }
        public int MaxSpamRate
        {
            get { return _maxSpamRate; }
            set
            {
                if(value == _maxSpamRate) return;
                _maxSpamRate = value;
                OnPropertyChanged();
            }
        }

        public HealItem HealItem
        {
            get { return _healItem; }
            set
            {
                if(value == _healItem) return;
                _healItem = value;
                OnPropertyChanged();
            }
        }

        public string TriggerSplitter
        {
            get { return _triggerSplitter; }
            set
            {
                if(value == _triggerSplitter) return;
                _triggerSplitter = value;
                OnPropertyChanged();
            }
        }

        public string TriggerDecoration
        {
            get { return _triggerDecoration; }
            set
            {
                if(value == _triggerDecoration) return;
                _triggerDecoration = value;
                OnPropertyChanged();
            }
        }


        private string _getTriggerType(HealerConditions? conditions)
        {
            if (conditions == null)
                return string.Empty;
            switch (conditions)
            {
                    case HealerConditions.Hitpoints:
                     return "hp";
                    case HealerConditions.HitpointsPercent:
                    return "hppc";
                    case HealerConditions.Mana:
                    return "mp";
                    case HealerConditions.ManaPercent:
                    return "mppc";
                default:
                    return Condition.ToString().ToLower();
            }
        }

        public HealerRule(string name, Spell spell, HealItem healItem, int? minTrigger, int? maxTrigger, int priority, HealerConditions condition,int minSpamRate, int maxSpamRate)
        {
            _name = name;
            _spell = spell;
            _healItem = healItem;
            _minTrigger = minTrigger;
            _maxTrigger = maxTrigger;
            _priority = priority;
            _condition = condition;
            _minSpamRate = minSpamRate;
            _maxSpamRate = maxSpamRate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}