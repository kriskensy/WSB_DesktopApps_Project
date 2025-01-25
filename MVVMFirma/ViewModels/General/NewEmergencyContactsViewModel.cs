using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Certifications;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            : base("Emergency Contact", false)
        {
            item = new EmergencyContacts();
            diving4LifeEntities.EmergencyContacts.Add(item);
        }

        public NewEmergencyContactsViewModel(int idEmergencyContact)
            : base("Emergency Contact", true)
        {
            item = diving4LifeEntities.EmergencyContacts.Find(idEmergencyContact);
        }
        #endregion

        #region Combobox
        public IEnumerable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(diving4LifeEntities).GetUsersKeyAndValueItems();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllEmergencyContactsViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(IdUser):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdUser) ?
                        "User cannot be empty" : string.Empty;
                case nameof(ContactFirstName):
                    return string.IsNullOrEmpty(ContactFirstName) ? "Contact Firstname cannot be empty" : string.Empty;
                case nameof(ContactLastName):
                    return string.IsNullOrEmpty(ContactLastName) ? "Contact Lastname cannot be empty" : string.Empty;
                case nameof(Relationship):
                    return string.IsNullOrEmpty(Relationship) ? "Relationship cannot be empty" : string.Empty;
                case nameof(PhoneNumber):
                    return !Helper.Validators.StringValidator.ContainsPhoneNumber(PhoneNumber ?? string.Empty) ?
                        "Phonenumber can contains only numbers and be exactly 9 characters long" : string.Empty;
                case nameof(Email):
                    return !Helper.Validators.StringValidator.ContainsEmailAddress(Email ?? string.Empty) ? 
                        "Email must contain @ and domain" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
