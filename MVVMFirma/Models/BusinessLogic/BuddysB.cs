using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class BuddysB : DataBaseClass
    {
        #region Constructor
        public BuddysB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IEnumerable<KeyAndValue> GetBuddysKeyAndValueItems()
        {
            return
                (
                    from buddy in db.BuddySystem
                    select new KeyAndValue
                    {
                        Key = buddy.IdBuddy,
                        Value = buddy.BuddyFirstName + " " + buddy.BuddyLastName
                    }
                ).ToList();
        }
        #endregion
    }
}
