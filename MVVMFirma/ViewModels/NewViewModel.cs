using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class NewViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected Diving4LifeEntities diving4LifeEntities;
        #endregion

        #region Item
        protected T item;
        #endregion

        #region Command
        //komenda, która jest podpięta pod button "Save and close" i wywoła funkcję SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion

        #region Constructor
        public NewViewModel(string displayName)
        {
            base.DisplayName = displayName;
            diving4LifeEntities = new Diving4LifeEntities();
        }
        #endregion

        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zamknięcie zakładki
        }
        #endregion
    }
}
