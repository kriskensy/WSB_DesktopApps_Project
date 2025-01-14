using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMFirma.Themes
{
    public static class ThemeManager
    {
        public static void ChangeTheme(string theme)
        {
            var application = Application.Current;

            application.Resources.MergedDictionaries.Clear(); //czyści aktualny styl

            if (theme == "Light")
            {
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("Colors.xaml", UriKind.Relative) });
            }
            if (theme == "Dark")
            {
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("DarkColors.xaml", UriKind.Relative) });
            }
        }


    }
}
