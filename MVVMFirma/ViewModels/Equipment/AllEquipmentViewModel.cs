using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
