using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class OrganizationsB:DataBaseClass
    {
        #region Constructor
        public OrganizationsB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValue> GetOrganisationsKeyAndValueItems()
        {
            return
                (
                    from organization in db.CertificationOrganization
                    select new KeyAndValue
                    {
                        Key = organization.IdOrganization,
                        Value = organization.OrganizationName
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
