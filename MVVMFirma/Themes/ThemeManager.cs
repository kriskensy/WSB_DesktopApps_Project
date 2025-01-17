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
        //public static void ChangeTheme(string theme)
        //{
        //    Messenger.Default.Register<string>("ChangeTheme", switchTheme);
        //    var application = Application.Current;

        //    application.Resources.MergedDictionaries.Clear(); //czyści aktualny styl

        //    if (theme == "Light")
        //    {
        //        application.Resources.MergedDictionaries.Add(
        //            new ResourceDictionary { Source = new Uri("Colors.xaml", UriKind.Relative) });
        //    }
        //    if (theme == "Dark")
        //    {
        //        application.Resources.MergedDictionaries.Add(
        //            new ResourceDictionary { Source = new Uri("DarkColors.xaml", UriKind.Relative) });
        //    }
        //}


        static ThemeManager()
        {
            Messenger.Default.Register<string>(null, "ChangeTheme", _ => SwitchTheme());
        }

        private static bool _isDarkMode = false;

        public static void SwitchTheme()
        {
            _isDarkMode = !_isDarkMode;
            var application = Application.Current;

            application.Resources.MergedDictionaries.Clear(); //czyści aktualny styl

            application.Resources.MergedDictionaries.Add(
                new ResourceDictionary
                {
                    Source = new Uri(_isDarkMode ? "DarkColors.xaml" : "Colors.xaml", UriKind.Relative)
                });
        }


    }
}
