using MVVMFirma.Models.Entities;
using System.Xml.Linq;

namespace MVVMFirma.ViewModels.General
{
    public class NewBuddysViewModel : NewViewModel<BuddySystem>
    {
        #region Properties
        public string BuddyFirstName
        {
            get
            {
                return item.BuddyFirstName;
            }
            set
            {
                item.BuddyFirstName = value;
                OnPropertyChanged(() => BuddyFirstName);
            }
        }

        public string BuddyLastName
        {
            get
            {
                return item.BuddyLastName;
            }
            set
            {
                item.BuddyLastName = value;
                OnPropertyChanged(() => BuddyLastName);
            }
        }

        public string CertificationLevel
        {
            get
            {
                return item.CertificationLevel;
            }
            set
            {
                item.CertificationLevel = value;
                OnPropertyChanged(() => CertificationLevel);
            }
        }

        public string ContactDetails
        {
            get
            {
                return item.ContactDetails;
            }
            set
            {
                item.ContactDetails = value;
                OnPropertyChanged(() => ContactDetails);
            }
        }

        #endregion

        #region Constructor
        public NewBuddysViewModel()
            : base("Buddy")
        {
            item = new BuddySystem();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.BuddySystem.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(BuddyFirstName):
                    return string.IsNullOrEmpty(BuddyFirstName) ? "Buddy Firstname cannot be empty" : string.Empty;
                case nameof(BuddyLastName):
                    return string.IsNullOrEmpty(BuddyLastName) ? "Buddy Lastname number cannot be empty" : string.Empty;
                case nameof(CertificationLevel):
                    return string.IsNullOrEmpty(CertificationLevel) ? "Certification level cannot be empty" : string.Empty;
                case nameof(ContactDetails):
                    return string.IsNullOrEmpty(ContactDetails) ? "Contact details cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
