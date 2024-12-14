using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Certifications
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
