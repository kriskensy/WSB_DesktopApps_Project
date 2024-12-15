using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveTypesViewModel : AllViewModel<DiveTypesForAllView>
    {
        #region Constructor
        public AllDiveTypesViewModel()
            : base("Dive Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveTypesForAllView>
                (
                    from diveType in diving4LifeEntities.DiveTypes
                    select new DiveTypesForAllView
                    {
                        IdDiveType = diveType.IdDiveType,
                        TypeName = diveType.TypeName,
                        Description = diveType.Description,
                    }
                );
        }
        #endregion
    }
}
