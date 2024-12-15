using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllTypeOfTrainingViewModel : AllViewModel<TypeOfTrainingForAllView>
    {
        #region Constructor
        public AllTypeOfTrainingViewModel()
            : base ("Training Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypeOfTrainingForAllView>
                (
                    from typeOfTraining in diving4LifeEntities.TypeOfTraining
                    select new TypeOfTrainingForAllView
                    {
                        IdTypeOfTraining = typeOfTraining.IdTypeOfTraining,
                        TrainingName = typeOfTraining.TrainingName,
                        Description = typeOfTraining.Description,
                    }
                );
        }
        #endregion
    }
}
