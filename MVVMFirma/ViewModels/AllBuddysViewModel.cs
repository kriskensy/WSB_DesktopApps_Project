using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MVVMFirma.ViewModels
{
    public class AllBuddysViewModel : AllViewModel<BuddySystemForAllView>
    {
        #region Constructor
        public AllBuddysViewModel()
    : base("Buddys")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<BuddySystemForAllView>
                (
                    from buddy in diving4LifeEntities.BuddySystem
                    select new BuddySystemForAllView
                    {
                        IdBuddy = buddy.IdBuddy,
                        DiveDate = buddy.DiveLogs.DiveDate,
                        BuddyName = buddy.BuddyName,
                        CertificationLevel = buddy.CertificationLevel,
                        ContactDetails = buddy.ContactDetails
                    }
                );
        }
        #endregion

    }
}
