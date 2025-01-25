using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveSitesViewModel : AllViewModel<DiveSitesForAllView>
    {

        #region Constructor
        public AllDiveSitesViewModel()
            : base("Dive Sites") { }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Site name", "Site location" };
        }

        public override void Sort()
        {
            if (SortField == "Site name")
                List = new ObservableCollection<DiveSitesForAllView>(List.OrderBy(item => item.SiteName));
            if (SortField == "Site location")
                List = new ObservableCollection<DiveSitesForAllView>(List.OrderBy(item => item.Location));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Site name", "Site location", "Description" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Site name")
                List = new ObservableCollection<DiveSitesForAllView>(List.Where(item => item.SiteName != null && item.SiteName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Site location")
                List = new ObservableCollection<DiveSitesForAllView>(List.Where(item => item.Location != null && item.Location.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Description")
                List = new ObservableCollection<DiveSitesForAllView>(List.Where(item => item.Description != null && item.Description.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        //dla okien modalnych
        private DiveSitesForAllView _SelectedDiveSite;

        public DiveSitesForAllView SelectedDiveSite
        {
            get
            {
                return _SelectedDiveSite;
            }
            set
            {
                _SelectedDiveSite = value;
                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<DiveSitesForAllView>>
                    (new ObjectSenderMessage<DiveSitesForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedDiveSite });

                    OnRequestClose();
                }
            }    
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveSitesForAllView>
                (
                    from diveSites in diving4LifeEntities.DiveSites
                    select new DiveSitesForAllView
                    {
                        IdDiveSite = diveSites.IdDiveSite,
                        SiteName = diveSites.SiteName,
                        Location = diveSites.Location,
                        Description = diveSites.Description,
                    }
            );
        }

        public override void Delete(DiveSitesForAllView record)
        {
            DiveSites diveSiteToDelete = (from item in diving4LifeEntities.DiveSites
                                    where item.IdDiveSite == record.IdDiveSite
                                    select item
                                   ).SingleOrDefault();


            if (diveSiteToDelete != null)
            {
                diving4LifeEntities.DiveSites.Remove(diveSiteToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(DiveSitesForAllView record)
        {
            DiveSites diveSiteToDelete = (from item in diving4LifeEntities.DiveSites
                                          where item.IdDiveSite == record.IdDiveSite
                                          select item
                                   ).SingleOrDefault();

            if (diveSiteToDelete != null)
            {
                
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
