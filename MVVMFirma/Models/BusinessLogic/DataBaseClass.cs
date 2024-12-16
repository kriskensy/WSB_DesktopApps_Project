using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    //klasa dostępowa do DB
    public class DataBaseClass
    {
        #region Context
        public Diving4LifeEntities1 db {  get; set; }
        #endregion

        #region Constructor
        public DataBaseClass(Diving4LifeEntities1 db)
        {
            this.db = db;
        }
        #endregion
    }
}
