using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Certifications;

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
            Load();
            if (FindField == "Dive type")
                List = new ObservableCollection<DiveTypesForAllView>(List.Where(item => item.TypeName != null && item.TypeName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Description")
                List = new ObservableCollection<DiveTypesForAllView>(List.Where(item => item.Description != null && item.Description.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
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
            DiveTypes diveTypeToDelete = (from item in diving4LifeEntities.DiveTypes
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(DiveTypesForAllView record)
        {
            DiveTypes diveTypeToDelete = (from item in diving4LifeEntities.DiveTypes
                                          where item.IdDiveType == record.IdDiveType
                                          select item
                                   ).SingleOrDefault();

            if (diveTypeToDelete != null)
            {
                Messenger.Default.Send(new OpenViewMessage()
                { ViewToOpen = new NewDiveTypesViewModel(SelectedRecord.IdDiveType), WhoRequestedToOpen = this });
            }
            else
            {
                throw new InvalidOperationException("Record not found in the database.");
            }
        }
        #endregion
    }
}
