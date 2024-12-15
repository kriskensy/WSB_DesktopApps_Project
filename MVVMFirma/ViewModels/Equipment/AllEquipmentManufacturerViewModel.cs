using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentManufacturerViewModel : AllViewModel<EquipmentManufacturerForAllView>
    {
        #region Constructor
        public AllEquipmentManufacturerViewModel()
            : base("EQ Manufacturer") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentManufacturerForAllView>
                (
                    from equipmentManufacturer in diving4LifeEntities.EquipmentManufacturer
                    select new EquipmentManufacturerForAllView
                    {
                        IdManufacturer = equipmentManufacturer.IdManufacturer,
                        ManufacturerName = equipmentManufacturer.ManufacturerName,
                        Country = equipmentManufacturer.Country,
                    }
                );
        }
        #endregion
    }
}
