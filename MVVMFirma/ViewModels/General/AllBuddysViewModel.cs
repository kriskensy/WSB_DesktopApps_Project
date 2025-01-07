using System.Collections.Generic;
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

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Buddy Lastname", "Certification Level" };
        }

        public override void Sort()
        {
            if (SortField == "Buddy Lastname")
                List = new ObservableCollection<BuddySystemForAllView>(List.OrderBy(item => item.BuddyLastName));
            if (SortField == "Certification Level")
                List = new ObservableCollection<BuddySystemForAllView>(List.OrderBy(item => item.CertificationLevel));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Buddy Lastname", "Certification Level", "Contact Details" };
        }

        public override void Find()
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
