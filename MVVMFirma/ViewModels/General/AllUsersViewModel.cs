using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
