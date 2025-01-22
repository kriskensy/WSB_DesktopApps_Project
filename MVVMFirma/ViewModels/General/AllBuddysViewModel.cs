using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
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
            Load();
            if (FindField == "Buddy Lastname")
                List = new ObservableCollection<BuddySystemForAllView>(List.Where(item => item.BuddyLastName != null && item.BuddyLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Certification Level")
                List = new ObservableCollection<BuddySystemForAllView>(List.Where(item => item.CertificationLevel != null && item.CertificationLevel.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Contact Details")
                List = new ObservableCollection<BuddySystemForAllView>(List.Where(item => item.ContactDetails != null && item.ContactDetails.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        private BuddySystemForAllView _SelectedBuddy;

        public BuddySystemForAllView SelectedBuddy
        {
            get
            {
                return _SelectedBuddy;
            }
            set
            {
                _SelectedBuddy = value;
                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<BuddySystemForAllView>>
                    (new ObjectSenderMessage<BuddySystemForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedBuddy });

                    OnRequestClose();
                }
            }
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
            BuddySystem buddyToDelete = (from item in diving4LifeEntities.BuddySystem
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        public override void Edit(BuddySystemForAllView record)
        {
            BuddySystem buddyToDelete = (from item in diving4LifeEntities.BuddySystem
                                         where item.IdBuddy == record.IdBuddy
                                         select item
                                   ).SingleOrDefault();


            if (buddyToDelete != null)
            {
                
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
