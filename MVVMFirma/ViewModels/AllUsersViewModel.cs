using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;

namespace MVVMFirma.ViewModels
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
