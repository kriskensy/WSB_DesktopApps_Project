using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region Constructor
        public AllViewModel(string displayName)
        {
            diving4LifeEntities = new Diving4LifeEntities1();
            base.DisplayName = displayName;
        }
        #endregion

        #region Helpers
        public abstract void Load();

        private void add()
        {
            //mess jest z biblio MVVMLight
            //pozwala na wysłanie komunikatu do innego obiektu. DisplayName to nazwa widoku
            //komunikat odbiera MainWindowModel, który otwiera okna
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
    }
}
