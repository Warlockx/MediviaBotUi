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
        private HealerConditions _condition;
        private int _triggerLimit = int.MaxValue;
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
            get { return _triggerType; }
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
                if(value == _condition) return;
                if (value.ToString().Contains("Percent"))
                {
                    TriggerType = "hppc";
                    TriggerLimit = 100;
                }
                else
                {
                    TriggerType = "hp";
                    TriggerLimit = int.MaxValue;
                }
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

        public HealerRule(string name, Spell spell, int minTrigger, int maxTrigger, int priority, HealerConditions condition, int minSpamRate, int maxSpamRate)
        {
            Name = name;
            Spell = spell;
            MinTrigger = minTrigger;
            MaxTrigger = maxTrigger;
            Priority = priority;
            Condition = condition;
            MinSpamRate = minSpamRate;
            MaxSpamRate = maxSpamRate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}