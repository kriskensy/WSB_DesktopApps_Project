using MVVMFirma.Models.Entities;
using System;

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
        #endregion

        #region XXXXXXXXX

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
