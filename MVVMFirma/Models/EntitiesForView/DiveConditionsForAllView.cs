using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DiveConditionsForAllView
    {
        public int IdCondition { get; set; }
        public DateTime DiveDate { get; set; }
        public decimal Temperature { get; set; }
        public string WaterCurrent { get; set; }
        public string Visibility { get; set; }
        public string Notes { get; set; }

    }
}
