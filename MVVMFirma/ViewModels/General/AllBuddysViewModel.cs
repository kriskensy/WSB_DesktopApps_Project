using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.General
{
    public class AllBuddysViewModel : AllViewModel<BuddySystemForAllView>
    {
        #region Constructor
        public AllBuddysViewModel()
            : base("Buddys")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<BuddySystemForAllView>
                (
                    from buddy in diving4LifeEntities.BuddySystem
                    select new BuddySystemForAllView
                    {
                        IdBuddy = buddy.IdBuddy,
                        BuddyFirstName = buddy.BuddyFirstName,
                        BuddyLastName = buddy.BuddyLastName,
                        CertificationLevel = buddy.CertificationLevel,
                        ContactDetails = buddy.ContactDetails
                    }
                );
        }

        public override void Delete(BuddySystemForAllView record)
        {
            var buddyToDelete = (from item in diving4LifeEntities.BuddySystem
                                 where item.IdBuddy == record.IdBuddy
                                 select item
                                   ).SingleOrDefault();


            if (buddyToDelete != null)
            {
                diving4LifeEntities.BuddySystem.Remove(buddyToDelete);
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
