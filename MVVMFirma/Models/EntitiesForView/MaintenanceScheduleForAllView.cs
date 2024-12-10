using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class MaintenanceScheduleForAllView
    {
        public int IdMaintenanceSchedule { get; set; }
        public string EquipmentName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
