using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Helper.Messages
{
    public class OpenViewMessage
    {
        public WorkspaceViewModel ViewToOpen { get; set; }
        public object WhoRequestedToOpen { get; set; }
    }
}
