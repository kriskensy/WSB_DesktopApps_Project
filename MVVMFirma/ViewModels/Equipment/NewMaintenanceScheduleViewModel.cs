using MVVMFirma.Models.Entities;
using System;

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

        #region XXXXXXXXX

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.MaintenanceSchedule.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
