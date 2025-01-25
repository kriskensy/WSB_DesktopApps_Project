using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;

namespace MVVMFirma.ViewModels.Equipment
{
    public class NewEquipmentCategoriesViewModel : NewViewModel<EquipmentCategories>
    {
        #region Properties
        public string CategoryName
        {
            get
            {
                return item.CategoryName;
            }
            set
            {
                item.CategoryName = value;
                OnPropertyChanged(() => CategoryName);
            }
        }

        #endregion

        #region Constructor
        public NewEquipmentCategoriesViewModel()
            : base("EQ Category", false)
        {
            item = new EquipmentCategories();
            diving4LifeEntities.EquipmentCategories.Add(item);
        }

        public NewEquipmentCategoriesViewModel(int idEquipmentCategory)
            : base("EQ Category", true)
        {
            item = diving4LifeEntities.EquipmentCategories.Find(idEquipmentCategory);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllEquipmentCategoriesViewModel) });
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(CategoryName):
                    return string.IsNullOrEmpty(CategoryName) ? "Category name cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
