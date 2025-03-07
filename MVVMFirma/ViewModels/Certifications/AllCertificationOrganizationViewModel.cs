﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
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

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Organization", "Country" };
        }

        public override void Sort()
        {
            if (SortField == "Organization")
                List = new ObservableCollection<CertificationOrganizationForAllView>(List.OrderBy(item => item.OrganizationName));
            if (SortField == "Country")
                List = new ObservableCollection<CertificationOrganizationForAllView>(List.OrderBy(item => item.Country));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Organization", "Country" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Organization")
                List = new ObservableCollection<CertificationOrganizationForAllView>
                    (List.Where(item => item.OrganizationName != null && item.OrganizationName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Country")
                List = new ObservableCollection<CertificationOrganizationForAllView>
                    (List.Where(item => item.Country != null && item.Country.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
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
            CertificationOrganization certificationOrganizationToDelete = (from item in diving4LifeEntities.CertificationOrganization
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(CertificationOrganizationForAllView record)
        {
            CertificationOrganization certificationOrganizationToDelete = (from item in diving4LifeEntities.CertificationOrganization
                                                                           where item.IdOrganization == record.IdOrganization
                                                                           select item
                                                                            ).SingleOrDefault();

            if (certificationOrganizationToDelete != null)
            {
                Messenger.Default.Send(new OpenViewMessage()
                { ViewToOpen = new NewCertificationOrganizationViewModel(SelectedRecord.IdOrganization), WhoRequestedToOpen = this });
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
