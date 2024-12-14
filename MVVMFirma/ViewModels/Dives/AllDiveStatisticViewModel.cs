using System.Collections.ObjectModel;
using System.Linq;
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
        #endregion
    }
}
