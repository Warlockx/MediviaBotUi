using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TibiaBotUI.Annotations;

namespace TibiaBotUI.Models
{
    public class HealItem : INotifyPropertyChanged
    {
        private string _name;
        private int _levelRequirement;
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

        public int LevelRequirement
        {
            get { return _levelRequirement; }
            set
            {
                if(value == _levelRequirement) return;
                _levelRequirement = value;
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

        public HealItem(string name, int cooldown, string[] vocationToUse)
        {
            _name = name;
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
