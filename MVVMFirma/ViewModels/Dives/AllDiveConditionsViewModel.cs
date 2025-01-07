using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveConditionsViewModel : AllViewModel<DiveConditionsForAllView>
    {
        #region Constructor
        public AllDiveConditionsViewModel()
            : base("Dive Conditions")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Dive Date", "Temperature", "Water Current", "Visibility" };
        }

        public override void Sort()
        {
            if (SortField == "Dive Date")
                List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.DiveDate));
            if (SortField == "Temperature")
                List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.Temperature));
            if (SortField == "Water Current")
                List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.WaterCurrent));
            if (SortField == "Visibility")
                List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.Visibility));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Water Current", "Visibility", "Notes" };
        }

        public override void Find()
        {

        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveConditionsForAllView>
                (
                    from diveCondition in diving4LifeEntities.DiveConditions
                    select new DiveConditionsForAllView
                    {
                        IdCondition = diveCondition.IdCondition,
                        DiveDate = diveCondition.DiveLogs.DiveDate,
                        Temperature = diveCondition.Temperature,
                        WaterCurrent = diveCondition.WaterCurrent,
                        Visibility = diveCondition.Visibility,
                        Notes = diveCondition.Notes
                    }
                );
        }

        public override void Delete(DiveConditionsForAllView record)
        {
            var diveConditionToDelete = (from item in diving4LifeEntities.DiveConditions
                                         where item.IdCondition == record.IdCondition
                                         select item
                                   ).SingleOrDefault();


            if (diveConditionToDelete != null)
            {
                diving4LifeEntities.DiveConditions.Remove(diveConditionToDelete);
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
