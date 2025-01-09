using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
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
        }
        #endregion

        #region XXXXXXXXX Combobox
        //ewentualnie zamienić na okno modalne co lepiej pasuje
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
            diving4LifeEntities.EmergencyContacts.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                //uwaga! walidacja pól wybieranych przez FK powinna zaznaczać pola, w których nie zostało jeszcze coś wybrane
                //case nameof(IdUser):
                //    return Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdUser) ?
                //        "User cannot be empty" : string.Empty;
                case nameof(ContactFirstName):
                    return string.IsNullOrEmpty(ContactFirstName) ? "Contact Firstname cannot be empty" : string.Empty;
                case nameof(ContactLastName):
                    return string.IsNullOrEmpty(ContactLastName) ? "Contact Lastname cannot be empty" : string.Empty;
                case nameof(Relationship):
                    return string.IsNullOrEmpty(Relationship) ? "Relationship cannot be empty" : string.Empty;
                case nameof(PhoneNumber):
                    return Helper.Validators.StringValidator.ContainsPhoneNumber(PhoneNumber ?? string.Empty) ?
                        "Phonenumber can contains only numbers and  and be exactly 9 characters long" : string.Empty;
                case nameof(Email):
                    return Helper.Validators.StringValidator.ContainsEmailAddress(Email ?? string.Empty) ? 
                        "Email must cointain @ and domain" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
