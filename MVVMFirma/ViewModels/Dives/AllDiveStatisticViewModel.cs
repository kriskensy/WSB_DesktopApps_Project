using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveStatisticViewModel : AllViewModel<DiveStatisticForAllView>
    {
        #region Constructor
        public AllDiveStatisticViewModel()
            : base("Statistic")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Dive Date", "Air Consumed", "Ascent Rate", "Bottom Time" };
        }

        public override void Sort()
        {
            if (SortField == "Dive Date")
                List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.DiveDate));
            if (SortField == "Air Consumed")
                List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.AirConsumed));
            if (SortField == "Ascent Rate")
                List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.AscentRate));
            if (SortField == "Bottom Time")
                List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.BottomTime));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Air Consumed", "Ascent Rate", "Bottom Time" };
        }

        public override void Find()
        {

        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveStatisticForAllView>
                (
                    from diveStatistic in diving4LifeEntities.DiveStatistic
                    select new DiveStatisticForAllView
                    {
                        IdStatistic = diveStatistic.IdStatistic,
                        DiveDate = diveStatistic.DiveLogs.DiveDate,
                        AirConsumed = diveStatistic.AirConsumed,
                        AscentRate = diveStatistic.AscentRate,
                        BottomTime = diveStatistic.BottomTime
                    }
                );
        }

        public override void Delete(DiveStatisticForAllView record)
        {
            var statisticToDelete = (from item in diving4LifeEntities.DiveStatistic
                                     where item.IdStatistic == record.IdStatistic
                                     select item
                                   ).SingleOrDefault();


            if (statisticToDelete != null)
            {
                diving4LifeEntities.DiveStatistic.Remove(statisticToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
