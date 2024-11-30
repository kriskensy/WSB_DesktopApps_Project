using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewUsersViewModel : NewViewModel<User>
    {
        #region Constructor
        public NewUsersViewModel()
            :base("User")
        {
            item = new User();
        }
        #endregion

        #region Properties
        public String FirstName
        {
            get
            {
                return item.FirstName;
            }
            set
            {
                item.FirstName = value;
                OnPropertyChanged(() => FirstName);
            }
        }

        public String LastName
        {
            get
            {
                return item.LastName;
            }
            set
            {
                item.LastName = value;
                OnPropertyChanged(() => LastName);
            }
        }

        public String Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        public String PhoneNumber
        {
            get
            {
                return item.PhoneNumber;
            }
            set
            {
                item.PhoneNumber = value;
                OnPropertyChanged(() => PhoneNumber);
            }
        }

        public String PasswordHash
        {
            get
            {
                return item.PasswordHash;
            }
            set
            {
                item.PasswordHash = value;
                OnPropertyChanged(() => PasswordHash);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.User.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
