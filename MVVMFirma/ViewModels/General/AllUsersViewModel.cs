using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.General
{
    public class AllUsersViewModel : AllViewModel<UserForAllView>
    {
        #region Constructor
        public AllUsersViewModel()
            : base("Users") { }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "User Lastname", "Email" };
        }

        public override void Sort()
        {
            if (SortField == "User Lastname")
                List = new ObservableCollection<UserForAllView>(List.OrderBy(item => item.LastName));
            if (SortField == "Email")
                List = new ObservableCollection<UserForAllView>(List.OrderBy(item => item.Email));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Email", "Phone number" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "User Lastname")
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.LastName != null && item.LastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Email")
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Phone number")
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.PhoneNumber != null && item.PhoneNumber.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UserForAllView>
                (
                    from user in diving4LifeEntities.User
                    select new UserForAllView
                    {
                        IdUser = user.IdUser,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                    }
            );
        }

        public override void Delete(UserForAllView record)
        {
            var userToDelete = (from item in diving4LifeEntities.User
                                where item.IdUser == record.IdUser
                                select item
                                   ).SingleOrDefault();


            if (userToDelete != null)
            {
                diving4LifeEntities.User.Remove(userToDelete);
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
