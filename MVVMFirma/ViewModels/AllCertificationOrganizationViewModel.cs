using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class AllCertificationOrganizationViewModel : AllViewModel<CertificationOrganization>
    {

        #region Constructor
        public AllCertificationOrganizationViewModel()
            : base("Certification Organization") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CertificationOrganization>
                (
                    diving4LifeEntities.CertificationOrganization.ToList()
                );
        }
        #endregion
    }
}
