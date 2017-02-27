using System.ComponentModel;
using System.Runtime.CompilerServices;
using MediviaBotUI.Properties;

namespace MediviaBotUI.Models
{

    public class Spell : INotifyPropertyChanged
    {
        private string _name;
        private string _formula;
        private string[] _vocationToCast;
        private int _castMagicLevel;
        private int _useMagicLevel;
        private int _manaCost;
        private bool _needsPremium;
        private int _charges;
        private string _type;

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

        public string Formula
        {
            get { return _formula; }
            set
            {
                if (value == _formula) return;
                _formula = value;
                OnPropertyChanged();
            }
        }

        public string[] VocationToCast
        {
            get { return _vocationToCast; }
            set
            {
                if (value == _vocationToCast) return;
                _vocationToCast = value;
                OnPropertyChanged();
            }
        }

        public int CastMagicLevel
        {
            get { return _manaCost; }
            set
            {
                if (value == _castMagicLevel) return;
                _castMagicLevel = value;
                OnPropertyChanged();
            }
        }

        public int UseMagicLevel
        {
            get { return _useMagicLevel; }
            set
            {
                if (value == _useMagicLevel) return;
                _useMagicLevel = value;
                OnPropertyChanged();
            }
        }

        public int ManaCost
        {
            get { return _manaCost; }
            set
            {
                if (value == _manaCost) return;
                _manaCost = value;
                OnPropertyChanged();
            }
        }

        public bool NeedsPremium
        {
            get { return _needsPremium; }
            set
            {
                if (value == _needsPremium) return;
                _needsPremium = value;
                OnPropertyChanged();
            }
        }
    
        public int Charges
        {
            get { return _charges; }
            set
            {
                if (value == _charges) return;
                _charges = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if(value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

       

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
