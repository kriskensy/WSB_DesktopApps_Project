using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Certifications
{
    public class AllCertificationOrganizationViewModel : AllViewModel<CertificationOrganizationForAllView>
    {

        #region Constructor
        public AllCertificationOrganizationViewModel()
            : base("Certification Organization") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CertificationOrganizationForAllView>
                (
                    from organization in diving4LifeEntities.CertificationOrganization
                    select new CertificationOrganizationForAllView
                    {
                        IdOrganization = organization.IdOrganization,
                        OrganizationName = organization.OrganizationName,
                        Country = organization.Country,
                    }
                );
        }
        #endregion
    }
}
