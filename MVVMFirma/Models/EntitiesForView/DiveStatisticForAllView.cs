using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DiveStatisticForAllView
    {
        public int IdStatistic { get; set; }
        public DateTime DiveDate { get; set; }
        public decimal? AirConsumed { get; set; }
        public decimal? AscentRate { get; set; }
        public int? BottomTime { get; set; }
    }
}
