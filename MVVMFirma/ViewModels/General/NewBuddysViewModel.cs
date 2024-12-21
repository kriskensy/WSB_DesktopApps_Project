using MVVMFirma.Models.Entities;

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
    }
}
