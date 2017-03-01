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
        private TargetingSetting _targetingConfiguration = new TargetingSetting();
        private ObservableCollection<TargetingTemplate> _targetingTemplates;
        private ObservableCollection<Monster> _monsters;
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        private ObservableCollection<TargetingSetting> _settings = new ObservableCollection<TargetingSetting>();
     

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

        public TargetingSetting Configuration
        {
            get { return _targetingConfiguration; }
            set
            {
                if(value == _targetingConfiguration) return;
                _targetingConfiguration = value;
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

        public TargetingViewModel()
        {
            LoadMonsters();
            LoadSpells();
        }

        #region commands

        private void LoadCommands()
        {
        }
        private void LoadMonsters()
        {
            Monsters = new ObservableCollection<Monster>(MonsterListProvider.LoadMonsters());
        }

        private void LoadSpells()
        {
            Spells =  new ObservableCollection<Spell>(SpellListProvider.LoadSpells("Attack"));
            Configuration.CurrentSpell = Spells.FirstOrDefault();
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
