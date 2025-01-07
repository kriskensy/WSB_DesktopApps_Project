﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveTypesViewModel : AllViewModel<DiveTypesForAllView>
    {
        #region Constructor
        public AllDiveTypesViewModel()
            : base("Dive Types") { }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Dive type" };
        }

        public override void Sort()
        {
            if (SortField == "Dive type")
                List = new ObservableCollection<DiveTypesForAllView>(List.OrderBy(item => item.TypeName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Dive type", "Description" };
        }

        public override void Find()
        {

        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveTypesForAllView>
                (
                    from diveType in diving4LifeEntities.DiveTypes
                    select new DiveTypesForAllView
                    {
                        IdDiveType = diveType.IdDiveType,
                        TypeName = diveType.TypeName,
                        Description = diveType.Description,
                    }
            );
        }

        public override void Delete(DiveTypesForAllView record)
        {
            var diveTypeToDelete = (from item in diving4LifeEntities.DiveTypes
                                    where item.IdDiveType == record.IdDiveType
                                    select item
                                   ).SingleOrDefault();


            if (diveTypeToDelete != null)
            {
                diving4LifeEntities.DiveTypes.Remove(diveTypeToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
