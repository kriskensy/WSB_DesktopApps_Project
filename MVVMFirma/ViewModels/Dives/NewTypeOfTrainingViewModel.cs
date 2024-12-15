using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewTypeOfTrainingViewModel : NewViewModel<TypeOfTraining>
    {
        #region Properties
        public string TrainingName
        {
            get
            {
                return item.TrainingName;
            }
            set
            {
                item.TrainingName = value;
                OnPropertyChanged(() => TrainingName);
            }
        }

        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }
        #endregion

        #region Constructor
        public NewTypeOfTrainingViewModel()
            : base("Training Type")
        {
            item = new TypeOfTraining();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.TypeOfTraining.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
