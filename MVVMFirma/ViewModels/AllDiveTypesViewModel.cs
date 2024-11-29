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
    public class AllDiveTypesViewModel : AllViewModel<DiveTypes>
    {
        #region Constructor
        public AllDiveTypesViewModel()
            : base("Dive Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveTypes>
                (
                    diving4LifeEntities.DiveTypes.ToList()
                );
        }
        #endregion
    }
}
