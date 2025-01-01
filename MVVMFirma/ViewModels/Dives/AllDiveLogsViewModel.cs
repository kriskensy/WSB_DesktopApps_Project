﻿using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using System.Windows.Input;
using System.Windows;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.BusinessLogic;

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
