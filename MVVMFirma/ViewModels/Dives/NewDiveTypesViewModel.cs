﻿using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveTypesViewModel : NewViewModel<DiveTypes>
    {
        #region Properties
        public string TypeName
        {
            get
            {
                return item.TypeName;
            }
            set
            {
                item.TypeName = value;
                OnPropertyChanged(() => TypeName);
            }
        }

        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }

        #endregion

        #region Constructor
        public NewDiveTypesViewModel()
            : base("Dive Type")
        {
            item = new DiveTypes();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveTypes.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}