using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentManufacturerViewModel : AllViewModel<EquipmentManufacturer>
    {
        #region Constructor
        public AllEquipmentManufacturerViewModel()
            : base("EQ Manufacturer") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentManufacturer>
                (
                    diving4LifeEntities.EquipmentManufacturer.ToList()
                );
        }
        #endregion
    }
}
