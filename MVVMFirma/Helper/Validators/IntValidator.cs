using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Validators
{
    static public class IntValidator
    {
        public static bool IsTextInteger(string text)
        {
            return int.TryParse(text, out var result);
        }
    }
}
