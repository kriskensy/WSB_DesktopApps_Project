using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
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
                        UserFirstName = equipment.User.FirstName,
                        UserLastName = equipment.User.LastName,
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
