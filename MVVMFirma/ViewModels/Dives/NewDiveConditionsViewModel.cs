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
            Messenger.Default.Register<DiveLogsForAllView>(this, getSelectedDiveLog);
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
            Messenger.Default.Send<ShowAllMessage>(new ShowAllMessage { MessageName = "DiveLogsAll", ObjectSender = this });
        }
        #endregion

        #region Helpers
        private void getSelectedDiveLog(DiveLogsForAllView diveLog)
        {
            IdDiveLog = diveLog.IdDiveLog;
            DiveDate = diveLog.DiveDate;
        }

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
                //uwaga! ta data ma zostać pobrana przez okno modalne z DiveLog
                //case nameof(DiveDate):
                //    return Helper.Validators.DateTimeValidator.IsNotFutureDate(DiveDate) ?
                //    "Dive date cannot be empty or in the future" : string.Empty;
                case nameof(Temperature):
                    return Helper.Validators.StringValidator.IsIntGreaterThenZero(Temperature.ToString()) ?
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
