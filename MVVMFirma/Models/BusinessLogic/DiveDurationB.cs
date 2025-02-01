using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
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
        //sumowanie wszystkich minut
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
                ).DefaultIfEmpty(0).Sum(); //dodany default na 0 jeśli nie ma wartości
        }

        //pobranie nurkowań do listy dla wykresu słupkowego
        public List<DiveLogsForAllView> GetDivesForUser(int idUser, DateTime dateFrom, DateTime dateTo)
        {
            
            return
                (
                from item in db.DiveLogs
                where
                item.User.IdUser == idUser &&
                item.DiveDate >= dateFrom &&
                item.DiveDate <= dateTo
                orderby item.DiveDate
                select new DiveLogsForAllView { DiveDate = item.DiveDate, DiveDuration = item.DiveDuration }
                ).ToList();
        }
        #endregion
    }
}
