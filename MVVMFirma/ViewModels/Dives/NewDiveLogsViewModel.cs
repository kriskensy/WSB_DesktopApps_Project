using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveLogsViewModel : NewViewModel<DiveLogs>
    {
        #region Properties
        public int IdUser
        {
            get
            {
                return item.IdUser;
            }
            set
            {
                item.IdUser = value;
                OnPropertyChanged(() => IdUser);
            }
        }

        public int IdDiveType
        {
            get
            {
                return item.IdDiveType;
            }
            set
            {
                item.IdDiveType = value;
                OnPropertyChanged(() => IdDiveType);
            }
        }

        public string DiveSite { get; set; } //props do wyświetlania nazwy miejsca nurkowego przez okno modalne

        public int IdDiveSite
        {
            get
            {
                return item.IdDiveSite;
            }
            set
            {
                item.IdDiveSite = value;
                OnPropertyChanged(() => IdDiveSite);
            }
        }

        public DateTime DiveDate
        {
            get
            {
                return item.DiveDate;
            }
            set
            {
                item.DiveDate = value;
                OnPropertyChanged(() => DiveDate);
            }
        }

        public int IdBuddy
        {
            get
            {
                return item.IdBuddy;
            }
            set
            {
                item.IdBuddy = value;
                OnPropertyChanged(() => IdBuddy);
            }
        }

        public int DiveDuration
        {
            get
            {
                return item.DiveDuration;
            }
            set
            {
                item.DiveDuration = value;
                OnPropertyChanged(() => DiveDuration);
            }
        }

        public decimal MaxDepth
        {
            get
            {
                return item.MaxDepth;
            }
            set
            {
                item.MaxDepth = value;
                OnPropertyChanged(() => MaxDepth);
            }
        }
        #endregion

        #region Constructor
        public NewDiveLogsViewModel()
            : base("Dive Log", false)
        {
            item = new DiveLogs();
            DiveDate = DateTime.Now;
            Messenger.Default.Register<DiveSitesForAllView>(this, this, getSelectedDiveSite);
        }

        //konstruktor do edycji rekordów. czy tak trzeba?
        public NewDiveLogsViewModel(DiveLogsForAllView diveLog)
            : base("Dive Log", true)
        {
            item = new DiveLogs();

            //IdDiveLog = diveLog.IdDiveLog;
            //IdUser = User.FirstOrDefault(item => item.UserId == diveLog.UserId);
            //IdDiveType = diveLog.DiveTypes.TypeName;
            //IdDiveSite = diveLog.DiveSites.SiteName;
            //DiveDate = diveLog.DiveDate;
            //IdBuddy = diveLog.BuddySystem.BuddyFirstName;
            //DiveDuration = diveLog.DiveDuration;
            //MaxDepth = diveLog.MaxDepth;
        }

        #endregion

        #region Combobox
        public IEnumerable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(diving4LifeEntities).GetUsersKeyAndValueItems();
            }
        }

        public IEnumerable<KeyAndValue> DiveTypesItems
        {
            get
            {
                return new DiveTypeB(diving4LifeEntities).GetDiveTypesKeyAndValueItems();
            }
        }

        public IEnumerable<KeyAndValue> BuddysItems
        {
            get
            {
                return new BuddysB(diving4LifeEntities).GetBuddysKeyAndValueItems();
            }
        }
        #endregion

        #region Command
        private BaseCommand _ShowAllDiveSites;
        //private DiveLogsForAllView diveLog;
        //private DiveLogs diveLog1;

        public ICommand ShowAllDiveSites
        {
            get
            {
                if (_ShowAllDiveSites == null)
                    _ShowAllDiveSites = new BaseCommand(() => showAllDiveSites());
                return _ShowAllDiveSites;
            }
        }

        //wysyła żądanie pokazania zakładki z wszystkimi DiveSite
        //ObjectSender wskazuje, że nadawcą wiadomości jest bieżący obiekt
        private void showAllDiveSites()
        {
            Messenger.Default.Send<ShowAllMessage>(new ShowAllMessage { MessageName = "DiveSitesAll", ObjectSender = this });
        }
        #endregion

        #region Helpers
        private void getSelectedDiveSite(DiveSitesForAllView diveSite)
        {
            IdDiveSite = diveSite.IdDiveSite;
            DiveSite = diveSite.SiteName;
        }

        public override void Save()
        {
            diving4LifeEntities.DiveLogs.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(IdUser):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdUser) ?
                    "User cannot be empty" : string.Empty;
                case nameof(IdDiveType):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdDiveType) ?
                    "Dive type cannot be empty" : string.Empty;
                case nameof(DiveSite):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdDiveSite) ?
                    "Dive site cannot be empty" : string.Empty;
                case nameof(DiveDate):
                    return !Helper.Validators.DateTimeValidator.IsNotFutureDate(DiveDate) ?
                    "Dive date cannot be empty or in the future" : string.Empty;
                case nameof(IdBuddy):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdBuddy) ?
                    "Buddy cannot be empty" : string.Empty;
                case nameof(DiveDuration):
                    return !Helper.Validators.StringValidator.IsIntGreaterThenZero(DiveDuration.ToString()) ?
                        "Dive Duration must be a number greater then 0" : string.Empty;
                case nameof(MaxDepth):
                    return !Helper.Validators.StringValidator.IsIntGreaterThenZero(MaxDepth.ToString()) ?
                        "Max depth must be a number greater then 0" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
