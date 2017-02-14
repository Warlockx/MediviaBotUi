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
        private int _cooldown;


       

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

        public HealItem(string name, int cooldown)
        {
            _name = name;
            _cooldown = cooldown;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
