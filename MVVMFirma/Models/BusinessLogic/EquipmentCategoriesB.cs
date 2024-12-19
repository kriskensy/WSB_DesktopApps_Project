using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class EquipmentCategoriesB : DataBaseClass
    {
        #region Constructor
        public EquipmentCategoriesB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValue> GetEquipmentCategoriesKeyAndValueItems()
        {
            return
                (
                    from equipmentCategory in db.EquipmentCategories
                    select new KeyAndValue
                    {
                        Key = equipmentCategory.IdCategory,
                        Value = equipmentCategory.CategoryName
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
