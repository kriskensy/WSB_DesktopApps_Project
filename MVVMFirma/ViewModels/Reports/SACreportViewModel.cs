using LiveCharts;
using LiveCharts.Wpf;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Reports
{
    public class SACreportViewModel : ReportsDataBaseClass
    {
        #region DB
        SACconsumptionB SACconsumptionLogic;
        #endregion

        #region Constructor
        public SACreportViewModel()
        {
            base.DisplayName = "SAC report";
            SACconsumptionLogic = new SACconsumptionB(db);
            Formatter = value => value + " bar/min";

            SACconsumption = 0;
        }
        #endregion

        #region Properties
        private int _AirConsummed;

        public int AirConsummed
        {
            get
            {
                return _AirConsummed;
            }
            set
            {
                if (_AirConsummed != value)
                {
                    _AirConsummed = value;
                    OnPropertyChanged(() => _AirConsummed);
                }
            }
        }

        private int _MaxDepth;

        public int MaxDepth
        {
            get
            {
                return _MaxDepth;
            }
            set
            {
                if (_MaxDepth != value)
                {
                    _MaxDepth = value;
                    OnPropertyChanged(() => _MaxDepth);
                }
            }
        }

        private double _SACconsumption;

        public double SACconsumption
        {
            get
            {
                return _SACconsumption;
            }
            set
            {
                if (_SACconsumption != value)
                {
                    _SACconsumption = value;
                    OnPropertyChanged(() => _SACconsumption);
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
                    _CreateReport = new BaseCommand(() => calculateAverageDiveSAC());
                return _CreateReport;
            }
        }

        private void calculateAverageDiveSAC()
        {
            SACconsumption = Math.Round((double)SACconsumptionLogic.AverageDiveSAC(IdUser, DateFrom, DateTo), 2); //pobranie SAC całkowitego

            var dives = SACconsumptionLogic.GetDivesForUser(IdUser, DateFrom, DateTo); //pobranie nurkowań w okresie

            SeriesCollection.Clear();
            Labels.Clear();

            var sacConsumption = dives.Select(d =>
                Math.Round((double)(d.AirConsumed * 10 / (d.DiveDuration * (d.MaxDepth / 10 + 1))), 2)).ToArray();

            SACconsumption = Math.Round(sacConsumption.Average(),2);

            Labels = dives.Select(d => d.DiveDate.ToShortDateString()).ToList();

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Dive SAC",
                Values = new ChartValues<double>(sacConsumption)
            });

            OnPropertyChanged(() => SACconsumption);
            OnPropertyChanged(() => SeriesCollection);
            OnPropertyChanged(() => Labels);
        }
        #endregion
    }
}
