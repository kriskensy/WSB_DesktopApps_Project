using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DiveLogsForAllView
    {
        public int IdDiveLog { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DiveTypeName { get; set; }
        public string SiteName { get; set; }
        public string SiteLocation { get; set; }
        public DateTime DiveDate { get; set; }
        public string BuddyFirstName { get; set; }
        public string BuddyLastName { get; set; }
        public int DiveDuration { get; set; }
        public decimal MaxDepth { get; set; }
    }
}
