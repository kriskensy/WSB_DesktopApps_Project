using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;
using System.Xml.Linq;

namespace MVVMFirma.ViewModels.Equipment
{
    public class NewMaintenanceScheduleViewModel : NewViewModel<MaintenanceSchedule>
    {
        #region Properties
        public int IdEquipment
        {
            get
            {
                return item.IdEquipment;
            }
            set
            {
                item.IdEquipment = value;
                OnPropertyChanged(() => IdEquipment);
            }
        }

        public DateTime ScheduledDate
        {
            get
            {
                return item.ScheduledDate;
            }
            set
            {
                item.ScheduledDate = value;
                OnPropertyChanged(() => ScheduledDate);
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

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }
        #endregion

        #region Constructor
        public NewMaintenanceScheduleViewModel()
            : base("Maintenance Schedule")
        {
            item = new MaintenanceSchedule();
            ScheduledDate = DateTime.Now;
        }
        #endregion

        #region XXXXXXXXX Combobox
        //ewentualnie zamienić na okno modalne co lepiej pasuje
        public IQueryable<KeyAndValue> MaintenanceSchedulesItems
        {
            get
            {
                return new EquipmentB(diving4LifeEntities).GetEquipmentKeyAndValueItems();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.MaintenanceSchedule.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Status):
                    return string.IsNullOrEmpty(Status) ? "Status cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
