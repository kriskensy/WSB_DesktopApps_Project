using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DiveLogsB:DataBaseClass
    {
        #region Constructor
        public DiveLogsB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValueForDate> GetDiveLogsKeyAndValueItems()
        {
            return
                (
                    from diveLog in db.DiveLogs
                    select new KeyAndValueForDate
                    {
                        Key = diveLog.IdDiveLog,
                        Value = diveLog.DiveDate
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
