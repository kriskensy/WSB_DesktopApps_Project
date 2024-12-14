﻿using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
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
            : base("EQ Category")
        {
            item = new EquipmentCategories();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.EquipmentCategories.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
