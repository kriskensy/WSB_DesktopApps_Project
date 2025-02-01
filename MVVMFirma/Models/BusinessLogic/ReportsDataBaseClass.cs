using LiveCharts;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//klasa bazowa do raportów, ...ReportViewModel

namespace MVVMFirma.Models.BusinessLogic
{
    public class ReportsDataBaseClass : WorkspaceViewModel
    {
        #region Context
        public Diving4LifeEntities1 db { get; set; }
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

        #region Chart
        private SeriesCollection _SeriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return _SeriesCollection; }
            set
            {
                if (_SeriesCollection != value)
                {
                    _SeriesCollection = value;
                    OnPropertyChanged(() => SeriesCollection);
                }
            }
        }

        private List<string> _Labels;
        public List<string> Labels
        {
            get { return _Labels; }
            set
            {
                if (_Labels != value)
                {
                    _Labels = value;
                    OnPropertyChanged(() => Labels);
                }
            }
        }

        private Func<double, string> _Formatter;
        public Func<double, string> Formatter
        {
            get { return _Formatter; }
            set
            {
                if (_Formatter != value)
                {
                    _Formatter = value;
                    OnPropertyChanged(() => Formatter);
                }
            }
        }
        #endregion

        #region Constructor
        public ReportsDataBaseClass()
            :base()
        {
            db = new Diving4LifeEntities1();

            DateFrom = DateTime.Now.AddYears(-1); //ustawienie daty rok wstecz żeby nie klikać za wiele
            DateTo = DateTime.Now;

            SeriesCollection = new SeriesCollection();
            Labels = new List<string>();
        }
        #endregion
    }
}
