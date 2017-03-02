using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using MediviaBotUI.Commands;

namespace MediviaBotUI.Models
{
    public class TargetingSetting :INotifyPropertyChanged
    {
        private int _danger;
        private Monster _targetMonster;
        private TargetingStance _stance;
        private int _keepAwayDistance;
        private AttackMode _attackMode;
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private Spell _currentSpell;
        private bool _onlyIfTrapped;
        public ICommand AddSpell { get; set; }
        public ICommand RemoveSpell { get; set; }

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

        public int Danger
        {
            get
            {
                return _danger;
            }

            set
            {
                if (value == _danger) return;
                _danger = value;
                OnPropertyChanged();
            }
        }

        public TargetingSetting()
        {
            AddSpell = new RelayCommand<TargetingSetting>(_addSpell, _canAddSpell);
            RemoveSpell = new RelayCommand<Spell>(_removeSpell, _canRemoveSpell);
        }

        public bool IsValid()
        {
            return TargetMonster != null;
        }
        private bool _canAddSpell(TargetingSetting obj)
        {
            return Spells.All(s => s != CurrentSpell);
        }

        private void _addSpell(TargetingSetting obj)
        {
            Spells.Add(CurrentSpell);
        }

        private bool _canRemoveSpell(Spell obj)
        {
            return Spells.Any(s => s == obj);
        }

        private void _removeSpell(Spell obj)
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
