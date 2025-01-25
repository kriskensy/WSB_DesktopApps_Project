using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;

namespace MVVMFirma.ViewModels.General
{
    public class NewUsersViewModel : NewViewModel<User>
    {
        #region Properties
        public string FirstName
        {
            get
            {
                return item.FirstName;
            }
            set
            {
                item.FirstName = value;
                OnPropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return item.LastName;
            }
            set
            {
                item.LastName = value;
                OnPropertyChanged(() => LastName);
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return item.PhoneNumber;
            }
            set
            {
                item.PhoneNumber = value;
                OnPropertyChanged(() => PhoneNumber);
            }
        }

        #endregion

        #region Constructor
        public NewUsersViewModel()
            : base("User", false)
        {
            item = new User();
            diving4LifeEntities.User.Add(item);
        }

        public NewUsersViewModel(int idUser)
            : base("User", true)
        {
            item = diving4LifeEntities.User.Find(idUser);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllUsersViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    return string.IsNullOrEmpty(FirstName) ? "Firstname cannot be empty" : string.Empty;
                case nameof(LastName):
                    return string.IsNullOrEmpty(LastName) ? "Lastname cannot be empty" : string.Empty;
                case nameof(Email):
                    return !Helper.Validators.StringValidator.ContainsEmailAddress(Email ?? string.Empty) ?
                        "Email must cointain @ and domain" : string.Empty;
                case nameof(PhoneNumber):
                    return !Helper.Validators.StringValidator.ContainsPhoneNumber(PhoneNumber ?? string.Empty) ?
                        "Phonenumber can contains only numbers and  and be exactly 9 characters long" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
