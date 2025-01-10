using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Messages
{
    public class AddMessage
    {
        public string MessageName { get; set; }
        public object ObjectSender { get; set; }
    }
}
