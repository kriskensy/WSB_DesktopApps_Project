using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Validators
{
    static public class NumberValidator
    {
        public static bool IsIntGreaterThenZero(string text)
        {
            int number;
            return (int.TryParse(text, out number) && number > 0);
        }

        public static bool IsDoubleGreaterThenZero(string text)
        {
            double number;
            return (double.TryParse(text, out number) && number > 0);
        }
    }
}
