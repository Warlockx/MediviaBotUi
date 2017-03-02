using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBotUI.Models
{
    public class TargetingPriorities : INotifyPropertyChanged
    {
        private int _proximity;
        private int _danger;
        private int _health;
        private bool _targetMustBeReachable = true;
        private bool _targetMustBeShootable;
        private bool _nonPvpMode;
        private bool _antiKs;
        private bool _syncSpellsWithAttacks;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Proximity
        {
            get { return _proximity; }
            set
            {
                if(value == _proximity)return;
                _proximity = value;
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

        public bool TargetMustBeReachable
        {
            get { return _targetMustBeReachable; }
            set
            {
                if(value== _targetMustBeReachable) return;
                _targetMustBeReachable = value;
                OnPropertyChanged();
            }
        }

        public bool TargetMustBeShootable
        {
            get { return _targetMustBeShootable; }
            set
            {
                if(value == _targetMustBeShootable) return;
                _targetMustBeShootable = value;
                OnPropertyChanged();
            }
        }

        public bool NonPvpMode
        {
            get { return _nonPvpMode; }
            set
            {
                if(value == _nonPvpMode)return;
                _nonPvpMode = value;
                OnPropertyChanged();
            }
        }

        public bool AntiKs
        {
            get { return _antiKs; }
            set
            {
                if(value == _antiKs) return;
                _antiKs = value;
                OnPropertyChanged();
            }
        }

        public bool SyncSpellsWithAttacks
        {
            get { return _syncSpellsWithAttacks; }
            set
            {
                if(value==_syncSpellsWithAttacks) return;
                _syncSpellsWithAttacks = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
