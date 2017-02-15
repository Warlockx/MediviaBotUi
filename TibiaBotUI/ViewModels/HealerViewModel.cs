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
using TibiaBotUI.Commands;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class HealerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private ObservableCollection<HealItem> _healItems = new ObservableCollection<HealItem>();
        private ObservableCollection<HealerRule> _spellHealerRules = new ObservableCollection<HealerRule>();
        private ObservableCollection<HealerRule> _itemHealerRules = new ObservableCollection<HealerRule>();
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
        public ObservableCollection<HealItem> HealItems
        {
            get { return _healItems; }
            set
            {
                if (value == _healItems) return;
                _healItems = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<HealerRule> SpellHealerRules
        {
            get
            {
                return _spellHealerRules;
            }
            set
            {
                if (value == _spellHealerRules) return;
                _spellHealerRules = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<HealerRule> ItemHealerRules
        {
            get
            {
                return _itemHealerRules;
            }

            set
            {
                if (value == _itemHealerRules) return;
                _itemHealerRules = value;
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
            AddRule = new RelayCommand(_addRule, _canAddRule);
            DeleteRule = new RelayCommand(_deleteRule,_canDeleteRule);
            Spells = new ObservableCollection<Spell>(SpellListProviderService.LoadSpells(SpellGroup.Healing));
            HealItems.Add(new HealItem("test item", 0));
            CurrentHealerRule = new HealerRule("", null,null, 0, 0, 0, HealerConditions.Hitpoints, 500, 700);
          
        }

        private bool _canDeleteRule(object arg)
        {
            HealerRule rule = (HealerRule)arg;
            return rule != null;
        }

        private void _deleteRule(object obj)
        {
            HealerRule rule = (HealerRule) obj;
            if (_spellHealerRules.Any(r => r.Equals(rule)))
                SpellHealerRules.Remove(rule);
            else
                ItemHealerRules.Remove(rule);
        }

        private bool _canAddRule(object arg)
        {
            return true; //check binds later
        }

        private void _addRule(object obj)
        {
            if ((string) obj == "Spell")
            {
                SpellHealerRules.Add(new HealerRule("", CurrentHealerRule.Spell,null,
                    CurrentHealerRule.MinTrigger,
                    CurrentHealerRule.MaxTrigger, CurrentHealerRule.Priority, CurrentHealerRule.Condition,
                    CurrentHealerRule.MinSpamRate, CurrentHealerRule.MaxSpamRate));
            }
            else
            {
                ItemHealerRules.Add(new HealerRule("", null, CurrentHealerRule.HealItem,
                   CurrentHealerRule.MinTrigger,
                   CurrentHealerRule.MaxTrigger, CurrentHealerRule.Priority, CurrentHealerRule.Condition,
                   CurrentHealerRule.MinSpamRate, CurrentHealerRule.MaxSpamRate));
            }
            CurrentHealerRule =  new HealerRule("", null, null, 0, 0, 0, HealerConditions.Hitpoints, 500, 700);
        }

        public event PropertyChangedEventHandler PropertyChanged;

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
