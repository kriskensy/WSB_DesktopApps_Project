using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;
using System.Windows;

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

        #region XXXXXXXXX Combobox
        //ewentualnie zamienić na okno modalne co lepiej pasuje
        public IQueryable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(diving4LifeEntities).GetUsersKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> OrganizationsItems
        {
            get
            {
                return new OrganizationsB(diving4LifeEntities).GetOrganisationsKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> TypesOfTrainingItems
        {
            get
            {
                return new TypesOfTrainingB(diving4LifeEntities).GetTypesOfTrainingKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.Certificates.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                //case nameof(IdUser):
                //    return ValidateForeignKey(IdUser, nameof(IdUser));
                //case nameof(IdOrganization):
                //    return ValidateForeignKey(IdUser, nameof(IdOrganization));
                //case nameof(IdTypeOfTraining):
                //    return ValidateForeignKey(IdUser, nameof(IdTypeOfTraining));
                //case nameof(IssueDate):
                //    return ValidateDateTime(IssueDate, nameof(IssueDate));
                case nameof(CertificateNumber):
                    return string.IsNullOrEmpty(CertificateNumber) ? "Certificate number cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }

        //protected override string ValidateDateTime(DateTime? value, string propertyName)
        //{
        //    if (value > DateTime.Now)
        //    {
        //        MessageBox.Show("The date cannot be later than today.", "Error");
        //    }
        //    return string.Empty;
        //}
        #endregion
    }
}
