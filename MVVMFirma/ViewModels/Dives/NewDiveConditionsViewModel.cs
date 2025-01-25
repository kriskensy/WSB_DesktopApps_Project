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

        public DateTime DiveDate { get; set; } //props do wyświetlania daty nurkowania przez okno modalne

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
            : base("Dive Condition", false)
        {
            item = new DiveConditions();
            DiveDate = DateTime.Now;
            Messenger.Default.Register<ObjectSenderMessage<DiveLogsForAllView>>(this, getSelectedDiveLog);
            diving4LifeEntities.DiveConditions.Add(item);
        }

        public NewDiveConditionsViewModel(int idDiveCondition)
            : base("Dive Condition", true)
        {
            item = diving4LifeEntities.DiveConditions.Find(idDiveCondition);
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

        private void showAllDiveLogs()//dodany objectsender
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
            { ViewModelTypeToReload = typeof(AllDiveConditionsViewModel) });
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
                case nameof(Temperature):
                    return !Helper.Validators.NumberValidator.IsDoubleGreaterThenZero(Temperature.ToString()) ?
                        "Temperature must be a number greater then 0" : string.Empty;
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
