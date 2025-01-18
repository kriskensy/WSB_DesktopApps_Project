using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.Themes
{
    public static class ThemeManager
    {
        public static void SwitchTheme(string theme)
        {
            var application = Application.Current;

            application.Resources.MergedDictionaries.Clear(); //czyści aktualny styl

            if (theme == "Light")
            {
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("Themes/Styles/Colors.xaml", UriKind.Relative) });
            }
            if (theme == "Dark")
            {
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("Themes/Styles/DarkColors.xaml", UriKind.Relative) });
            }
        }
    }
}
