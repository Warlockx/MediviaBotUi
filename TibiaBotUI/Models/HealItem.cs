using System.ComponentModel;
using System.Runtime.CompilerServices;
using MediviaBotUI.Properties;

namespace MediviaBotUI.Models
{
    public class HealItem : INotifyPropertyChanged
    {
        private string _name;
        private int _magicLevelRequirement;
        private int _cooldown;
        private string[] _vocationToUse;

        public string Name
        {
            get { return _name; }
            set
            {
                if(value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Cooldown
        {
            get { return _cooldown; }
            set
            {
                if(value == _cooldown) return;
                _cooldown = value;
                OnPropertyChanged();
            }
        }

        public string[] VocationToUse
        {
            get { return _vocationToUse; }
            set
            {
                if(value == _vocationToUse) return;
                _vocationToUse = value;
                OnPropertyChanged();
            }
        }

        public int MagicLevelRequirement
        {
            get { return _magicLevelRequirement; }
            set
            {
                if(value == _magicLevelRequirement) return;
                _magicLevelRequirement = value;
                OnPropertyChanged();
            }
        }

        public HealItem(string name, int magicLevelRequirement, int cooldown, string[] vocationToUse)
        {
            _name = name;
            _magicLevelRequirement = magicLevelRequirement;
            _cooldown = cooldown;
            _vocationToUse = vocationToUse;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
