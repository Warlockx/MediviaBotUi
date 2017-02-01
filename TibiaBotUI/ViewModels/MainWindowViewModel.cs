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

namespace TibiaBotUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Variables
     
        private string _windowTitle = "Medivia Botter 0.0.1";
        private bool _cavebotEnabled;
        private int _currentPage;
        private WaypointType _waypointType = WaypointType.Stand;
        private WaypointDirection _waypointDirection = WaypointDirection.Center;
        private WaypointLocation _waypointLocation = new WaypointLocation(0, 0, 0, WaypointDirection.Center);
        private ObservableCollection<Waypoint> _waypointList = new ObservableCollection<Waypoint>();
        private bool _editingAction;
        private bool _activeMainMenu;
        private IHighlightingDefinition _highlightingDefinition;
        private string _textEditorForeground = "#FFFFFFFF";
        private bool _baseDarkTheme = true;
        private string _colorAccent = "Crimson";
        private string[] _colorAccents =
        {
            "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald", "Teal", "Cyan",
            "Cobalt", "Indigo", "Violet", "Pink", "Magenta", "Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel",
            "Mauve", "Taupe", "Sienna"
        };

        private int _xWaypointRange = 1;
        private int _yWaypointRange = 1;

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
      
        public bool CavebotEnabled
        {
            get { return _cavebotEnabled; }
            set
            {
                if (value == _cavebotEnabled) return;
                _cavebotEnabled = value;
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
        
        public WaypointType WaypointType
        {
            get { return _waypointType; }
            set
            {
                if(value == _waypointType) return;
                _waypointType = value;
                OnPropertyChanged();
            }
        }
       
        public WaypointDirection WaypointDirection
        {
            get { return _waypointDirection; }
            set
            {
                if (value == _waypointDirection) return;
                _waypointDirection = value;
                OnPropertyChanged();
            }
        }

        public WaypointLocation WaypointLocation
        {
            get { return _waypointLocation; }
            set
            {
                if(value == _waypointLocation) return;
                _waypointLocation = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Waypoint> WaypointList
        {
            get { return _waypointList; }
            set
            {
                if (value == _waypointList) return;
                _waypointList = value;
                OnPropertyChanged();
            }
        }
      
        public bool EditingAction
        {
            get { return _editingAction; }
            set
            {
                if(value == _editingAction) return;
                _editingAction = value;
                OnPropertyChanged();
            }
        }

        public bool ActiveMainMenu
        {
            get { return _activeMainMenu; }
            set
            {
                if(value == _activeMainMenu) return;
                _activeMainMenu = value;
                OnPropertyChanged();
            }
        }

        public IHighlightingDefinition HighlightingDefinition
        {
            get { return _highlightingDefinition; }
            set
            {
                if (value == _highlightingDefinition) return;
                _highlightingDefinition = value;
                OnPropertyChanged();
            }
        }

        public string TextEditorForeground
        {
            get { return _textEditorForeground; }
            set
            {
                if(value ==_textEditorForeground) return;
                _textEditorForeground = value;
                OnPropertyChanged();
            }
        }

        public bool BaseDarkTheme
        {
            get { return _baseDarkTheme; }
            set
            {
                if (value == _baseDarkTheme) return;
                _baseDarkTheme = value;
                string basetheme = value ? "BaseDark" : "BaseLight";
                TextEditorForeground = ThemeManager.GetAppTheme(basetheme).Resources["FlyoutForegroundBrush"].ToString();
                ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(_colorAccent),
                            ThemeManager.GetAppTheme(basetheme));
                OnPropertyChanged();
            }
        }

        public string ColorAccent
        {
            get { return _colorAccent; }
            set
            {
                if(value == _colorAccent) return;
                ThemeManager.ChangeAppStyle(Application.Current,
                             ThemeManager.GetAccent(value),
                             ThemeManager.GetAppTheme(_baseDarkTheme ? "BaseDark" : "BaseLight"));
                _colorAccent = value;
                OnPropertyChanged();
            }
        }

        public string[] ColorAccents
        {
            get { return _colorAccents; }
            set
            {
                if (value == _colorAccents) return;
               
                _colorAccents = value;
                OnPropertyChanged();
            }
        }

        public int XWaypointRange
        {
            get { return _xWaypointRange; }
            set
            {
                if (value == _xWaypointRange) return;
                _xWaypointRange = value;
                OnPropertyChanged();
            }
        }

        public int YWaypointRange
        {
            get { return _yWaypointRange; }
            set
            {
                if (value == _xWaypointRange) return;
                _xWaypointRange = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand SwitchPage { get; set; }
        public ICommand AddWaypoint { get; set; }
        public ICommand EditWaypointAction { get; set; }

        private bool _canSwitchPage(object arg)
        {
            int index = int.Parse((string)arg);
            return _currentPage != index;
        }

        private void _switchPage(object obj)
        {
            int index = int.Parse((string)obj);
            CurrentPage = index;
            ActiveMainMenu = false;
        }
      
        private bool _canAddWaypoint(object arg)
        {
            return _waypointLocation != null;
        }

        private void _addWaypoint(object obj)
        {
            //mock
            WaypointList.Add(new Waypoint(WaypointList.Count,WaypointType,XWaypointRange,YWaypointRange,"",WaypointLocation.AddOffset(WaypointDirection), "auto(50000,80000)\r\nlocal current = getself().dir \r\nlocal next = current + 1 \r\nif next >= 4 then \r\nnext = 0 \r\nend \r\nturn(next) \r\nwait(500,700) \r\nturn(current)"));
        }

        private bool _canEditWaypointAction(object arg)
        {
            Waypoint waypoint = (Waypoint) arg;
            return waypoint?.Type == WaypointType.Action;
        }

        private void _editWaypointAction(object obj)
        {
            EditingAction = true;
        }

        private void LoadLuaSyntaxHighlight()
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("TibiaBotUI.LuaDark.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    HighlightingDefinition = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }
        #endregion
        public MainWindowViewModel()
        {
            LoadLuaSyntaxHighlight();
            SwitchPage = new RelayCommand(_switchPage,_canSwitchPage);
            AddWaypoint = new RelayCommand(_addWaypoint,_canAddWaypoint);
            EditWaypointAction = new RelayCommand(_editWaypointAction,_canEditWaypointAction);
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
