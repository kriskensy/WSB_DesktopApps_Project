using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.BusinessLogic;
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

        public override void Delete(CertificationOrganizationForAllView record)
        {
            var certificationOrganizationToDelete = (from item in diving4LifeEntities.CertificationOrganization
                                                     where item.IdOrganization == record.IdOrganization
                                                     select item
                                   ).SingleOrDefault();


            if (certificationOrganizationToDelete != null)
            {
                diving4LifeEntities.CertificationOrganization.Remove(certificationOrganizationToDelete);
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
