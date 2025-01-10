using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Messages
{
    public class ShowAllMessage
    {
        public string MessageName { get; set; }

        //props dodany: trafia do sendera w komendach showAllxxx
        public object ObjectSender { get; set; }
    }
}
