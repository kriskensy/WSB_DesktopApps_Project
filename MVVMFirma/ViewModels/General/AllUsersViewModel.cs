using System.Collections.ObjectModel;
using System.Linq;
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
        #endregion
    }
}
