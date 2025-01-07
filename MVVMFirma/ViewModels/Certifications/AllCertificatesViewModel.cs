using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.Generic;

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

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "User Lastname", "Organization Name", "Type of training", "Issue Date", "Certification Number" };
        }

        public override void Sort()
        {
            if (SortField == "User Lastname")
                List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.UserLastName));
            if (SortField == "Organization Name")
                List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.OrganizationName));
            if (SortField == "Type of training")
                List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.TypeOfTraining));
            if (SortField == "Issue Date")
                List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.IssueDate));
            if (SortField == "Certification Number")
                List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.CertificateNumber));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Organization Name", "Type of training", "Certification Number" };
        }

        public override void Find()
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
