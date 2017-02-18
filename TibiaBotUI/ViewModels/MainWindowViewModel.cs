using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using MahApps.Metro;
using TibiaBotUI.Commands;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Variables
     
        private string _windowTitle = "TibiaBotUi 0.1";
        private int _currentPage;
        private bool _activeMainMenu;

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                if (value == _windowTitle) return;
                _windowTitle = value;
                OnPropertyChanged();
            }
        }
      
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value == _currentPage) return;
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public bool ActiveMainMenu
        {
            get { return _activeMainMenu; }
            set
            {
                if (value == _activeMainMenu) return;
                _activeMainMenu = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand SwitchPage { get; set; }

        private bool _canSwitchPage(string arg)
        {
            int index = int.Parse(arg);
            return _currentPage != index;
        }

        private void _switchPage(string obj)
        {
            int index = int.Parse(obj);
            CurrentPage = index;
            ActiveMainMenu = false;
        }
      
        #endregion
        public MainWindowViewModel()
        {
            SwitchPage = new RelayCommand<string>(_switchPage,_canSwitchPage);
        }

        


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

    }
}
