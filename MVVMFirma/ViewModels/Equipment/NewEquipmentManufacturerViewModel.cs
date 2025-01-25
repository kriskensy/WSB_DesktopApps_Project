using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;
using System.Windows;

namespace MVVMFirma.ViewModels.Equipment
{
    public class NewEquipmentManufacturerViewModel : NewViewModel<EquipmentManufacturer>
    {
        #region Properties
        public string ManufacturerName
        {
            get
            {
                return item.ManufacturerName;
            }
            set
            {
                item.ManufacturerName = value;
                OnPropertyChanged(() => ManufacturerName);
            }
        }

        public string Country
        {
            get
            {
                return item.Country;
            }
            set
            {
                item.Country = value;
                OnPropertyChanged(() => Country);
            }
        }
        #endregion

        #region Constructor
        public NewEquipmentManufacturerViewModel()
            : base("Manufacturer", false)
        {
            item = new EquipmentManufacturer();
            diving4LifeEntities.EquipmentManufacturer.Add(item);
        }

        public NewEquipmentManufacturerViewModel(int idManufacturer)
            : base("Manufacturer", true)
        {
            item = diving4LifeEntities.EquipmentManufacturer.Find(idManufacturer);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllEquipmentManufacturerViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(ManufacturerName):
                    return string.IsNullOrEmpty(ManufacturerName) ? "Manufacturer name cannot be empty" : string.Empty;
                case nameof(Country):
                    return string.IsNullOrEmpty(Country) ? "Country cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
