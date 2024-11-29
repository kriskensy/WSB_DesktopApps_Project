using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
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
