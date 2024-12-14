using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveSitesViewModel : AllViewModel<DiveSites>
    {

        #region Constructor
        public AllDiveSitesViewModel()
            : base("Dive Sites") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveSites>
                (
                    diving4LifeEntities.DiveSites.ToList()
                );
        }
        #endregion
    }
}
