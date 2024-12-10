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
    public class AllDiveLogsViewModel : AllViewModel<DiveLogsForAllView>
    {
        #region Constructor
        public AllDiveLogsViewModel()
            : base("Dive Log")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveLogsForAllView>
                (
                    from diveLog in diving4LifeEntities.DiveLogs
                    select new DiveLogsForAllView
                    {
                        IdDiveLog = diveLog.IdDiveLog,
                        UserFirstName = diveLog.User.FirstName,
                        UserLastName = diveLog.User.LastName,
                        DiveTypeName = diveLog.DiveTypes.TypeName,
                        SiteName = diveLog.DiveSites.SiteName,
                        SiteLocation = diveLog.DiveSites.Location,
                        DiveDate = diveLog.DiveDate,
                        DiveDuration = diveLog.DiveDuration,
                        MaxDepth = diveLog.MaxDepth
                    }
                );
        }
        #endregion
    }
}
