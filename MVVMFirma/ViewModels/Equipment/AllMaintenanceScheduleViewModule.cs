using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Equipment name", "Scheduled Date", "Status" };
        }

        public override void Sort()
        {
            if (SortField == "Equipment name")
                List = new ObservableCollection<MaintenanceScheduleForAllView>(List.OrderBy(item => item.EquipmentName));
            if (SortField == "Scheduled Date")
                List = new ObservableCollection<MaintenanceScheduleForAllView>(List.OrderBy(item => item.ScheduledDate));
            if (SortField == "Status")
                List = new ObservableCollection<MaintenanceScheduleForAllView>(List.OrderBy(item => item.Status));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Equipment name", "Description", "Status" };
        }

        public override void Find()
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

        public override void Delete(MaintenanceScheduleForAllView record)
        {
            var scheduleToDelete = (from item in diving4LifeEntities.MaintenanceSchedule
                                    where item.IdMaintenanceSchedule == record.IdMaintenanceSchedule
                                    select item
                                   ).SingleOrDefault();


            if (scheduleToDelete != null)
            {
                diving4LifeEntities.MaintenanceSchedule.Remove(scheduleToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
