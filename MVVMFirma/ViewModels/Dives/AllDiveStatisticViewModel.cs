using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveStatisticViewModel : AllViewModel<DiveStatisticForAllView>
    {
        #region Constructor
        public AllDiveStatisticViewModel()
            : base("Statistic")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Dive Date", "Air Consumed", "Ascent Rate", "Bottom Time" };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Dive Date":
                    List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.DiveDate));
                    break;
                case "Air Consumed":
                    List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.AirConsumed));
                    break;
                case "Ascent Rate":
                    List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.AscentRate));
                    break;
                case "Bottom Time":
                    List = new ObservableCollection<DiveStatisticForAllView>(List.OrderBy(item => item.BottomTime));
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Air Consumed", "Ascent Rate", "Bottom Time" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Air Consumed")
                List = new ObservableCollection<DiveStatisticForAllView>(List.Where(item => item.AirConsumed != null && item.AirConsumed.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Ascent Rate")
                List = new ObservableCollection<DiveStatisticForAllView>(List.Where(item => item.AscentRate != null && item.AscentRate.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Bottom Time")
                List = new ObservableCollection<DiveStatisticForAllView>(List.Where(item => item.BottomTime != null && item.BottomTime.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        private DiveStatisticForAllView _SelectedDiveStatistic;

        public DiveStatisticForAllView SelectedDiveStatistic
        {
            get
            {
                return _SelectedDiveStatistic;
            }
            set
            {
                _SelectedDiveStatistic = value;
                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<DiveStatisticForAllView>>
                    (new ObjectSenderMessage<DiveStatisticForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedDiveStatistic });

                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveStatisticForAllView>
                (
                    from diveStatistic in diving4LifeEntities.DiveStatistic
                    select new DiveStatisticForAllView
                    {
                        IdStatistic = diveStatistic.IdStatistic,
                        DiveDate = diveStatistic.DiveLogs.DiveDate,
                        AirConsumed = diveStatistic.AirConsumed,
                        AscentRate = diveStatistic.AscentRate,
                        BottomTime = diveStatistic.BottomTime
                    }
                );
        }

        public override void Delete(DiveStatisticForAllView record)
        {
            DiveStatistic statisticToDelete = (from item in diving4LifeEntities.DiveStatistic
                                     where item.IdStatistic == record.IdStatistic
                                     select item
                                   ).SingleOrDefault();


            if (statisticToDelete != null)
            {
                diving4LifeEntities.DiveStatistic.Remove(statisticToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
