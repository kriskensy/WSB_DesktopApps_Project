using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewCertificationOrganizationViewModel : NewViewModel<CertificationOrganization>
    {
        #region Constructor
        public NewCertificationOrganizationViewModel()
            : base("Organization")
        {
            item = new CertificationOrganization();
        }
        #endregion

        #region Properties
        public String OrganizationName
        {
            get
            {
                return item.OrganizationName;
            }
            set
            {
                item.OrganizationName = value;
                OnPropertyChanged(() => OrganizationName);
            }
        }

        public String Country
        {
            get
            {
                return item.Country;
            }
            set
            {
                item.Country = value;
                OnPropertyChanged(() => Country);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.CertificationOrganization.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
