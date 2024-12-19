using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Certifications
{
    public class NewCertificationOrganizationViewModel : NewViewModel<CertificationOrganization>
    {
        #region Properties
        public string OrganizationName
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

        public string Country
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

        #region Constructor
        public NewCertificationOrganizationViewModel()
            : base("Organization")
        {
            item = new CertificationOrganization();
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
