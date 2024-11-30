using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewEquipmentManufacturerViewModel : NewViewModel<EquipmentManufacturer>
    {
        #region Constructor
        public NewEquipmentManufacturerViewModel()
            : base("EQ Manufacturer")
        {
            item = new EquipmentManufacturer();
        }
        #endregion

        #region Properties
        public String ManufacturerName
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

        public String Country
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

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.EquipmentManufacturer.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
