using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveStatisticViewModel : NewViewModel<DiveStatistic>
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

        public DateTime DiveDate { get; set; }

        public decimal AirConsumed
        {
            get
            {
                return item.AirConsumed;
            }
            set
            {
                item.AirConsumed = value;
                OnPropertyChanged(() => AirConsumed);
            }
        }

        public decimal AscentRate
        {
            get
            {
                return item.AscentRate;
            }
            set
            {
                item.AscentRate = value;
                OnPropertyChanged(() => AscentRate);
            }
        }

        public int BottomTime
        {
            get
            {
                return item.BottomTime;
            }
            set
            {
                item.BottomTime = value;
                OnPropertyChanged(() => BottomTime);
            }
        }
        #endregion

        #region Constructor
        public NewDiveStatisticViewModel()
            : base("Dive Statistic", false)
        {
            item = new DiveStatistic();
            DiveDate = DateTime.Now;
            Messenger.Default.Register<DiveStatisticForAllView>(this, getSelectedDiveStatistic);
        }
        #endregion

        //#region Combobox
        ////ewentualnie zamienić na okno modalne co lepiej pasuje
        //public IEnumerable<KeyAndValueForDate> DiveStatisticsItems
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
        private void getSelectedDiveStatistic(DiveStatisticForAllView diveStatistic)
        {
            IdDiveLog = diveStatistic.IdStatistic;
            DiveDate = diveStatistic.DiveDate;
        }

        public override void Save()
        {
            diving4LifeEntities.DiveStatistic.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                //uwaga! ta data ma zostać pobrana z DiveLog
                //case nameof(DiveDate):
                //    return Helper.Validators.DateTimeValidator.IsNotFutureDate(DiveDate) ?
                //    "Dive date cannot be empty or in the future" : string.Empty;
                case nameof(AirConsumed):
                    return Helper.Validators.StringValidator.IsIntGreaterThenZero(AirConsumed.ToString()) ?
                        "Air consumption must be a number greater then 0" : string.Empty;
                case nameof(AscentRate):
                    return Helper.Validators.StringValidator.IsIntGreaterThenZero(AscentRate.ToString()) ?
                        "Ascent rate must be a number greater then 0" : string.Empty;
                case nameof(BottomTime):
                    return Helper.Validators.StringValidator.IsIntGreaterThenZero(BottomTime.ToString()) ?
                        "Bottom time must be a number greater then 0" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}