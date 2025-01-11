using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Validators
{
    public static class DateTimeValidator
    {
        public static bool IsNotFutureDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
