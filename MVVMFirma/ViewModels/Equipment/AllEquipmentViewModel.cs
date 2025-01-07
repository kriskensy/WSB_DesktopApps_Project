using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentViewModel : AllViewModel<EquipmentForAllView>
    {
        #region Constructor
        public AllEquipmentViewModel()
            : base("Equipment")
        {
        }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "User Lastname", "Category", "Manufacturer", "Equipment Name", "Serial Number", "Purchase Date" };
        }

        public override void Sort()
        {
            if (SortField == "User Lastname")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.UserLastName));
            if (SortField == "Category")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.CategoryName));
            if (SortField == "Manufacturer")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.ManufacturerName));
            if (SortField == "Equipment Name")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.EquipmentName));
            if (SortField == "Serial Number")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.SerialNumber));
            if (SortField == "Purchase Date")
                List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.PurchaseDate));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Category", "Manufacturer", "Equipment Name", "Serial Number" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "User Lastname")
                List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.UserLastName != null && item.UserLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Category")
                List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.CategoryName != null && item.CategoryName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Manufacturer")
                List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.ManufacturerName != null && item.ManufacturerName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Equipment Name")
                List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.EquipmentName != null && item.EquipmentName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Serial Number")
                List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.SerialNumber != null && item.SerialNumber.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        private EquipmentForAllView _SelectedEquipment;

        public EquipmentForAllView SelectedEquipment
        {
            get
            {
                return _SelectedEquipment;
            }
            set
            {
                _SelectedEquipment = value;
                Messenger.Default.Send(_SelectedEquipment);
                OnRequestClose();
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentForAllView>
                (
                    from equipment in diving4LifeEntities.Equipment
                    select new EquipmentForAllView
                    {
                        IdEquipment = equipment.IdEquipment,
                        UserFirstName = equipment.User.FirstName,
                        UserLastName = equipment.User.LastName,
                        CategoryName = equipment.EquipmentCategories.CategoryName,
                        ManufacturerName = equipment.EquipmentManufacturer.ManufacturerName,
                        EquipmentName = equipment.Name,
                        SerialNumber = equipment.SerialNumber,
                        PurchaseDate = equipment.PurchaseDate
                    }
                );
        }

        public override void Delete(EquipmentForAllView record)
        {
            var equipmentToDelete = (from item in diving4LifeEntities.Equipment
                                     where item.IdEquipment == record.IdEquipment
                                     select item
                                   ).SingleOrDefault();


            if (equipmentToDelete != null)
            {
                diving4LifeEntities.Equipment.Remove(equipmentToDelete);
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
