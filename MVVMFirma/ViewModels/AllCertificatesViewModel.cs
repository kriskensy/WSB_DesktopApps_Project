using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllCertificatesViewModel : AllViewModel<CertificatesForAllView>
    {
        #region Constructor
        public AllCertificatesViewModel()
            :base("Certificates")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CertificatesForAllView>
                (
                    from certificate in diving4LifeEntities.Certificates
                    select new CertificatesForAllView
                    {
                        IdCertificate= certificate.IdCertificate,
                        UserFirstName= certificate.User.FirstName,
                        UserLastName = certificate.User.LastName,
                        OrganizationName = certificate.CertificationOrganization.OrganizationName,
                        TypeOfTraining = certificate.TypeOfTraining.TrainingName,
                        IssueDate = certificate.IssueDate,
                        CertificateNumber = certificate.CertificateNumber
                    }
                );
        }
        #endregion
    }
}
