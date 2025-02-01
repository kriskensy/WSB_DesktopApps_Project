using LiveCharts.Wpf;
using LiveCharts;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//ile nurkowań z za szybkim wynurzaniem + średnie wynurzanie

namespace MVVMFirma.ViewModels.Reports
{
    public class SafetyReportViewModel : ReportsDataBaseClass
    {
        #region DB
        SafetyReportB safetyReportLogic;
        #endregion

        #region Constructor
        public SafetyReportViewModel()
        {
            base.DisplayName = "Safety report";
            safetyReportLogic = new SafetyReportB(db);
            Formatter = value => value + " m/min";

            AverageAscentRate = 0;
            OverSpeedDives = 0;
        }
        #endregion

        #region Properties
        private double _AverageAscentRate;

        public double AverageAscentRate
        {
            get => _AverageAscentRate;
            set
            {
                if (_AverageAscentRate != value)
                {
                    _AverageAscentRate = value;
                    OnPropertyChanged(() => AverageAscentRate);
                }
            }
        }

        private int _OverSpeedDives;

        public int OverSpeedDives
        {
            get => _OverSpeedDives;
            set
            {
                if (_OverSpeedDives != value)
                {
                    _OverSpeedDives = value;
                    OnPropertyChanged(() => OverSpeedDives);
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
                    _CreateReport = new BaseCommand(() => calculateSafetyReport());
                return _CreateReport;
            }
        }

        private void calculateSafetyReport()
        {
            AverageAscentRate = Math.Round((double)safetyReportLogic.AverageAscentRate(IdUser, DateFrom, DateTo), 2); //obranie średniej prędkości wynurzania

            //pobranie liczby nurkowań z przekroczeniem prędkości wynurzania 9 m/min
            OverSpeedDives = safetyReportLogic.CountOverSpeedDives(IdUser, DateFrom, DateTo);

            var dives = safetyReportLogic.GetDivesForUser(IdUser, DateFrom, DateTo); //pobranie nurkowań w okresie

            SeriesCollection.Clear();
            Labels.Clear();

            var ascentRates = dives.Select(d => (double)d.AscentRate).ToArray();

            Labels = dives.Select(d => d.DiveDate.ToShortDateString()).ToList();

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Ascent Rate",
                Values = new ChartValues<double>(ascentRates)
            });

            OnPropertyChanged(() => AverageAscentRate);
            OnPropertyChanged(() => OverSpeedDives);
            OnPropertyChanged(() => SeriesCollection);
            OnPropertyChanged(() => Labels);
        }
        #endregion
    }
}
