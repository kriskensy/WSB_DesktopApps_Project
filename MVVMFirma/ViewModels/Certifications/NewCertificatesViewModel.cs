using MVVMFirma.Models.Entities;
using System;

namespace MVVMFirma.ViewModels.Certifications
{
    public class NewCertificatesViewModel : NewViewModel<Certificates>
    {
        #region Properties
        public int IdUser
        {
            get
            {
                return item.IdUser;
            }
            set
            {
                item.IdUser = value;
                OnPropertyChanged(() => IdUser);
            }
        }

        public int IdOrganization
        {
            get
            {
                return item.IdOrganization;
            }
            set
            {
                item.IdOrganization = value;
                OnPropertyChanged(() => IdOrganization);
            }
        }

        public int IdTypeOfTraining
        {
            get
            {
                return item.IdTypeOfTraining;
            }
            set
            {
                item.IdTypeOfTraining = value;
                OnPropertyChanged(() => IdTypeOfTraining);
            }
        }

        public DateTime IssueDate
        {
            get
            {
                return item.IssueDate;
            }
            set
            {
                item.IssueDate = value;
                OnPropertyChanged(() => IssueDate);
            }
        }

        public string CertificateNumber
        {
            get
            {
                return item.CertificateNumber;
            }
            set
            {
                item.CertificateNumber = value;
                OnPropertyChanged(() => CertificateNumber);
            }
        }
        #endregion

        #region Constructor
        public NewCertificatesViewModel()
            : base("Certificate")
        {
            item = new Certificates();
            IssueDate = DateTime.Now;
        }
        #endregion

        #region XXXXXXXXX

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.Certificates.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
