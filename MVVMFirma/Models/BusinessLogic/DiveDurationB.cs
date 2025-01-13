using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DiveDurationB : DataBaseClass
    {
        #region Constructor
        public DiveDurationB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public int DiveDurationFromTo(int idUser, DateTime dateFrom, DateTime dateTo)
        {
            return
                (
                from item in db.DiveLogs
                where
                item.User.IdUser == idUser &&
                item.DiveDate >= dateFrom &&
                item.DiveDate <= dateTo
                select item.DiveDuration
                ).Sum();
        }
        #endregion
    }
}
