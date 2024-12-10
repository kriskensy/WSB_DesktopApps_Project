using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class EmergencyContactsForAllView
    {
        public int IdEmergencyContact { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ContactName { get; set; }
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
