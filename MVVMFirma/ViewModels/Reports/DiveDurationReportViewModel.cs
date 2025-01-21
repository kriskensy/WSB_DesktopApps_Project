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
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

//ile minut pod wodą w okresie od.. do.. miał dany user?

namespace MVVMFirma.ViewModels.Reports
{
    public class DiveDurationReportViewModel : WorkspaceViewModel
    {
        #region DB
        Diving4LifeEntities1 db;
        DiveDurationB diveDurationLogic;
        #endregion

        #region Constructor
        public DiveDurationReportViewModel()
        {
            base.DisplayName = "Dive duration report";
            db = new Diving4LifeEntities1();
            diveDurationLogic = new DiveDurationB(db);

            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            DiveDurationTime = 0;

            SeriesCollection = new SeriesCollection();
            Labels = new List<string>();
            Formatter = value => value + " min";
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
            DiveDurationTime = diveDurationLogic.DiveDurationFromTo(IdUser, DateFrom, DateTo); //pobranie czasu całkowitego

            var dives = diveDurationLogic.GetDivesForUser(IdUser, DateFrom, DateTo); //pobranie nurkowań w okresie

            SeriesCollection.Clear();
            Labels.Clear();

            var durations = dives.Select(d => (int)d.DiveDuration).ToArray();
            Labels = dives.Select(d => d.DiveDate.ToShortDateString()).ToList(); //konieczna zamiana na stringa

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Dive Duration",
                Values = new ChartValues<int>(durations)
            });

            //aktualizacja
            OnPropertyChanged(() => DiveDurationTime);
            OnPropertyChanged(() => SeriesCollection);
            OnPropertyChanged(() => Labels);
        }
        #endregion
    }
}
