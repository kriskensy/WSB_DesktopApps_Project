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

        public string DiveSiteName { get; set; } //props do wyświetlania nazwy miejsca nurkowego przez okno modalne
        public string DiveSiteLocation { get; set; } //props do wyświetlania lokalizacji miejsca nurkowego przez okno modalne

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
            Messenger.Default.Register<ObjectSenderMessage<DiveSitesForAllView>>(this, getSelectedDiveSite);
            diving4LifeEntities.DiveLogs.Add(item);
        }

        public NewDiveLogsViewModel(int idDiveLog)
            : base("Dive Log", true)
        {
            item = diving4LifeEntities.DiveLogs.Find(idDiveLog);
            DiveSiteName = diving4LifeEntities.DiveSites.Find(item.IdDiveSite).SiteName;
            DiveSiteLocation = diving4LifeEntities.DiveSites.Find(item.IdDiveSite).Location;
            Messenger.Default.Register<ObjectSenderMessage<DiveSitesForAllView>>(this, getSelectedDiveSite);
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
            Messenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                WhoRequestedToOpen = this,
                ViewToOpen = new AllDiveSitesViewModel()
                { WhoRequestedToOpen = this }
            });
        }
        #endregion

        #region Helpers
        private void getSelectedDiveSite(ObjectSenderMessage<DiveSitesForAllView> message)
        {
            if (message.WhoRequestedToOpen != this)
            {
                return;
            }
            DiveSitesForAllView diveSite = message.Object;
            IdDiveSite = diveSite.IdDiveSite;
            DiveSiteName = diveSite.SiteName;
            DiveSiteLocation = diveSite.Location;
        }

        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllDiveLogsViewModel) });
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
                case nameof(DiveSiteName):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdDiveSite) ?
                    "Dive site name cannot be empty" : string.Empty;
                case nameof(DiveSiteLocation):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdDiveSite) ?
                    "Dive site location cannot be empty" : string.Empty;
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
