using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class AppConfigurationViewModel : INotifyPropertyChanged
    {
        private IHighlightingDefinition _highlightingDefinition;
        private ThemeBaseColors _baseTheme = ThemeBaseColors.BaseDark;
        private ThemeAccents _themeAccent = ThemeAccents.Crimson;


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

        public ThemeBaseColors BaseTheme
        {
            get { return _baseTheme; }
            set
            {
                if (value == _baseTheme) return;
                _baseTheme = value;
                ThemingService.UpdateTheme(ThemeAccent, BaseTheme);
                OnPropertyChanged();
            }
        }

        public ThemeAccents ThemeAccent
        {
            get { return _themeAccent; }
            set
            {
                if (value == _themeAccent) return;
                _themeAccent = value;
                ThemingService.UpdateTheme(ThemeAccent, BaseTheme);
                OnPropertyChanged();
            }
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

        public AppConfigurationViewModel()
        {
            LoadLuaSyntaxHighlight();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
