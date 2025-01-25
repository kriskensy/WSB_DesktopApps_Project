using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveTypesViewModel : NewViewModel<DiveTypes>
    {
        #region Properties
        public string TypeName
        {
            get
            {
                return item.TypeName;
            }
            set
            {
                item.TypeName = value;
                OnPropertyChanged(() => TypeName);
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
        public NewDiveTypesViewModel()
            : base("Dive Type", false)
        {
            item = new DiveTypes();
            diving4LifeEntities.DiveTypes.Add(item);
        }

        public NewDiveTypesViewModel(int idDiveType)
            : base("Dive Type", true)
        {
            item = diving4LifeEntities.DiveTypes.Find(idDiveType);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllDiveTypesViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(TypeName):
                    return string.IsNullOrEmpty(TypeName) ? "Type name cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
