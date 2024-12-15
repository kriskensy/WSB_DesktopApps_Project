using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentCategoriesViewModel : AllViewModel<EquipmentCategoriesForAllView>
    {
        #region Constructor
        public AllEquipmentCategoriesViewModel()
            : base("EQ Categories") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentCategoriesForAllView>
                (
                    from equipmentCategories in diving4LifeEntities.EquipmentCategories
                    select new EquipmentCategoriesForAllView
                    {
                        IdCategory = equipmentCategories.IdCategory,
                        CategoryName = equipmentCategories.CategoryName,
                    }
                );
        }
        #endregion
    }
}
