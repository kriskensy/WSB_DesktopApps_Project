using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Certifications;
using MVVMFirma.ViewModels.Equipment;
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

        public DateTime DiveDate { get; set; } //props do wyświetlania daty nurkowania przez okno modalne

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
            Messenger.Default.Register<ObjectSenderMessage<DiveLogsForAllView>>(this, getSelectedDiveLog);
            diving4LifeEntities.DiveStatistic.Add(item);
        }

        public NewDiveStatisticViewModel(int idDiveStatistic)
            : base("Dive Statistic", true)
        {
            item = diving4LifeEntities.DiveStatistic.Find(idDiveStatistic);
            DiveDate = diving4LifeEntities.DiveLogs.Find(item.IdDiveLog).DiveDate;
            Messenger.Default.Register<ObjectSenderMessage<DiveLogsForAllView>>(this, getSelectedDiveLog);
        }
        #endregion

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
            Messenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                WhoRequestedToOpen = this,
                ViewToOpen = new AllDiveLogsViewModel()
                { WhoRequestedToOpen = this }
            });
        }
        #endregion

        #region Helpers
        private void getSelectedDiveLog(ObjectSenderMessage<DiveLogsForAllView> message)
        {
            if (message.WhoRequestedToOpen != this)
            {
                return;
            }
            DiveLogsForAllView diveLog = message.Object;
            IdDiveLog = diveLog.IdDiveLog;
            DiveDate = diveLog.DiveDate;
        }

        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllDiveStatisticViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(DiveDate):
                    return !Helper.Validators.DateTimeValidator.IsNotFutureDate(DiveDate) ?
                    "Dive date cannot be empty or in the future" : string.Empty;
                case nameof(AirConsumed):
                    return !Helper.Validators.NumberValidator.IsDoubleGreaterThenZero(AirConsumed.ToString()) ?
                        "Air consumption must be a number greater then 0" : string.Empty;
                case nameof(AscentRate):
                    return !Helper.Validators.NumberValidator.IsDoubleGreaterThenZero(AscentRate.ToString()) ?
                        "Ascent rate must be a number greater then 0" : string.Empty;
                case nameof(BottomTime):
                    return !Helper.Validators.NumberValidator.IsDoubleGreaterThenZero(BottomTime.ToString()) ?
                        "Bottom time must be a number greater then 0" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}