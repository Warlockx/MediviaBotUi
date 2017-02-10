using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class HealerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private ObservableCollection<HealerRule> _healerRules = new ObservableCollection<HealerRule>();
        private string _currentRuleName;
        private Spell _currentRuleSpell;
        private int _currentRuleMinTrigger;
        private int _currentRuleMaxTrigger;
        private int _currentRulePriority;

        public ObservableCollection<Spell> Spells
        {
            get { return _spells; }
            set
            {
                if(value.Equals(_spells)) return;
                _spells = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<HealerRule> HealerRules
        {
            get
            {
                return _healerRules;
            }

            set
            {
                if (value == _healerRules) return;
                _healerRules = value;
                OnPropertyChanged();
            }
        }

        public string CurrentRuleName
        {
            get { return _currentRuleName; }
            set
            {
                if (value == _currentRuleName) return;
                _currentRuleName = value;
                OnPropertyChanged();
            }
        }

        public Spell CurrentRuleSpell
        {
            get
            {
                return _currentRuleSpell;
            }

            set
            {
                if(value == _currentRuleSpell) return;
                _currentRuleSpell = value;
                OnPropertyChanged();
            }
        }

        public int CurrentRuleMinTrigger
        {
            get
            {
                return _currentRuleMinTrigger;
            }

            set
            {
                if (value == _currentRuleMinTrigger) return;
                _currentRuleMinTrigger = value;
                OnPropertyChanged();
            }
        }

        public int CurrentRuleMaxTrigger
        {
            get
            {
                return _currentRuleMaxTrigger;
            }

            set
            {
                if (value == _currentRuleMaxTrigger) return;
                _currentRuleMaxTrigger = value;
                OnPropertyChanged();
            }
        }

        public int CurrentRulePriority
        {
            get
            {
                return _currentRulePriority;
            }

            set
            {
                if (value == _currentRulePriority) return;
                _currentRulePriority = value;
                OnPropertyChanged();
            }
        }


        public HealerViewModel()
        {
            Spells = new ObservableCollection<Spell>(SpellListProviderService.LoadSpells(SpellGroup.Healing));
            HealerRules.Add(new HealerRule("test", Spells?.First(),"hppc >=", 50, 50,1));
            HealerRules.Add(new HealerRule("test", Spells?.Last(), "hppc >=", 50, 50, 2));
            HealerRules.Add(new HealerRule("test", Spells?.First(), "hppc >=", 50, 50, 3));
        }

        public event PropertyChangedEventHandler PropertyChanged;

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
