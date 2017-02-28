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
        private TargetingConfiguration _targetingConfiguration = new TargetingConfiguration();
        private ObservableCollection<TargetingTemplate> _targetingTemplates;
        private ObservableCollection<Monster> _monsters;
        private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
        public ICommand AddSpell { get; set; }
        public ICommand RemoveSpell { get; set; }

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

        public TargetingConfiguration Configuration
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
      
        public TargetingViewModel()
        {
            LoadMonsters();
            LoadSpells();
            AddSpell = new RelayCommand<TargetingConfiguration>(Configuration.AddSpell,Configuration.CanAddSpell);
            RemoveSpell = new RelayCommand<Spell>(Configuration.RemoveSpell, Configuration.CanRemoveSpell);
        }

        #region commands

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
