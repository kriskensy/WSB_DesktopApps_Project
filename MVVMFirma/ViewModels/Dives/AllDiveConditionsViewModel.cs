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
