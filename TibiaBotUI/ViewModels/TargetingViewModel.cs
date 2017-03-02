using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediviaBotUI.Commands;
using MediviaBotUI.Models;
using MediviaBotUI.Services;

namespace MediviaBotUI.ViewModels
{
    public class TargetingViewModel : INotifyPropertyChanged
    {
        private bool _targetingEnabled;
        private TargetingSetting _currentSetting = new TargetingSetting();
        private ObservableCollection<TargetingTemplate> _targetingTemplates;
        private ObservableCollection<Monster> _monsters;
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private ObservableCollection<TargetingSetting> _settings = new ObservableCollection<TargetingSetting>();
        private TargetingPriorities _priorities = new TargetingPriorities();
        private string _addButtonText = "ü";
        private string _addButtonTooltip = "Add";

        public ICommand AddRule { get; set; }
        public ICommand RemoveRule { get; set; }
        public ICommand EditRule { get; set; }

        public bool TargetingEnabled
        {
            get { return _targetingEnabled; }
            set
            {
                if (value == _targetingEnabled) return;
                _targetingEnabled = value;
                OnPropertyChanged();
            }
        }

        public TargetingSetting CurrentSetting
        {
            get { return _currentSetting; }
            set
            {
                if(value == _currentSetting) return;
                _currentSetting = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TargetingTemplate> TargetingTemplates
        {
            get
            {
                return _targetingTemplates;
            }

            set
            {
                if (value == TargetingTemplates) return;
                _targetingTemplates = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Monster> Monsters
        {
            get { return _monsters; }
            set
            {
                if(value == _monsters) return;
                _monsters = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Spell> Spells
        {
            get { return _spells; }
            set
            {
                if(value == _spells) return;
                _spells = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TargetingSetting> Settings
        {
            get { return _settings; }
            set
            {
                if(value == _settings) return;
                _settings = value;
                OnPropertyChanged();
            }
        }

        public TargetingPriorities Priorities
        {
            get { return _priorities; }
            set
            {
                if(value == _priorities) return;
                _priorities = value;
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
                if (value == _addButtonText) return;
                _addButtonTooltip = value;
                OnPropertyChanged();
            }
        }

        public TargetingViewModel()
        {
            LoadCommands();
            LoadMonsters();
            LoadSpells();
        }

        #region commands

        private void LoadCommands()
        {
            AddRule = new RelayCommand<TargetingSetting>(_addRule,_canAddRule);
            RemoveRule = new RelayCommand<TargetingSetting>(_removeRule, _canRemoveRule);
            EditRule = new RelayCommand<TargetingSetting>(_editRule, _canEditRule);
        }

        private bool _canEditRule(TargetingSetting arg)
        {
            return arg != null;
        }

        private void _editRule(TargetingSetting obj)
        {
            AddButtonText = "<";
            AddButtonTooltip = "Save";
            CurrentSetting = obj;
        }

        private bool _canRemoveRule(TargetingSetting arg)
        {
            return arg != null;
        }

        private void _removeRule(TargetingSetting obj)
        {
            if (obj != null)
             Settings.Remove(obj);
        }

        private bool _canAddRule(TargetingSetting arg)
        {
            return CurrentSetting.IsValid();
        }

        private void _addRule(TargetingSetting obj)
        {
            if(Settings.All(s => !s.Equals(CurrentSetting)))
                Settings.Add(CurrentSetting);

            AddButtonText = "ü";
            AddButtonTooltip = "Add";
            CurrentSetting = new TargetingSetting();
        }

        private void LoadMonsters()
        {
            Monsters = new ObservableCollection<Monster>(MonsterListProvider.LoadMonsters());
        }

        private void LoadSpells()
        {
            Spells =  new ObservableCollection<Spell>(SpellListProvider.LoadSpells("Attack"));
            CurrentSetting.CurrentSpell = Spells.FirstOrDefault();
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
