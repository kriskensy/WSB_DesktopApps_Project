using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UsersB : DataBaseClass
    {
        #region Constructor
        public UsersB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IEnumerable<KeyAndValue> GetUsersKeyAndValueItems()
        {
            return
                (
                    from user in db.User
                    select new KeyAndValue
                    {
                        Key = user.IdUser,
                        Value = user.FirstName + " " + user.LastName,
                    }
                ).ToList();
        }
        #endregion
    }
}
