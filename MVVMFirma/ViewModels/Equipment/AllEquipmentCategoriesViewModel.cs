using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentCategoriesViewModel : AllViewModel<EquipmentCategories>
    {
        #region Constructor
        public AllEquipmentCategoriesViewModel()
            : base("EQ Categories") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentCategories>
                (
                    diving4LifeEntities.EquipmentCategories.ToList()
                );
        }
        #endregion
    }
}
