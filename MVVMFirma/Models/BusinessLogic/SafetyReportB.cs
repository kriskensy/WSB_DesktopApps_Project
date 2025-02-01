using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SafetyReportB : DataBaseClass
    {
        #region Constructor
        public SafetyReportB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public decimal AverageAscentRate(int idUser, DateTime dateFrom, DateTime dateTo)
        {
            return (
                from item in db.DiveStatistic
                where
                item.DiveLogs.IdUser == idUser &&
                item.DiveLogs.DiveDate >= dateFrom &&
                item.DiveLogs.DiveDate <= dateTo
                select item.AscentRate
            ).DefaultIfEmpty(0).Average(); //dodany default na 0 jeśli nie ma wartości
        }

        public int CountOverSpeedDives(int idUser, DateTime dateFrom, DateTime dateTo, double ascentRateThreshold = 9.0) //prawdziwa wratość
        {
            return (
                from item in db.DiveStatistic
                where
                item.DiveLogs.IdUser == idUser &&
                item.DiveLogs.DiveDate >= dateFrom &&
                item.DiveLogs.DiveDate <= dateTo &&
                (double)item.AscentRate > ascentRateThreshold //konieczne rzutowanie do double
                select item
            ).Count();
        }

        public List<DiveLogsForAllView> GetDivesForUser(int idUser, DateTime dateFrom, DateTime dateTo)
        {
            return (
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
                    AscentRate = statistic.AscentRate
                }
            ).ToList();
        }
        #endregion
    }
}
