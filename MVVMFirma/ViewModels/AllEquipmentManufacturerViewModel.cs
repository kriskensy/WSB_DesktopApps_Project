using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class AllEquipmentManufacturerViewModel : AllViewModel<EquipmentManufacturer>
    {
        #region Constructor
        public AllEquipmentManufacturerViewModel()
            : base("EQ Manufacturer") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EquipmentManufacturer>
                (
                    diving4LifeEntities.EquipmentManufacturer.ToList()
                );
        }
        #endregion
    }
}
