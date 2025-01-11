using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
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
            : base("Certificate", false)
        {
            item = new Certificates();
            IssueDate = DateTime.Now;
            IdUser = 0;
        }
        #endregion

        #region Combobox
        public IEnumerable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(diving4LifeEntities).GetUsersKeyAndValueItems();
            }
        }

        public IEnumerable<KeyAndValue> OrganizationsItems
        {
            get
            {
                return new OrganizationsB(diving4LifeEntities).GetOrganisationsKeyAndValueItems();
            }
        }
        public IEnumerable<KeyAndValue> TypesOfTrainingItems
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
                case nameof(IdUser):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdUser) ?
                    "User cannot be empty" : string.Empty;
                case nameof(IdOrganization):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdOrganization) ?
                    "Organization cannot be empty" : string.Empty;
                case nameof(IdTypeOfTraining):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdTypeOfTraining) ?
                    "Type of training cannot be empty" : string.Empty;
                case nameof(IssueDate):
                    return !Helper.Validators.DateTimeValidator.IsNotFutureDate(IssueDate) ?
                        "Issue date cannot be empty or in the future" : string.Empty;
                case nameof(CertificateNumber):
                    return string.IsNullOrEmpty(CertificateNumber) ? "Certificate number cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
