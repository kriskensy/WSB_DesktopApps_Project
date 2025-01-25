using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
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
            : base("Organization", false)
        {
            item = new CertificationOrganization();
            diving4LifeEntities.CertificationOrganization.Add(item);
        }

        public NewCertificationOrganizationViewModel(int idCertificationorganization)
            : base("Organization", true)
        {
            item = diving4LifeEntities.CertificationOrganization.Find(idCertificationorganization);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllCertificationOrganizationViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(OrganizationName):
                    return string.IsNullOrEmpty(OrganizationName) ? "Organization name cannot be empty" : string.Empty;
                case nameof(Country):
                    return string.IsNullOrEmpty(Country) ? "Country cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
