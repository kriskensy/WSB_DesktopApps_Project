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
    public class AllDiveSitesViewModel : AllViewModel<DiveSites>
    {

        #region Constructor
        public AllDiveSitesViewModel()
            : base("Dive Sites") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveSites>
                (
                    diving4LifeEntities.DiveSites.ToList()
                );
        }
        #endregion
    }
}
