using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MediviaBotUI.Commands;

namespace MediviaBotUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Variables
     
        private string _windowTitle = "MediviaBotUi 0.1";
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
