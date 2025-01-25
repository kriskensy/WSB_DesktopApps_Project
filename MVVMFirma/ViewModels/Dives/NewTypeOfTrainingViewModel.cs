using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;

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
            : base("Training Type", false)
        {
            item = new TypeOfTraining();
            diving4LifeEntities.TypeOfTraining.Add(item);
        }

        public NewTypeOfTrainingViewModel(int idTrainigType)
            : base("Training Type", true)
        {
            item = diving4LifeEntities.TypeOfTraining.Find(idTrainigType);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllTypeOfTrainingViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(TrainingName):
                    return string.IsNullOrEmpty(TrainingName) ? "Training name cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
