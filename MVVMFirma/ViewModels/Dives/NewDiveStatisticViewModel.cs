using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
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
            : base("Dive Statistic")
        {
            item = new DiveStatistic();
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
            Messenger.Default.Send<string>("DiveLogsAll");
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveStatistic.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        //protected override string ValidateProperty(string propertyName)
        //{
        //    switch (propertyName)
        //    {
        //        case nameof(BottomTime):
        //            return !Helper.Validators.IntValidator.IsTextInteger(BottomTime) ? "Phonenumber can contains only numbers" : string.Empty;
        //        default:
        //            return string.Empty;
        //    }
        //}
        #endregion
    }
}