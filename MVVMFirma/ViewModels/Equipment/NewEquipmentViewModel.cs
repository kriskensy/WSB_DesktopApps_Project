using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Certifications;
using MVVMFirma.Views.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MVVMFirma.ViewModels.Equipment
{
    public class NewEquipmentViewModel : NewViewModel<Models.Entities.Equipment>
    {
        #region Properties
        public int IdUser
        {
            get
            {
                return item.IdUser;
            }
            set
            {
                item.IdUser = value;
                OnPropertyChanged(() => IdUser);
            }
        }

        public int IdCategory
        {
            get
            {
                return item.IdCategory;
            }
            set
            {
                item.IdCategory = value;
                OnPropertyChanged(() => IdCategory);
            }
        }

        public int IdManufacturer
        {
            get
            {
                return item.IdManufacturer;
            }
            set
            {
                item.IdManufacturer = value;
                OnPropertyChanged(() => IdManufacturer);
            }
        }

        public string Name
        {
            get
            {
                return item.Name;
            }
            set
            {
                item.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string SerialNumber
        {
            get
            {
                return item.SerialNumber;
            }
            set
            {
                item.SerialNumber = value;
                OnPropertyChanged(() => SerialNumber);
            }
        }

        public DateTime PurchaseDate
        {
            get
            {
                return item.PurchaseDate;
            }
            set
            {
                item.PurchaseDate = value;
                OnPropertyChanged(() => PurchaseDate);
            }
        }
        #endregion

        #region Constructor
        public NewEquipmentViewModel()
            : base("Equipment", false)
        {
            item = new Models.Entities.Equipment();
            PurchaseDate = DateTime.Now;
            diving4LifeEntities.Equipment.Add(item);
        }

        public NewEquipmentViewModel(int idEquipment)
            : base("Equipment", true)
        {
            item = diving4LifeEntities.Equipment.Find(idEquipment);
        }
        #endregion

        #region Combobox
        public IEnumerable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(diving4LifeEntities).GetUsersKeyAndValueItems();
            }
        }

        public IEnumerable<KeyAndValue> EquipmentCategoriesItems
        {
            get
            {
                return new EquipmentCategoriesB(diving4LifeEntities).GetEquipmentCategoriesKeyAndValueItems();
            }
        }

        public IEnumerable<KeyAndValue> EquipmentManufacturersItems
        {
            get
            {
                return new EquipmentManufacturersB(diving4LifeEntities).GetManufacturersKeyAndValueItems();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllEquipmentViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(IdUser):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdUser) ?
                    "User cannot be empty" : string.Empty;
                case nameof(IdCategory):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdCategory) ?
                    "Category cannot be empty" : string.Empty;
                case nameof(IdManufacturer):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdManufacturer) ?
                    "Manufacturer cannot be empty" : string.Empty;
                case nameof(Name):
                    return string.IsNullOrEmpty(Name) ? "Equipment name cannot be empty" : string.Empty;
                case nameof(SerialNumber):
                    return string.IsNullOrEmpty(SerialNumber) ? "Serial number cannot be empty" : string.Empty;
                case nameof(PurchaseDate):
                    return !Helper.Validators.DateTimeValidator.IsNotFutureDate(PurchaseDate) ?
                    "Purchase date cannot be empty or in the future" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
