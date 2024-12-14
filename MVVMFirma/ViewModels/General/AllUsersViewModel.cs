using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.General
{
    public class AllUsersViewModel : AllViewModel<User>
    {
        #region Constructor
        public AllUsersViewModel()
            : base("Users") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<User>
                (
                    diving4LifeEntities.User.ToList()
                );
        }
        #endregion
    }
}
