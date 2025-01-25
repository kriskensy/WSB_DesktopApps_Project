using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SACconsumptionB : DataBaseClass
    {
        #region Constructor
        public SACconsumptionB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public decimal AverageDiveSAC(int idUser, DateTime dateFrom, DateTime dateTo)
        {
            return
                (
                from item in db.DiveStatistic
                where
                item.DiveLogs.IdUser == idUser &&
                item.DiveLogs.DiveDate >= dateFrom &&
                item.DiveLogs.DiveDate <= dateTo

                select item.AirConsumed * 10 / (item.DiveLogs.DiveDuration * (item.DiveLogs.MaxDepth + 1))
                ).Average();
        }

        //pobranie nurkowań do listy dla wykresu słupkowego
        public List<DiveLogsForAllView> GetDivesForUser(int idUser, DateTime dateFrom, DateTime dateTo)
        {

            return
                (
                from item in db.DiveLogs
                join statistic in db.DiveStatistic
                on item.IdDiveLog equals statistic.IdDiveLog
                where
                item.User.IdUser == idUser &&
                item.DiveDate >= dateFrom &&
                item.DiveDate <= dateTo
                orderby item.DiveDate
                select new DiveLogsForAllView 
                {
                    DiveDate = item.DiveDate, 
                    DiveDuration = item.DiveDuration,
                    MaxDepth = item.MaxDepth,
                    AirConsumed = statistic.AirConsumed //pole dodane do DiveLogsForAllView
                }
                ).ToList();
        }
        #endregion
    }
}
