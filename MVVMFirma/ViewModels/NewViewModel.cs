using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class NewViewModel<T> : WorkspaceViewModel, IDataErrorInfo
    {
        #region DB
        protected Diving4LifeEntities1 diving4LifeEntities;
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
                    //_SaveCommand = new BaseCommand(() => SaveAndClose());
                    _SaveCommand = new BaseCommand(() => ValidateAndSave());
                return _SaveCommand;
            }
        }

        #endregion

        #region Constructor
        public NewViewModel(string displayName)
        {
            base.DisplayName = displayName;
            diving4LifeEntities = new Diving4LifeEntities1();
        }
        #endregion

        #region Helpers
        protected bool IsValid()
        {
            foreach (System.Reflection.PropertyInfo item in this.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(ValidateProperty(item.Name)))
                {
                    return false;
                }
            }
            return true;
        }

        public string Error => string.Empty;

        //tą metodę (Property) implementuję w każdej klasie. gdzie będą walidowane dane
        //public string this[string columnName] => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                return ValidateProperty(columnName);
            }
        }

        protected virtual string ValidateProperty(string propertyName)
        {
            return string.Empty;
        }

        private void ValidateAndSave()
        {
            try
            {
                if (IsValid())
                {
                    SaveAndClose();
                }
                else
                {
                    MessageBox.Show("Invalid data. Cannot save.", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Writting in databank impossible.", "Error");
            }
        }

        public abstract void Save();
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zamknięcie zakładki
        }
        #endregion
    }
}
