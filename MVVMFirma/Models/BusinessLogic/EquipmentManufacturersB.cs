using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class EquipmentManufacturersB : DataBaseClass
    {
        #region Constructor
        public EquipmentManufacturersB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValue> GetManufacturersKeyAndValueItems()
        {
            return
                (
                    from manufacturer in db.EquipmentManufacturer
                    select new KeyAndValue
                    {
                        Key = manufacturer.IdManufacturer,
                        Value = manufacturer.ManufacturerName
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
