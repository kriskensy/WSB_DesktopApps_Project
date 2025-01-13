using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SACconsumptionB:DataBaseClass
    {
        #region Constructor
        public SACconsumptionB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        //#region Business Functions
        //public decimal SingleDiveSACconsumption(int idUser, decimal airConsumed, int diveDuration, decimal maxDepth)
        //{
        //    return
        //        (
        //            from item in db.DiveLogs
        //            where
        //            item.IdUser == idUser
        //            select new
        //            {
        //            item.DiveStatistic.AirConsumed,
        //            item.DiveDuration,
        //            item.MaxDepth
        //            }
        //        ).ToList();
        //}

        //public decimal TotalDiveSACconsumption(int idUser, decimal airConsumed, int diveDuration, decimal maxDepth)
        //{
        //    return
        //        (
        //            from item in db.DiveLogs
        //            where
        //            item.IdUser == idUser
        //            select new
        //            {
        //                item.DiveStatistic.AirConsumed,
        //                item.DiveDuration,
        //                item.MaxDepth
        //            }
        //        ).ToList();
        //}
        //#endregion
    }
}
