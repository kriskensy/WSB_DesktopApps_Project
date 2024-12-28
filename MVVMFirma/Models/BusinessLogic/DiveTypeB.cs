using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DiveTypeB : DataBaseClass
    {
        #region Constructor
        public DiveTypeB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IEnumerable<KeyAndValue> GetDiveTypesKeyAndValueItems()
        {
            return
                (
                    from diveType in db.DiveTypes
                    select new KeyAndValue
                    {
                        Key = diveType.IdDiveType,
                        Value = diveType.TypeName
                    }
                ).ToList();
        }
        #endregion
    }
}
