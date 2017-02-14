using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TibiaBotUI.Models
{
    public class HealerRule : INotifyPropertyChanged
    {
        private string _name;
        private Spell _spell;
        private string _triggerType = "hp";
        private int _minTrigger;
        private int _maxTrigger;
        private int _priority;
        private int _triggerLimit = int.MaxValue;
        private HealerConditions _condition;
        private HealerConditions? _additionalCondition;
        private string _additionalTriggerType = "hp";
        private int? _additionalMinTrigger;
        private int? _additionalMaxTrigger;
        private int _additionalTriggerLimit = int.MaxValue;
        private int _minSpamRate;
        private int _maxSpamRate;
        private bool _hasAddtionalCondition;

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
        public int MinTrigger
        {
            get { return _minTrigger; }
            set
            {
                if (value == _minTrigger) return;
                _minTrigger = value;
                OnPropertyChanged();
            }
        }
        public int? AdditionalMinTrigger
        {
            get { return _additionalMinTrigger; }
            set
            {
                if (value == _additionalMinTrigger) return;
                _additionalMinTrigger = value;
                OnPropertyChanged();
            }
        }
        public int MaxTrigger
        {
            get { return _maxTrigger; }
            set
            {
                if (value == _maxTrigger) return;
                _maxTrigger = value;
                OnPropertyChanged();
            }
        }
        public int? AdditionalMaxTrigger
        {
            get { return _additionalMaxTrigger; }
            set
            {
                if (value == _additionalMaxTrigger) return;
                _additionalMaxTrigger = value;
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
        public string AdditionalTriggerType
        {
            get
            {
                return _getTriggerType(_additionalCondition);
            }
            set
            {
                if (value == _additionalTriggerType) return;
                _additionalTriggerType = value;
                OnPropertyChanged();
            }
        }
        public HealerConditions Condition
        {
            get { return _condition; }
            set
            {
                if(value == _condition ) return;
                TriggerLimit = value.ToString().Contains("Percent") ? 100 : int.MaxValue;
                _condition = value;
                OnPropertyChanged();
            }
        }
        public HealerConditions? AdditionalCondition
        {
            get { return _additionalCondition; }
            set
            {
                if (value == _additionalCondition) return;
                TriggerLimit = value.ToString().Contains("Percent") ? 100 : int.MaxValue;
                _additionalCondition = value;
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
        public int AdditionalTriggerLimit
        {
            get { return _additionalTriggerLimit; }
            set
            {
                if (value == _additionalTriggerLimit) return;

                _additionalTriggerLimit = value;
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
        public bool HasAddtionalCondition
        {
            get { return _hasAddtionalCondition; }
            set
            {
                if(value == _hasAddtionalCondition) return;
                _hasAddtionalCondition = value;
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

        public HealerRule(string name, Spell spell, int minTrigger, int maxTrigger, int priority,bool hasAdditionalCondition, HealerConditions condition, HealerConditions? additionalCondition, int? additionalMinTrigger, int? additionalMaxTrigger, int minSpamRate, int maxSpamRate)
        {
            _name = name;
            _spell = spell;
            _minTrigger = minTrigger;
            _maxTrigger = maxTrigger;
            _priority = priority;
            _condition = condition;
            if (!hasAdditionalCondition)
            {
                _additionalCondition = null;
                _additionalMinTrigger = null;
                _additionalMaxTrigger = null;
            }
            else
            {
                _additionalCondition = additionalCondition;
                _additionalMinTrigger = additionalMinTrigger;
                _additionalMaxTrigger = additionalMaxTrigger;
            }
          
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