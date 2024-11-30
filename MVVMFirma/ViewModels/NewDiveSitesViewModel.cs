using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewDiveSitesViewModel : NewViewModel<DiveSites>
    {
        #region Constructor
        public NewDiveSitesViewModel()
            : base("Dive Sites")
        {
            item = new DiveSites();
        }
        #endregion

        #region Properties
        public String SiteName
        {
            get
            {
                return item.SiteName;
            }
            set
            {
                item.SiteName = value;
                OnPropertyChanged(() => SiteName);
            }
        }

        public String Location
        {
            get
            {
                return item.Location;
            }
            set
            {
                item.Location = value;
                OnPropertyChanged(() => Location);
            }
        }

        public String Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveSites.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
