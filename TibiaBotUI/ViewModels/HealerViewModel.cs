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
        public ICommand ChangePriority { get; set; }
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
        public CollectionViewSource SpellHealerRulesViewSource { get; set; } = new CollectionViewSource();
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
        public CollectionViewSource ItemHealerRulesViewSource { get; set; } = new CollectionViewSource();

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
            _loadCollections();
            _prepareViewSources();
            _loadCommands();
            CurrentHealerRule = new HealerRule("", Spells.First(),HealItems.First(), 0, 110, 0, HealerConditions.Hitpoints, 500, 700);
        }

        #region commands
        private void _prepareViewSources()
        {
            SpellHealerRulesViewSource.Source = SpellHealerRules;
            SpellHealerRulesViewSource.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Ascending));
            ItemHealerRulesViewSource.Source = ItemHealerRules;
            ItemHealerRulesViewSource.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Ascending));
        }

        private void _loadCommands()
        {
            AddRule = new RelayCommand<string>(_addRule, _canAddRule);
            DeleteRule = new RelayCommand<HealerRule>(_deleteRule, _canDeleteRule);
            ChangePriority = new RelayCommand<HealerRule>(_changePriority, _canChangePriority);
        }

        private void _loadCollections()
        {
            Spells = new ObservableCollection<Spell>(SpellListProviderService.LoadSpells(SpellGroup.Healing));
            HealItems.Add(new HealItem("test item", 0));
        }

        private bool _canChangePriority(HealerRule arg)
        {
            return true;
        }

        private void _changePriority(HealerRule obj)
        {
            HealerRule duplicatedPriorityItem;
            int max;
            bool increaseValue;
            if (SpellHealerRules.Any(r => r.Equals(obj)))
            {
                max = SpellHealerRules.Count - 1;
                if (obj.Priority > max)
                    obj.Priority = max;

                duplicatedPriorityItem =
                    SpellHealerRules.FirstOrDefault(r => !r.Equals(obj) && r.Priority == obj.Priority);
                increaseValue = SpellHealerRules.Any(r => r.Priority == obj.Priority + 1) || duplicatedPriorityItem?.Priority >= max;
            }
            else
            {
                max = ItemHealerRules.Count - 1;
                if (obj.Priority > max)
                    obj.Priority = max;

                duplicatedPriorityItem =
                    ItemHealerRules.FirstOrDefault(r => !r.Equals(obj) && r.Priority == obj.Priority);
                increaseValue = ItemHealerRules.Any(r => r.Priority == obj.Priority + 1) || duplicatedPriorityItem?.Priority >= max;
            }

            if (duplicatedPriorityItem == null) return;

            duplicatedPriorityItem.Priority = increaseValue ? obj.Priority - 1 : obj.Priority + 1;
        }

        private bool _canDeleteRule(HealerRule arg)
        {
            return arg != null;
        }

        private void _deleteRule(HealerRule obj)
        {
            if (_spellHealerRules.Any(r => r.Equals(obj)))
            {
                SpellHealerRules.Where(r => r.Priority > obj.Priority).ToList().ForEach(r=> r.Priority--);
                SpellHealerRules.Remove(obj);
            }
            else
            {
                ItemHealerRules.Where(r => r.Priority > obj.Priority).ToList().ForEach(r => r.Priority--);
                ItemHealerRules.Remove(obj);
            }
        }

        private bool _canAddRule(string arg)
        {
            return true; //check binds later
        }

        private void _addRule(string obj)
        {
            string condition = CurrentHealerRule.Condition.ToString();
            if (!condition.Contains("Hitpoint") &&
                !condition.Contains("Mana"))
            {
                CurrentHealerRule.MinTrigger = null;
                CurrentHealerRule.MaxTrigger = null;
            }

            if (obj == "Spell")
            {
                if (CurrentHealerRule.Priority > SpellHealerRules.Count)
                    CurrentHealerRule.Priority = SpellHealerRules.Count;

                CurrentHealerRule.HealItem = null;

                SpellHealerRules.Add(CurrentHealerRule);
                CurrentHealerRule = new HealerRule("", CurrentHealerRule.Spell, CurrentHealerRule.HealItem, 0, 110,
                    SpellHealerRules.Count, HealerConditions.Hitpoints, 500, 700);
            }
            else
            {
                if (CurrentHealerRule.Priority > ItemHealerRules.Count)
                    CurrentHealerRule.Priority = ItemHealerRules.Count;

                CurrentHealerRule.Spell = null;
                ItemHealerRules.Add(CurrentHealerRule);
                CurrentHealerRule = new HealerRule("", CurrentHealerRule.Spell, CurrentHealerRule.HealItem, 0, 110,
                    ItemHealerRules.Count, HealerConditions.Hitpoints, 500, 700);
            }

        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
