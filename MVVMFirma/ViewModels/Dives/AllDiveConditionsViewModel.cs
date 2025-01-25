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
    public class AllDiveConditionsViewModel : AllViewModel<DiveConditionsForAllView>
    {
        #region Constructor
        public AllDiveConditionsViewModel()
            : base("Dive Conditions")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Dive Date", "Temperature", "Water Current", "Visibility" };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Dive Date":
                    List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.DiveDate));
                    break;
                case "Temperature":
                    List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.Temperature));
                    break;
                case "Water Current":
                    List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.WaterCurrent));
                    break;
                case "Visibility":
                    List = new ObservableCollection<DiveConditionsForAllView>(List.OrderBy(item => item.Visibility));
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Water Current", "Visibility", "Notes" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Water Current")
                List = new ObservableCollection<DiveConditionsForAllView>(List.Where(item => item.WaterCurrent != null && item.WaterCurrent.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Visibility")
                List = new ObservableCollection<DiveConditionsForAllView>(List.Where(item => item.Visibility != null && item.Visibility.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Notes")
                List = new ObservableCollection<DiveConditionsForAllView>(List.Where(item => item.Notes != null && item.Notes.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveConditionsForAllView>
                (
                    from diveCondition in diving4LifeEntities.DiveConditions
                    select new DiveConditionsForAllView
                    {
                        IdCondition = diveCondition.IdCondition,
                        DiveDate = diveCondition.DiveLogs.DiveDate,
                        Temperature = diveCondition.Temperature,
                        WaterCurrent = diveCondition.WaterCurrent,
                        Visibility = diveCondition.Visibility,
                        Notes = diveCondition.Notes
                    }
                );
        }

        public override void Delete(DiveConditionsForAllView record)
        {
            DiveConditions diveConditionToDelete = (from item in diving4LifeEntities.DiveConditions
                                         where item.IdCondition == record.IdCondition
                                         select item
                                   ).SingleOrDefault();


            if (diveConditionToDelete != null)
            {
                diving4LifeEntities.DiveConditions.Remove(diveConditionToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(DiveConditionsForAllView record)
        {
            DiveConditions diveConditionToDelete = (from item in diving4LifeEntities.DiveConditions
                                                    where item.IdCondition == record.IdCondition
                                                    select item
                                                    ).SingleOrDefault();

            if (diveConditionToDelete != null)
            {
                
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
