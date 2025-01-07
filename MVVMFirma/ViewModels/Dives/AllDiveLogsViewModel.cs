﻿using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using System.Windows.Input;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.BusinessLogic;
using System.Collections.Generic;

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
            if (SortField == "User Lastname")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.UserLastName));
            if (SortField == "Dive Type")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveTypeName));
            if (SortField == "Site name")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.SiteName));
            if (SortField == "Site location")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.SiteLocation));
            if (SortField == "Dive Date")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveDate));
            if (SortField == "Buddy Lastname")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.BuddyLastName));
            if (SortField == "Dive duration")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.DiveDuration));
            if (SortField == "Max depth")
                List = new ObservableCollection<DiveLogsForAllView>(List.OrderBy(item => item.MaxDepth));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Dive Type", "Site name", "Site location", "Buddy Lastname" };
        }

        public override void Find()
        {

        }
        #endregion

        #region Properties
        private DiveConditionsForAllView _SelectedDiveCondition;

        public DiveConditionsForAllView SelectedDiveCondition
        {
            get
            {
                return _SelectedDiveCondition;
            }
            set
            {
                _SelectedDiveCondition = value;
                Messenger.Default.Send(_SelectedDiveCondition);
                OnRequestClose();
            }
        }

        private DiveStatisticForAllView _SelectedDiveStatistic;

        public DiveStatisticForAllView SelectedDiveStatistic
        {
            get
            {
                return _SelectedDiveStatistic;
            }
            set
            {
                _SelectedDiveStatistic = value;
                Messenger.Default.Send(_SelectedDiveStatistic);
                OnRequestClose();
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
            var diveLogToDelete = (from item in diving4LifeEntities.DiveLogs
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
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
