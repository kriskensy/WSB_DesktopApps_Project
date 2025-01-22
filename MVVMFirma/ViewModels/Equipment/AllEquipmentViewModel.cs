using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
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
            switch (SortField)
            {
                case "User Lastname":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.UserLastName));
                    break;
                case "Category":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.CategoryName));
                    break;
                case "Manufacturer":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.ManufacturerName));
                    break;
                case "Equipment Name":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.EquipmentName));
                    break;
                case "Serial Number":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.SerialNumber));
                    break;
                case "Purchase Date":
                    List = new ObservableCollection<EquipmentForAllView>(List.OrderBy(item => item.PurchaseDate));
                    break;
                default:
                    break;
            }

        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "User Lastname", "Category", "Manufacturer", "Equipment Name", "Serial Number" };
        }

        public override void Find()
        {
            Load();

            switch (FindField)
            {
                case "User Lastname":
                    List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.UserLastName != null && item.UserLastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Category":
                    List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.CategoryName != null && item.CategoryName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Manufacturer":
                    List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.ManufacturerName != null && item.ManufacturerName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Equipment Name":
                    List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.EquipmentName != null && item.EquipmentName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "Serial Number":
                    List = new ObservableCollection<EquipmentForAllView>(List.Where(item => item.SerialNumber != null && item.SerialNumber.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
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
                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<EquipmentForAllView>>
                    (new ObjectSenderMessage<EquipmentForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedEquipment });

                    OnRequestClose();
                }
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
                throw new InvalidOperationException("Record not found in the database.");
            }
        }

        public override void Edit(EquipmentForAllView record)
        {
            var equipmentToDelete = (from item in diving4LifeEntities.Equipment
                                     where item.IdEquipment == record.IdEquipment
                                     select item
                                   ).SingleOrDefault();


            if (equipmentToDelete != null)
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