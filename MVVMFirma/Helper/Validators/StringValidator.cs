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
        public static bool ContainsPhoneNumber(string text)
        {
            //return string.IsNullOrEmpty(text) || Regex.IsMatch(text, @"^[\d\s]+$");
            return !(Regex.IsMatch(text, @"^[\d\s]+$") && text.Length == 9);
        }

        public static bool ContainsEmailAddress(string text)
        {
            return !Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsIntGreaterThenZero(string text)
        {
            int number;
            return !(int.TryParse(text, out number) && number > 0);
        }
    }
}
