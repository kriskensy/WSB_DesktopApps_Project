﻿using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveConditionsViewModel : NewViewModel<DiveConditions>
    {
        #region Properties
        public int IdDiveLog
        {
            get
            {
                return item.IdDiveLog;
            }
            set
            {
                item.IdDiveLog = value;
                OnPropertyChanged(() => IdDiveLog);
            }
        }

        public decimal Temperature
        {
            get
            {
                return item.Temperature;
            }
            set
            {
                item.Temperature = value;
                OnPropertyChanged(() => Temperature);
            }
        }

        public string WaterCurrent
        {
            get
            {
                return item.WaterCurrent;
            }
            set
            {
                item.WaterCurrent = value;
                OnPropertyChanged(() => WaterCurrent);
            }
        }

        public string Visibility
        {
            get
            {
                return item.Visibility;
            }
            set
            {
                item.Visibility = value;
                OnPropertyChanged(() => Visibility);
            }
        }

        public string Notes
        {
            get
            {
                return item.Notes;
            }
            set
            {
                item.Notes = value;
                OnPropertyChanged(() => Notes);
            }
        }
        #endregion

        #region Constructor
        public NewDiveConditionsViewModel()
            : base("Dive Condition")
        {
            item = new DiveConditions();
        }
        #endregion

        //#region Combobox
        ////ewentualnie zamienić na okno modalne co lepiej pasuje
        //public IEnumerable<KeyAndValueForDate> DiveConditionsItems
        //{
        //    get
        //    {
        //        return new DiveLogsB(diving4LifeEntities).GetDiveLogsKeyAndValueItems();
        //    }
        //}
        //#endregion

        #region Command
        private BaseCommand _ShowAllDiveLogs;

        public ICommand ShowAllDiveLogs
        {
            get
            {
                if (_ShowAllDiveLogs == null)
                    _ShowAllDiveLogs = new BaseCommand(() => showAllDiveLogs());
                return _ShowAllDiveLogs;
            }
        }

        private void showAllDiveLogs()
        {
            Messenger.Default.Send<ShowAllMessage>(new ShowAllMessage { MessageName = "DiveLogsAll" });
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveConditions.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(WaterCurrent):
                    return string.IsNullOrEmpty(WaterCurrent) ? "Water current cannot be empty" : string.Empty;
                case nameof(Visibility):
                    return string.IsNullOrEmpty(Visibility) ? "Visibility cannot be empty" : string.Empty;
                case nameof(Notes):
                    return string.IsNullOrEmpty(Notes) ? "Notes cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
