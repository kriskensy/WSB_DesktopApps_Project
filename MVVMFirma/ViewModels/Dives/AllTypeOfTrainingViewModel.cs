using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllTypeOfTrainingViewModel : AllViewModel<TypeOfTraining>
    {
        #region Constructor
        public AllTypeOfTrainingViewModel()
            : base ("Training Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypeOfTraining>
                (
                diving4LifeEntities.TypeOfTraining.ToList()
                );
        }
        #endregion
    }
}
