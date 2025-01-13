using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels.Reports
{
    public class SACreportViewModel:WorkspaceViewModel
    {
        #region DB
        Diving4LifeEntities1 db;
        #endregion

        #region Constructor
        public SACreportViewModel()
        {
            base.DisplayName = "SAC report";
            db = new Diving4LifeEntities1();
        }
        #endregion
    }
}
