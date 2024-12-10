using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class AllEquipmentViewModel : AllViewModel<EquipmentForAllView>
    {
        #region Constructor
        public AllEquipmentViewModel()
            : base("Equipment")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentForAllView>
                (
                    from equipment in diving4LifeEntities.Equipment
                    select new EquipmentForAllView
                    {
                        IdEquipment = equipment.IdEquipment,
                        CategoryName = equipment.EquipmentCategories.CategoryName,
                        ManufacturerName = equipment.EquipmentManufacturer.ManufacturerName,
                        EquipmentName = equipment.Name,
                        SerialNumber = equipment.SerialNumber,
                        PurchaseDate = equipment.PurchaseDate
                    }
                );
        }
        #endregion
    }
}
