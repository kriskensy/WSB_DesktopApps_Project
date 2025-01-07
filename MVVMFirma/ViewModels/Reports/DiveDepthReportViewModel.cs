using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels.Reports
{
    public class DiveDepthReportViewModel : WorkspaceViewModel
    {

        #region DB
        Diving4LifeEntities1 db;
        #endregion

        #region Constructor
        public DiveDepthReportViewModel()
        {
            base.DisplayName = "Dive depth report";
            db = new Diving4LifeEntities1();
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            DiveDuarationTime = 0;
        }
        #endregion

        #region Fields
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

        private int _DiveDuarationTime;

        public int DiveDuarationTime
        {
            get
            {
                return _DiveDuarationTime;
            }
            set
            {
                if (_DiveDuarationTime != value)
                {
                    _DiveDuarationTime = value;
                    OnPropertyChanged(() => _DiveDuarationTime);
                }
            }
        }
        #endregion

        #region Commands

        #endregion
    }
}
