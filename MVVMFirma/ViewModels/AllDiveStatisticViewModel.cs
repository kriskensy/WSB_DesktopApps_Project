using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
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
