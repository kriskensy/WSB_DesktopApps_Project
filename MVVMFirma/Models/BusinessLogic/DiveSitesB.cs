﻿using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DiveSitesB : DataBaseClass
    {
        #region Constructor
        public DiveSitesB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IEnumerable<KeyAndValue> GetDiveSitesKeyAndValueItems()
        {
            return
                (
                    from diveSite in db.DiveSites
                    select new KeyAndValue
                    {
                        Key = diveSite.IdDiveSite,
                        Value = diveSite.SiteName + " - " + diveSite.Location
                    }
                ).ToList();
        }
        #endregion
    }
}
