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
    public class AllEmergencyContactsViewModel : AllViewModel<EmergencyContactsForAllView>
    {
        #region Constructor
        public AllEmergencyContactsViewModel()
            : base("Emergency Contact")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "User Lastname", "Contact Lastname", "Relationship", "Email" };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "User Lastname":
                    List = new ObservableCollection<EmergencyContactsForAllView>(List.OrderBy(item => item.UserLastName));
                    break;
                case "Contact Lastname":
                    List = new ObservableCollection<EmergencyContactsForAllView>(List.OrderBy(item => item.ContactLastName));
                    break;
                case "Relationship":
                    List = new ObservableCollection<EmergencyContactsForAllView>(List.OrderBy(item => item.Relationship));
                    break;
                case "Email":
                    List = new ObservableCollection<EmergencyContactsForAllView>(List.OrderBy(item => item.Email));
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Contact Lastname" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "User Lastname")
                List = new ObservableCollection<EmergencyContactsForAllView>(List.Where(item => item.UserLastName != null && item.UserLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Contact Lastname")
                List = new ObservableCollection<EmergencyContactsForAllView>(List.Where(item => item.ContactLastName != null && item.ContactLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
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
            EmergencyContacts emergencyContactToDelete = (from item in diving4LifeEntities.EmergencyContacts
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(EmergencyContactsForAllView record)
        {
            EmergencyContacts emergencyContactToDelete = (from item in diving4LifeEntities.EmergencyContacts
                                                          where item.IdEmergencyContact == record.IdEmergencyContact
                                                          select item
                                   ).SingleOrDefault();


            if (emergencyContactToDelete != null)
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
