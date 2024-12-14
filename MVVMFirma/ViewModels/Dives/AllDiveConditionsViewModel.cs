using System.Collections.ObjectModel;
using System.Linq;
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
        #endregion
    }
}
