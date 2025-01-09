using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Validators
{
    public static class ForeignKeyValidator
    {
        public static bool IsForeignKeySelected(int? value)
        {
            return !value.HasValue;
        }
    }
}
