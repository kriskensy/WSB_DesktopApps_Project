using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
                        ContactFirstName = emergencyContact.ContactFirstName,
                        ContactLastName = emergencyContact.ContactLastName,
                        Relationship = emergencyContact.Relationship,
                        PhoneNumber = emergencyContact.PhoneNumber,
                        Email = emergencyContact.Email
                    }
                );
        }

        public override void Delete(EmergencyContactsForAllView record)
        {
            var emergencyContactToDelete = (from item in diving4LifeEntities.EmergencyContacts
                                   where item.IdEmergencyContact == record.IdEmergencyContact
                                            select item
                                   ).SingleOrDefault();


            if (emergencyContactToDelete != null)
            {
                diving4LifeEntities.EmergencyContacts.Remove(emergencyContactToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
