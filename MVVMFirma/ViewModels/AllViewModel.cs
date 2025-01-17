using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class AllViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly Diving4LifeEntities1 diving4LifeEntities;
        #endregion

        #region Commands
        private BaseCommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }

        private BaseCommand _AddCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }

        }

        private BaseCommand _EditCommand;

        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                    _EditCommand = new BaseCommand(() => editRecord(), () => IsRecordSelected);
                return _EditCommand;
            }
        }

        private BaseCommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                    _DeleteCommand = new BaseCommand(() => deleteRecord(), () => IsRecordSelected);
                return _DeleteCommand;
            }
        }
        #endregion

        #region List
        private ObservableCollection<T> _List;

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion

        #region Sorting and Filtering
        public string SortField { get; set; }

        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }

        public abstract List<string> GetComboboxSortList();

        private BaseCommand _SortCommand;

        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }

        public abstract void Sort();

        public string FindField { get; set; }

        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }

        public abstract List<string> GetComboboxFindList();

        public string FindTextBox { get; set; }

        private BaseCommand _FindCommand;

        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }

        public abstract void Find();

        #endregion

        #region Constructor
        public AllViewModel(string displayName)
        {
            diving4LifeEntities = new Diving4LifeEntities1();
            base.DisplayName = displayName;
            //IsDarkMode = false; //tryb jasny TODO: jak ustawiam tą flagę to mi wywala aplikację przy przełączaniu zakładek
        }
        #endregion

        #region Properties
        //ten props przetrzymuje informację kto zażądał otwarcia zakładki
        public object WhoRequestedToSelectElement { get; set; }

        private BaseCommand _SwitchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_SwitchThemeCommand == null)
                    _SwitchThemeCommand = new BaseCommand(() => switchTheme());
                return _SwitchThemeCommand;
            }

        }

        private void switchTheme()
        {
            MessageBox.Show("SwitchThemeCommand triggered!");
            Messenger.Default.Send("ChangeTheme");
        }


        //private bool _isDarkMode; //TODO: skasować

        //public bool IsDarkMode
        //{
        //    get => _isDarkMode;
        //    set
        //    {
        //        _isDarkMode = value;
        //        OnPropertyChanged(() => IsDarkMode); //info dla widoku o zmianie
        //        ThemeManager.ChangeTheme(_isDarkMode ? "Dark" : "Light"); //zmiana
        //    }
        //}
        #endregion

        #region Helpers
        public abstract void Load();

        private void add()
        {
            //mess jest z biblio MVVMLight
            //pozwala na wysłanie komunikatu do innego obiektu. DisplayName to nazwa widoku
            //komunikat odbiera MainWindowModel, który otwiera okna
            Messenger.Default.Send(new AddMessage { MessageName = DisplayName + "Add" });
        }

        private void editRecord() //TODO: napisać implementację
        {
            if (SelectedRecord != null)
                Messenger.Default.Send(DisplayName + "Edit", SelectedRecord);
        }

        public abstract void Delete(T record);
        private void deleteRecord()
        {
            if (SelectedRecord == null)
                return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Delete Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Delete(SelectedRecord);
                    Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while deleting record: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private T _SelectedRecord;
        public T SelectedRecord
        {
            get => _SelectedRecord;
            set
            {
                _SelectedRecord = value;
                OnPropertyChanged(() => SelectedRecord);
                OnPropertyChanged(() => IsRecordSelected); //aktualizacja przycisków
                CommandManager.InvalidateRequerySuggested(); //odświeżanie komend edit, delete
                //Console.WriteLine($"SelectedRecord set to: {_SelectedRecord}"); //pomoc przy debugowaniu
            }
        }

        public bool IsRecordSelected //sprawdza czy jakiś rekord jest wybrany
        {
            get
            {
                return SelectedRecord != null;
            }
        }

        //private void switchTheme()
        //{
        //    Messenger.Default.Send("ChangeTheme");
        //}
        #endregion
    }
}
