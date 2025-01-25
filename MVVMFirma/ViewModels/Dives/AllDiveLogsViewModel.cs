using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using System.Windows.Input;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.BusinessLogic;
using System.Collections.Generic;
using System;
using MVVMFirma.Helper.Messages;
using MVVMFirma.ViewModels.Certifications;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveLogsViewModel : AllViewModel<DiveLogsForAllView>
    {
        #region Constructor
        public AllDiveLogsViewModel()
            : base("Dive Log")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "User Lastname", "Dive Type", "Site name", "Site location", "Dive Date", "Buddy Lastname", "Dive duration", "Max depth" };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "User Lastname":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.UserLastName));
                    break;
                case "Dive Type":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveTypeName));
                    break;
                case "Site name":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.SiteName));
                    break;
                case "Site location":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.SiteLocation));
                    break;
                case "Dive Date":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveDate));
                    break;
                case "Buddy Lastname":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.BuddyLastName));
                    break;
                case "Dive duration":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveDuration));
                    break;
                case "Max depth":
                    List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.MaxDepth));
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Dive Type", "Site name", "Site location", "Buddy Lastname" };
        }

        public override void Find()
        {
            Load();
            switch (FindField)
            {
                case "User Lastname":
                    List = new ObservableCollection<DiveLogsForAllView>(List.Where(item => item.UserLastName != null
                        && item.UserLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Dive Type":
                    List = new ObservableCollection<DiveLogsForAllView>(List.Where(item => item.DiveTypeName != null
                        && item.DiveTypeName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Site name":
                    List = new ObservableCollection<DiveLogsForAllView>(List.Where(item => item.SiteName != null
                        && item.SiteName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Site location":
                    List = new ObservableCollection<DiveLogsForAllView>(List.Where(item => item.SiteLocation != null
                        && item.SiteLocation.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Buddy Lastname":
                    List = new ObservableCollection<DiveLogsForAllView>(List.Where(item => item.BuddyLastName != null
                        && item.BuddyLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Properties

        //dla okien modalnych
        private DiveLogsForAllView _SelectedDiveLog;

        public DiveLogsForAllView SelectedDiveLog
        {
            get
            {
                return _SelectedDiveLog;
            }
            set
            {
                _SelectedDiveLog = value;
                SelectedRecord = value; //synchronizacja z SelectedRecord

                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<DiveLogsForAllView>>
                    (new ObjectSenderMessage<DiveLogsForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedDiveLog });
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveLogsForAllView>
                (
                    from diveLog in diving4LifeEntities.DiveLogs
                    select new DiveLogsForAllView
                    {
                        IdDiveLog = diveLog.IdDiveLog,
                        UserFirstName = diveLog.User.FirstName,
                        UserLastName = diveLog.User.LastName,
                        DiveTypeName = diveLog.DiveTypes.TypeName,
                        SiteName = diveLog.DiveSites.SiteName,
                        SiteLocation = diveLog.DiveSites.Location,
                        DiveDate = diveLog.DiveDate,
                        BuddyFirstName = diveLog.BuddySystem.BuddyFirstName,
                        BuddyLastName = diveLog.BuddySystem.BuddyLastName,
                        DiveDuration = diveLog.DiveDuration,
                        MaxDepth = diveLog.MaxDepth
                    }
            );
        }

        public override void Delete(DiveLogsForAllView record)
        {
            DiveLogs diveLogToDelete = (from item in diving4LifeEntities.DiveLogs
                                   where item.IdDiveLog == record.IdDiveLog
                                   select item
                                   ).SingleOrDefault();


            if (diveLogToDelete != null)
            {
                diving4LifeEntities.DiveLogs.Remove(diveLogToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(DiveLogsForAllView record)
        {
            DiveLogs diveLogToDelete = (from item in diving4LifeEntities.DiveLogs
                                        where item.IdDiveLog == record.IdDiveLog
                                        select item
                                        ).SingleOrDefault();

            if (diveLogToDelete != null)
            {
                Messenger.Default.Send(new OpenViewMessage()
                { ViewToOpen = new NewDiveLogsViewModel(SelectedRecord.IdDiveLog), WhoRequestedToOpen = this });
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
