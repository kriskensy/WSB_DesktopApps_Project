using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class CertificatesForAllView
    {
        public int IdCertificate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string OrganizationName { get; set; }
        public string TypeOfTraining { get; set; }
        public DateTime IssueDate { get; set; }
        public string CertificateNumber { get; set; }
    }
}
