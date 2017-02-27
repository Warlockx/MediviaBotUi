using System.Windows;
using MahApps.Metro;
using MediviaBotUI.Models;

namespace MediviaBotUI.Services
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
