using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TibiaBotUI.Models
{
    public class HealerRule : INotifyPropertyChanged
    {
        private string _name;
        private Spell _spell;
        private string _triggerType;
        private int _minTrigger;
        private int _maxTrigger;
        private int _priority;

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

        public HealerRule(string name, Spell spell, string triggerType, int minTrigger, int maxTrigger, int priority)
        {
            _name = name;
            _spell = spell;
            _triggerType = triggerType;
            _minTrigger = minTrigger;
            _maxTrigger = maxTrigger;
            _priority = priority;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}