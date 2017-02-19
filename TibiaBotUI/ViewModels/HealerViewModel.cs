using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        private HealerService _healerService;
        private string _addButtonText = "ü";
        private string _addButtonTooltip = "Add";
        private bool _editingRule;

        public ICommand AddRule { get; set; }
        public ICommand DeleteRule { get; set; }
        public ICommand EditRule { get; set; }
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

        public string AddButtonText
        {
            get { return _addButtonText; }
            set
            {
                if (value == _addButtonText) return;
                _addButtonText = value;
                OnPropertyChanged();
            }
        }

        public string AddButtonTooltip
        {
            get { return _addButtonTooltip; }
            set
            {
                if (value == _addButtonTooltip) return;
                _addButtonTooltip = value;
                OnPropertyChanged();
            }
        }

        public bool EditingRule
        {
            get { return _editingRule; }
            set
            {
                if(value == _editingRule) return;
                _editingRule = value;
                OnPropertyChanged();
            }
        }


        public HealerViewModel()
        {
            _loadCollections();
            _prepareViewSources();
            _loadCommands();
            CurrentHealerRule = new HealerRule(0,"", Spells.First(),HealItems.First(), 0, 110, 0, HealerConditions.Hitpoints, 500, 700, false,false,true);
            _healerService = new HealerService(this);
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
            EditRule = new RelayCommand<HealerRule>(_editRule, _canEditRule);
            ChangePriority = new RelayCommand<HealerRule>(_changePriority, _canChangePriority);
        }

        private bool _canEditRule(HealerRule arg)
        {
            return arg != null;
        }

        private void _editRule(HealerRule obj)
        {
            EditingRule = true;
            AddButtonText = "<";
            AddButtonTooltip = "Save";
            CurrentHealerRule = obj;
        }

        private void _loadCollections()
        {
            Spells = new ObservableCollection<Spell>(SpellListProviderService.LoadSpells(SpellGroup.Healing));
            HealItems = new ObservableCollection<HealItem>(HealItemListProviderService.LoadHealItems());
        }

        private bool _canChangePriority(HealerRule arg)
        {
            return true;
        }

        private void _changePriority(HealerRule obj)
        {
            if (obj == null) return;
            ObservableCollection<HealerRule> collection = SpellHealerRules.Any(r=> r.Equals(obj)) ? SpellHealerRules : ItemHealerRules;

            //fix priority
            int max = collection.Count - 1;
            if (obj.Priority > max)
                obj.Priority = max;

            //finds the item where the priority is the same as current item
            HealerRule oldPriorityItem = collection.FirstOrDefault(r => !r.Equals(obj) && r.Priority == obj.Priority);
            //checks if the olditem is the last based on priority or if the olditem.Priority is bigger than the currentItem 
            bool increaseValue =  oldPriorityItem?.Priority >= max || collection.Any(r => r.Priority == obj.Priority + 1);

            //checks if there
            if (oldPriorityItem == null) return;
            oldPriorityItem.Priority = increaseValue ? obj.Priority - 1 : obj.Priority + 1;
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
            return SpellHealerRules != null || ItemHealerRules != null;
        }

        private void _addRule(string obj)
        {
            //check which collection to use
            ObservableCollection<HealerRule> collection = obj == "Spell" ? SpellHealerRules : ItemHealerRules;
            CollectionViewSource viewSource =  obj == "Spell" ? SpellHealerRulesViewSource : ItemHealerRulesViewSource;
            //correct priority
            if (CurrentHealerRule.Priority > collection.Count)
                CurrentHealerRule.Priority = collection.Count;

            //remove triggers if its not a range trigger
            string condition = CurrentHealerRule.Condition.ToString();
            if (!condition.Contains("Hitpoint") &&
                !condition.Contains("Mana"))
            {
                CurrentHealerRule.MinTrigger = null;
                CurrentHealerRule.MaxTrigger = null;
                CurrentHealerRule.TriggerSplitter = "";
                CurrentHealerRule.TriggerDecoration = "";
            }
            else
            {
                CurrentHealerRule.MinTrigger = CurrentHealerRule.MinTrigger ?? 0;
                CurrentHealerRule.MaxTrigger = CurrentHealerRule.MaxTrigger ?? 100;
                CurrentHealerRule.TriggerSplitter =  "~";
                CurrentHealerRule.TriggerDecoration = condition.Contains("Percent") ? "%" : "";
            }


            //check if the rule exists already based on id
            HealerRule ruleChecker = collection.FirstOrDefault(r => r.Equals(CurrentHealerRule));
            if (ruleChecker == null)
            {
                //fix priority if its being added in the middle
                collection.Where(r => r.Priority >= CurrentHealerRule.Priority).ToList().ForEach(r => r.Priority++);
                collection.Add(CurrentHealerRule);
            }


            viewSource.View.Refresh();
            CurrentHealerRule = new HealerRule(collection.Count, "", Spells.First(), HealItems.First(), 0, 110,
                collection.Count, HealerConditions.Hitpoints, 500, 700, false, false, true);

            AddButtonText = "ü";
            AddButtonTooltip = "Add";
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
