using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro;
using TibiaBotUI.Models;

namespace TibiaBotUI.Services
{
    public static class ThemingService
    {
        public static void UpdateTheme(ThemeAccents accent, ThemeBaseColors baseColor)
        {
            ThemeManager.ChangeAppStyle(Application.Current,
                          ThemeManager.GetAccent(accent.ToString()),
                          ThemeManager.GetAppTheme(baseColor.ToString()));
        }
    }
}
