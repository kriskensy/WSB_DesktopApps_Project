using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
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
            : base("Equipment")
        {
            item = new Models.Entities.Equipment();
            PurchaseDate = DateTime.Now;
        }


        #endregion

        #region XXXXXXXXX Combobox
        //ewentualnie zamienić na okno modalne co lepiej pasuje
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
            diving4LifeEntities.Equipment.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Name):
                    return string.IsNullOrEmpty(Name) ? "Name cannot be empty" : string.Empty;
                case nameof(SerialNumber):
                    return string.IsNullOrEmpty(SerialNumber) ? "Serial number cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
