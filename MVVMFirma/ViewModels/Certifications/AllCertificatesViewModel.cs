using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.Generic;
using System;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;

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
            switch (SortField)
            {
                case "User Lastname":
                    List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.UserLastName));
                    break;
                case "Organization Name":
                    List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.OrganizationName));
                    break;
                case "Type of training":
                    List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.TypeOfTraining));
                    break;
                case "Issue Date":
                    List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.IssueDate));
                    break;
                case "Certification Number":
                    List = new ObservableCollection<CertificatesForAllView>(List.OrderBy(item => item.CertificateNumber));
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Organization Name", "Type of training", "Certification Number" };
        }

        public override void Find()
        {
            Load();

            switch (FindField)
            {
                case "User Lastname":
                    List = new ObservableCollection<CertificatesForAllView>(List.Where(item => item.UserLastName != null
                        && item.UserLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Organization Name":
                    List = new ObservableCollection<CertificatesForAllView>(List.Where(item => item.OrganizationName != null
                        && item.OrganizationName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Type of training":
                    List = new ObservableCollection<CertificatesForAllView>(List.Where(item => item.TypeOfTraining != null
                        && item.TypeOfTraining.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Certification Number":
                    List = new ObservableCollection<CertificatesForAllView>(List.Where(item => item.CertificateNumber != null
                        && item.CertificateNumber.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
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
            Certificates certificateToDelete = (from item in diving4LifeEntities.Certificates
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(CertificatesForAllView record)
        {
            Certificates certificateToEdit = (from item in diving4LifeEntities.Certificates
                                              where item.IdCertificate == record.IdCertificate
                                              select item
                                                ).SingleOrDefault();

            if (certificateToEdit != null)
            {
                Messenger.Default.Send(new OpenViewMessage() 
                { ViewToOpen = new NewCertificatesViewModel(SelectedRecord.IdCertificate), WhoRequestedToOpen = this });

            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
