using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.General
{
    public class AllEmergencyContactsViewModel : AllViewModel<EmergencyContactsForAllView>
    {
        #region Constructor
        public AllEmergencyContactsViewModel()
            : base("Emergency Contact")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EmergencyContactsForAllView>
                (
                    from emergencyContact in diving4LifeEntities.EmergencyContacts
                    select new EmergencyContactsForAllView
                    {
                        IdEmergencyContact = emergencyContact.IdEmergencyContact,
                        UserFirstName = emergencyContact.User.FirstName,
                        UserLastName = emergencyContact.User.LastName,
                        ContactName = emergencyContact.ContactName,
                        Relationship = emergencyContact.Relationship,
                        PhoneNumber = emergencyContact.PhoneNumber,
                        Email = emergencyContact.Email
                    }
                );
        }
        #endregion
    }
}
