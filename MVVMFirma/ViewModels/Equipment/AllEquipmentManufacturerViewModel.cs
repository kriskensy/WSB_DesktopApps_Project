﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllEquipmentManufacturerViewModel : AllViewModel<EquipmentManufacturerForAllView>
    {
        #region Constructor
        public AllEquipmentManufacturerViewModel()
            : base("EQ Manufacturer") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentManufacturerForAllView>
                (
                    from equipmentManufacturer in diving4LifeEntities.EquipmentManufacturer
                    select new EquipmentManufacturerForAllView
                    {
                        IdManufacturer = equipmentManufacturer.IdManufacturer,
                        ManufacturerName = equipmentManufacturer.ManufacturerName,
                        Country = equipmentManufacturer.Country,
                    }
            );
        }

        public override void Delete(EquipmentManufacturerForAllView record)
        {
            var manufacturerToDelete = (from item in diving4LifeEntities.EquipmentManufacturer
                                        where item.IdManufacturer == record.IdManufacturer
                                        select item
                                   ).SingleOrDefault();


            if (manufacturerToDelete != null)
            {
                diving4LifeEntities.EquipmentManufacturer.Remove(manufacturerToDelete);
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
