using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.General
{
    public class NewEmergencyContactsViewModel : NewViewModel<EmergencyContacts>
    {
        #region Properties
        public int IdUser
        {
            get
            {
                return item.IdUser;
            }
            set
            {
                item.IdUser = value;
                OnPropertyChanged(() => IdUser);
            }
        }

        public string ContactFirstName
        {
            get
            {
                return item.ContactFirstName;
            }
            set
            {
                item.ContactFirstName = value;
                OnPropertyChanged(() => ContactFirstName);
            }
        }

        public string ContactLastName
        {
            get
            {
                return item.ContactLastName;
            }
            set
            {
                item.ContactLastName = value;
                OnPropertyChanged(() => ContactLastName);
            }
        }

        public string Relationship
        {
            get
            {
                return item.Relationship;
            }
            set
            {
                item.Relationship = value;
                OnPropertyChanged(() => Relationship);
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
        #endregion

        #region Constructor
        public NewEmergencyContactsViewModel()
            : base("Emergency Contact")
        {
            item = new EmergencyContacts();
        }
        #endregion

        #region XXXXXXXXX

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.EmergencyContacts.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
