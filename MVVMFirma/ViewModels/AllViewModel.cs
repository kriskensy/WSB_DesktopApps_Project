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
        protected readonly Diving4LifeEntities diving4LifeEntities;
        #endregion

        #region LoadCommand
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
        public AllViewModel(String displayName)
        {
            diving4LifeEntities = new Diving4LifeEntities();
            base.DisplayName = displayName;
        }
        #endregion

        #region Helpers
        public abstract void Load();
        #endregion
    }
}
