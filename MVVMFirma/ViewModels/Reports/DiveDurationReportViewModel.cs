using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//ile minut pod wodą w okresie od.. do.. miał dany user?

namespace MVVMFirma.ViewModels.Reports
{
    public class DiveDurationReportViewModel : WorkspaceViewModel
    {
        #region DB
        Diving4LifeEntities1 db;
        #endregion

        #region Constructor
        public DiveDurationReportViewModel()
        {
            base.DisplayName = "Dive duration report";
            db = new Diving4LifeEntities1();
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            DiveDurationTime = 0;
        }
        #endregion

        #region Properties
        private int _IdUser;

        public int IdUser
        {
            get
            {
                return _IdUser;
            }
            set
            {
                if (_IdUser != value)
                {
                    _IdUser = value;
                    OnPropertyChanged(() => IdUser);
                }
            }
        }

        private DateTime _DateFrom;

        public DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }
            set
            {
                if (_DateFrom != value)
                {
                    _DateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }

        private DateTime _DateTo;

        public DateTime DateTo
        {
            get
            {
                return _DateTo;
            }
            set
            {
                if (_DateTo != value)
                {
                    _DateTo = value;
                    OnPropertyChanged(() => _DateTo);
                }
            }
        }

        private int _DiveDurationTime;

        public int DiveDurationTime
        {
            get
            {
                return _DiveDurationTime;
            }
            set
            {
                if (_DiveDurationTime != value)
                {
                    _DiveDurationTime = value;
                    OnPropertyChanged(() => _DiveDurationTime);
                }
            }
        }

        public IEnumerable<KeyAndValue> UsersItems
        {
            get
            {
                return new UsersB(db).GetUsersKeyAndValueItems();
            }
        }
        #endregion

        #region Commands
        private BaseCommand _CreateReport;

        public ICommand CreateReport
        {
            get
            {
                if (_CreateReport == null)
                    _CreateReport = new BaseCommand(() => calculateDiveDurationTime());
                return _CreateReport;
            }
        }

        private void calculateDiveDurationTime()
        {
            DiveDurationTime = new DiveDurationB(db).DiveDurationFromTo(IdUser, DateFrom, DateTo);
        }
        #endregion
    }
}
