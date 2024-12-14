using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Equipment
{
    public class AllMaintenanceScheduleViewModule : AllViewModel<MaintenanceScheduleForAllView>
    {
        #region Constructor
        public AllMaintenanceScheduleViewModule()
            : base("Maintenance Schedule")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MaintenanceScheduleForAllView>
                (
                    from maintenanceSchedule in diving4LifeEntities.MaintenanceSchedule
                    select new MaintenanceScheduleForAllView
                    {
                        IdMaintenanceSchedule = maintenanceSchedule.IdMaintenanceSchedule,
                        EquipmentName = maintenanceSchedule.Equipment.Name,
                        ScheduledDate = maintenanceSchedule.ScheduledDate,
                        Description = maintenanceSchedule.Description,
                        Status = maintenanceSchedule.Status
                    }
                );
        }
        #endregion
    }
}
