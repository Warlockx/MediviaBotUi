using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBotUI.Models
{
    public class TargetingTemplate : INotifyPropertyChanged
    {
        private string _name;
        private int _distance;
        private AttackMode _attackMode;
        private IEnumerable<Spell> _spells;
        private bool _ifTrapped;

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

        public int Distance
        {
            get { return _distance; }
            set
            {
                if (value == _distance) return;
                _distance = value;
                OnPropertyChanged();

            }
        }

        public AttackMode Mode
        {
            get { return _attackMode; }
            set
            {
                if (value == _attackMode) return;
                _attackMode = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Spell> Spells
        {
            get { return _spells; }
            set
            {
                if (value.Equals(_spells)) return;
                _spells = value;
                OnPropertyChanged();
            }
        }

        public bool IfTrapped
        {
            get { return _ifTrapped; }
            set
            {
                if (value == _ifTrapped) return;
                _ifTrapped = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
