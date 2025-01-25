using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Messages
{
    public class ReloadViewMessage
    {
        public Type ViewModelTypeToReload { get; set; }
    }
}
