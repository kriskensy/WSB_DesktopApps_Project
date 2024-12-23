using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Validators
{
    static public class StringValidator
    {
        public static bool ContainsOnlyNumbers(string text)
        {
            return string.IsNullOrEmpty(text) || Regex.IsMatch(text, @"^[\d\s]+$");
        }
    }
}
