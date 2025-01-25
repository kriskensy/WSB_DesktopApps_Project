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

            //usuwanie aktualnych słowników
            var themeDictionaries = application.Resources.MergedDictionaries
                .Where(d => d.Source != null &&
                            (d.Source.OriginalString.Contains("Colors.xaml") ||
                             d.Source.OriginalString.Contains("DarkColors.xaml")))
                .ToList();

            foreach (var dictionary in themeDictionaries)
            {
                application.Resources.MergedDictionaries.Remove(dictionary);
            }

            //dodanie nowego słownika
            if (theme == "Light")
            {
                Console.WriteLine("Loading Light Theme...");
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("Themes/Styles/Colors.xaml", UriKind.Relative) });
            }
            else if (theme == "Dark")
            {
                Console.WriteLine("Loading Dark Theme...");
                application.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = new Uri("Themes/Styles/DarkColors.xaml", UriKind.Relative) });
            }
        }
    }
}
