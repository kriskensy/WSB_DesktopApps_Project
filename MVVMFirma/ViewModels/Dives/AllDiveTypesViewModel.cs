using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveTypesViewModel : AllViewModel<DiveTypes>
    {
        #region Constructor
        public AllDiveTypesViewModel()
            : base("Dive Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveTypes>
                (
                    diving4LifeEntities.DiveTypes.ToList()
                );
        }
        #endregion
    }
}
