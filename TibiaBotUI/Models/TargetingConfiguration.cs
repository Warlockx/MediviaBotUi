using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBotUI.Models
{
    public class TargetingConfiguration :INotifyPropertyChanged
    {
        private int _proximity;
        private int _health;
        private int _danger;
        private Monster _targetMonster;
        private TargetingStance _stance;
        private int _keepAwayDistance;
        private AttackMode _attackMode;
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private Spell _currentSpell;
        private bool _onlyIfTrapped;
        public int Proximity
        {
            get { return _proximity; }
            set
            {
                if(value == _proximity) return;
                _proximity = value;
                OnPropertyChanged();
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                if (value == _health) return;
                _health = value;
                OnPropertyChanged();
            }
        }

        public int Danger
        {
            get { return _danger; }
            set
            {
                if (value == _danger) return;
                _danger = value;
                OnPropertyChanged();
            }
        }

        public TargetingStance Stance
        {
            get { return _stance; }
            set
            {
                if(value == _stance) return;
                _stance = value;
                OnPropertyChanged();
            }
        }

        public Monster TargetMonster
        {
            get { return _targetMonster; }
            set
            {
                if(value == _targetMonster) return;
                _targetMonster = value;
                OnPropertyChanged();
            }
        }

        public int KeepAwayDistance
        {
            get { return _keepAwayDistance; }
            set
            {
                if(value== _keepAwayDistance) return;
                _keepAwayDistance = value;
                OnPropertyChanged();
            }
        }

        public AttackMode AttackMode
        {
            get { return _attackMode; }
            set
            {
                if(value == _attackMode) return;
                _attackMode = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Spell> Spells
        {
            get
            {
                return _spells;
            }

            set
            {
                if(value == _spells) return;
                _spells = value;
                OnPropertyChanged();
            }
        }

        public Spell CurrentSpell
        {
            get
            {
                return _currentSpell;
            }

            set
            {
                if (value == _currentSpell) return;
                _currentSpell = value;
                OnPropertyChanged();
            }
        }

        public bool OnlyIfTrapped
        {
            get
            {
                return _onlyIfTrapped;
            }

            set
            {
                if(value == _onlyIfTrapped) return;
                _onlyIfTrapped = value;
                OnPropertyChanged();
            }
        }

        public bool CanAddSpell(TargetingConfiguration obj)
        {
            return Spells.All(s => s != CurrentSpell);
        }

        public void AddSpell(TargetingConfiguration obj)
        {
            Spells.Add(CurrentSpell);
        }

        public bool CanRemoveSpell(Spell obj)
        {
            return Spells.Any(s => s == obj);
        }

        public void RemoveSpell(Spell obj)
        {
            Spells.Remove(obj);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
