using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllTypeOfTrainingViewModel : AllViewModel<TypeOfTraining>
    {
        #region Constructor
        public AllTypeOfTrainingViewModel()
            : base ("Training Types") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypeOfTraining>
                (
                diving4LifeEntities.TypeOfTraining.ToList()
                );
        }
        #endregion
    }
}
