using MVVMFirma.Models.Entities;
using System;

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

        #region XXXXXXXXX

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.Equipment.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
