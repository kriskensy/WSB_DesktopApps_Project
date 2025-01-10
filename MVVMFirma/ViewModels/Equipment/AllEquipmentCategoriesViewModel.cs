using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentCategoriesViewModel : AllViewModel<EquipmentCategoriesForAllView>
    {
        #region Constructor
        public AllEquipmentCategoriesViewModel()
            : base("EQ Categories") { }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Category Name" };
        }

        public override void Sort()
        {
            if (SortField == "Category Name")
                List = new ObservableCollection<EquipmentCategoriesForAllView>(List.OrderBy(item => item.CategoryName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Category Name" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Category Name")
                List = new ObservableCollection<EquipmentCategoriesForAllView>(List.Where(item => item.CategoryName != null && item.CategoryName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        private EquipmentCategoriesForAllView _SelectedEquipmentCategory;

        public EquipmentCategoriesForAllView SelectedEquipmentCategory
        {
            get
            {
                return _SelectedEquipmentCategory;
            }
            set
            {
                _SelectedEquipmentCategory = value;
                if (WhoRequestedToSelectElement != null)
                {
                    Messenger.Default.Send(_SelectedEquipmentCategory);
                    //tu jeszcze dopisać od kogo i do kogo jest wiadomość
                }

                OnRequestClose();
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentCategoriesForAllView>
                (
                    from equipmentCategories in diving4LifeEntities.EquipmentCategories
                    select new EquipmentCategoriesForAllView
                    {
                        IdCategory = equipmentCategories.IdCategory,
                        CategoryName = equipmentCategories.CategoryName,
                    }
            );
        }

        public override void Delete(EquipmentCategoriesForAllView record)
        {
            var categoryToDelete = (from item in diving4LifeEntities.EquipmentCategories
                                    where item.IdCategory == record.IdCategory
                                    select item
                                   ).SingleOrDefault();


            if (categoryToDelete != null)
            {
                diving4LifeEntities.EquipmentCategories.Remove(categoryToDelete);
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
