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
            : base("Dive Log")
        {
            item = new DiveLogs();
            DiveDate = DateTime.Now;
        }

        //konstruktor do edycji rekordów
        public NewDiveLogsViewModel(DiveLogsForAllView diveLog)
            : base("Dive Log")
        {
            this.diveLog = diveLog;
        }

        #endregion

        #region Combobox
        //ewentualnie zamienić na okno modalne co lepiej pasuje
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

        //public IEnumerable<KeyAndValue> SiteItems
        //{
        //    get
        //    {
        //        return new DiveSitesB(diving4LifeEntities).GetDiveSitesKeyAndValueItems();
        //    }
        //}

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
        private DiveLogsForAllView diveLog;
        private DiveLogs diveLog1;

        public ICommand ShowAllDiveSites
        {
            get
            {
                if (_ShowAllDiveSites == null)
                    _ShowAllDiveSites = new BaseCommand(() => showAllDiveSites());
                return _ShowAllDiveSites;
            }
        }

        private void showAllDiveSites()
        {
            Messenger.Default.Send<ShowAllMessage>(new ShowAllMessage { MessageName = "DiveSitesAll" });
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveLogs.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
