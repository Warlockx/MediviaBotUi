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

    public class Spell : INotifyPropertyChanged
    {
        private string _name;
        private string _formula;
        public string[] _vocationToCast;
        public string _group;
        public string _type;
        public string _cooldown;
        public string _groupCooldown;
        public int _minimunLevel;
        public int _manaCost;
        public int _priceToLearn;
        public string[] _citiesToLearn;
        public bool _premiumOnly;
        public int _soulPoints;
        public int _charges;
        public string _damageType;

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

        public string Group
        {
            get { return _group; }
            set
            {
                if (value == _group) return;
                _group = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Cooldown
        {
            get { return _cooldown; }
            set
            {
                if (value == _cooldown) return;
                _cooldown = value;
                OnPropertyChanged();
            }
        }

        public string GroupCooldown
        {
            get { return _groupCooldown; }
            set
            {
                if (value == _groupCooldown) return;
                _groupCooldown = value;
                OnPropertyChanged();
            }
        }

        public int MinimunLevel
        {
            get { return _minimunLevel; }
            set
            {
                if (value == _minimunLevel) return;
                _minimunLevel = value;
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

        public int PriceToLearn
        {
            get { return _priceToLearn; }
            set
            {
                if (value == _priceToLearn) return;
                _priceToLearn = value;
                OnPropertyChanged();
            }
        }

        public string[] CitiesToLearn
        {
            get { return _citiesToLearn; }
            set
            {
                if (value == _citiesToLearn) return;
                _citiesToLearn = value;
                OnPropertyChanged();
            }
        }

        public bool PremiumOnly
        {
            get { return _premiumOnly; }
            set
            {
                if (value == _premiumOnly) return;
                _premiumOnly = value;
                OnPropertyChanged();
            }
        }

        public int SoulPoints
        {
            get { return _soulPoints; }
            set
            {
                if (value == _soulPoints) return;
                _soulPoints = value;
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

        public string DamageType
        {
            get { return _damageType; }
            set
            {
                if (value == _damageType) return;
                _damageType = value;
                OnPropertyChanged();
            }
        }

        public Spell(string name, string formula, string[] vocationToCast, string group, string type, string cooldown, string groupCooldown, int minimunLevel, int manaCost, int priceToLearn, string[] citiesToLearn, bool premiumOnly, int soulPoints, int charges, string damageType)
        {
            Name = name;
            Formula = formula;
            VocationToCast = vocationToCast;
            Group = group;
            Type = type;
            Cooldown = cooldown;
            GroupCooldown = groupCooldown;
            MinimunLevel = minimunLevel;
            ManaCost = manaCost;
            PriceToLearn = priceToLearn;
            CitiesToLearn = citiesToLearn;
            PremiumOnly = premiumOnly;
            SoulPoints = soulPoints;
            Charges = charges;
            DamageType = damageType;
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

       

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
