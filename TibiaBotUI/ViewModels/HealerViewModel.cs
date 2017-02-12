using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TibiaBotUI.Commands;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class HealerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private ObservableCollection<HealerRule> _healerRules = new ObservableCollection<HealerRule>();
        private HealerRule _currentHealerRule;
        private bool _healerEnabled;
        private int _currentHealerTab;

        public ICommand AddRule { get; set; }
        public ICommand DeleteRule { get; set; }
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
      
        public bool HealerEnabled
        {
            get { return _healerEnabled; }
            set
            {
                if(value == _healerEnabled) return;
                _healerEnabled = value;
                OnPropertyChanged();
            }
        }

        public int CurrentHealerTab
        {
            get { return _currentHealerTab; }
            set
            {
                if (value == _currentHealerTab) return;
                _currentHealerTab = value;
                OnPropertyChanged();
            }
        }

        public HealerRule CurrentHealerRule
        {
            get { return _currentHealerRule; }
            set
            {
                if(value == _currentHealerRule) return;
                _currentHealerRule = value;
                OnPropertyChanged();
            }
        }

        public HealerViewModel()
        {
            AddRule = new RelayCommand(_addrule,_canAddRule);
            DeleteRule = new RelayCommand(_deleteRule,_canDeleteRule);
            Spells = new ObservableCollection<Spell>(SpellListProviderService.LoadSpells(SpellGroup.Healing));
            CurrentHealerRule = new HealerRule("", Spells.First(), 0, 0, 0, HealerConditions.Hitpoints, 500, 700);
        }

        private bool _canDeleteRule(object arg)
        {
            HealerRule rule = (HealerRule)arg;
            return rule != null;
        }

        private void _deleteRule(object obj)
        {
            HealerRule rule = (HealerRule) obj;
            _healerRules.Remove(rule);           
        }

        private bool _canAddRule(object arg)
        {
            return true; //check binds later
        }

        private void _addrule(object obj)
        {
            HealerRules.Add(new HealerRule("", CurrentHealerRule.Spell, CurrentHealerRule.MinTrigger,
                CurrentHealerRule.MaxTrigger, CurrentHealerRule.Priority, CurrentHealerRule.Condition, CurrentHealerRule.MinSpamRate,CurrentHealerRule.MaxSpamRate));
        }

        public event PropertyChangedEventHandler PropertyChanged;

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
