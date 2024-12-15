using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveSitesViewModel : AllViewModel<DiveSitesForAllView>
    {

        #region Constructor
        public AllDiveSitesViewModel()
            : base("Dive Sites") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveSitesForAllView>
                (
                    from diveSites in diving4LifeEntities.DiveSites
                    select new DiveSitesForAllView
                    {
                        IdDiveSite = diveSites.IdDiveSite,
                        SiteName = diveSites.SiteName,
                        Location = diveSites.Location,
                        Description = diveSites.Description,
                    }
                );
        }
        #endregion
    }
}
