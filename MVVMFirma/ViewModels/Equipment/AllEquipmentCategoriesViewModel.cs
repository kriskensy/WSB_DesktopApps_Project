using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
