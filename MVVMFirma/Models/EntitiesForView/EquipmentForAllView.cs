using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class EquipmentForAllView
    {
        public int IdEquipment { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public string EquipmentName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
