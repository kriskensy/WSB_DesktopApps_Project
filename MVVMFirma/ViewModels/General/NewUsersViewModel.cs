﻿using MVVMFirma.Models.Entities;

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
            : base("User")
        {
            item = new User();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.User.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    return string.IsNullOrEmpty(FirstName) ? "First name cannot be empty" : string.Empty;
                case nameof(LastName):
                    return string.IsNullOrEmpty(LastName) ? "Last name cannot be empty" : string.Empty;
                case nameof(Email):
                    return string.IsNullOrEmpty(Email) ? "Email name cannot be empty" : string.Empty;
                //case nameof(PhoneNumber):
                //    return string.IsNullOrEmpty(PhoneNumber) ? "Phone number name cannot be empty" : string.Empty;
                case nameof(PhoneNumber):
                    return !Helper.Validators.StringValidator.ContainsOnlyNumbers(PhoneNumber ?? string.Empty) ? "Phonenumber can contains only numbers" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
