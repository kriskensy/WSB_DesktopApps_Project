using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class EquipmentB : DataBaseClass
    {
        #region Constructor
        public EquipmentB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValue> GetEquipmentKeyAndValueItems()
        {
            return
                (
                    from equipment in db.Equipment
                    select new KeyAndValue
                    {
                        Key = equipment.IdEquipment,
                        Value = equipment.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
