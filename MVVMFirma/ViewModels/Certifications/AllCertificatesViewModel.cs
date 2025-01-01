using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Certifications
{
    public class AllCertificatesViewModel : AllViewModel<CertificatesForAllView>
    {
        #region Constructor
        public AllCertificatesViewModel()
            : base("Certificates")
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
                        IdCertificate = certificate.IdCertificate,
                        UserFirstName = certificate.User.FirstName,
                        UserLastName = certificate.User.LastName,
                        OrganizationName = certificate.CertificationOrganization.OrganizationName,
                        TypeOfTraining = certificate.TypeOfTraining.TrainingName,
                        IssueDate = certificate.IssueDate,
                        CertificateNumber = certificate.CertificateNumber
                    }
                );
        }

        public override void Delete(CertificatesForAllView record)
        {
            var certificateToDelete = (from item in diving4LifeEntities.Certificates
                                       where item.IdCertificate == record.IdCertificate
                                       select item
                                   ).SingleOrDefault();


            if (certificateToDelete != null)
            {
                diving4LifeEntities.Certificates.Remove(certificateToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
