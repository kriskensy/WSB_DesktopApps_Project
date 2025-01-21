using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Messages
{
    public class ObjectSenderMessage<T>
    {
        public T Object { get; set; }
        public object WhoRequestedToOpen { get; set; }
    }
}
