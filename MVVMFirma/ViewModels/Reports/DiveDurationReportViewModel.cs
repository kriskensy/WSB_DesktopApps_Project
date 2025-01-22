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
    public class DiveDurationReportViewModel : ReportsDataBaseClass
    {
        #region DB
        DiveDurationB diveDurationLogic;
        #endregion

        #region Constructor
        public DiveDurationReportViewModel()
        {
            base.DisplayName = "Dive duration report";
            diveDurationLogic = new DiveDurationB(db);
            Formatter = value => value + " min";

            DiveDurationTime = 0;
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
