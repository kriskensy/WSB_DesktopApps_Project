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
        #region Fields
        private bool EditRecord;
        #endregion

        #region DB
        protected Diving4LifeEntities1 diving4LifeEntities;
        #endregion

        #region Item
        protected T item;
        #endregion

        #region Command
        //komenda, która jest podpięta pod button "Save and close" i wywoła funkcję ValidateAndSave
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

        private BaseCommand _CancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                    _CancelCommand = new BaseCommand(() => CancelAndClose());
                return _CancelCommand;
            }
        }

        #endregion

        #region Constructor
        public NewViewModel(string displayName, bool editRecord)
        {
            base.DisplayName = displayName;
            EditRecord = editRecord;
            diving4LifeEntities = new Diving4LifeEntities1();
        }
        #endregion

        #region Helpers
        protected bool IsValid()
        {
            foreach (System.Reflection.PropertyInfo item in this.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(ValidateProperty(item.Name)))
                    return false;
            }
            return true;
        }

        //TODO: tutaj moja metoda sprawdzająca. Pomysł aby sprawdzać każdą właściwość osobno
        //protected bool IsValid()
        //{
        //    foreach (System.Reflection.PropertyInfo item in this.GetType().GetProperties())
        //    {
        //        var value = item.GetValue(this);

        //        //sprawdzenie ogólne
        //        if (!string.IsNullOrEmpty(ValidateProperty(item.Name)))
        //            return false;

        //        //sprawdzenie czy props jest DateTime - jeśli tak to walidacja
        //        if (item.PropertyType == typeof(DateTime?) || item.PropertyType == typeof(DateTime))
        //        {
        //            if (!string.IsNullOrEmpty(ValidateDateTime(value as DateTime?, item.Name)))
        //                return false;
        //        }

        //        //sprawdzenie czy props jest "zwykłym" int - jeśli tak to walidacja
        //        if (item.PropertyType == typeof(int?) && !item.Name.StartsWith("Id"))
        //        {
        //            if (!string.IsNullOrEmpty(ValidateInt(value as int?, item.Name)))
        //                return false;
        //        }

        //        //sprawdzenie czy props jest FK (int) - jeśli tak to walidacja
        //        if (item.PropertyType == typeof(int?) && item.Name.StartsWith("Id"))
        //        {
        //            if (!string.IsNullOrEmpty(ValidateForeignKey(value as int?, item.Name)))
        //                return false;
        //        }
        //    }
        //    return true;
        //}

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

        protected virtual string ValidateDateTime(DateTime? value, string propertyName)
        {
            //if (!value.HasValue || value.Value > DateTime.Now)
            //    MessageBox.Show($"{propertyName} is incorrect.", "Error");
            return string.Empty;
        }

        protected virtual string ValidateInt(int? value, string propertyName)
        {
            //if (!value.HasValue || value <= 0)
            //    MessageBox.Show($"{propertyName} is incorrect.", "Error");
            return string.Empty;
        }

        protected virtual string ValidateForeignKey(int? value, string propertyName)
        {
            //if (!value.HasValue || value <= 0)
            //    MessageBox.Show($"Foreign key {propertyName} is incorrect.", "Error");
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

        public void CancelAndClose()
        {
            base.OnRequestClose();
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
