﻿using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pokazać sprzęt nurkowy dla usera po jakiejś kategorii

namespace MVVMFirma.ViewModels.Reports
{
    public class EquipmentCategoryReportViewModel: WorkspaceViewModel
    {
        #region DB
        Diving4LifeEntities1 db;
        #endregion

        #region Constructor
        public EquipmentCategoryReportViewModel()
        {
            base.DisplayName = "Equipment category report";
            db = new Diving4LifeEntities1();
        }
        #endregion

        #region Properties

        #endregion

        #region Commands

        #endregion
    }
}
