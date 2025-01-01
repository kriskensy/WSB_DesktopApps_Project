using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllDiveSitesViewModel : AllViewModel<DiveSitesForAllView>
    {

        #region Constructor
        public AllDiveSitesViewModel()
            : base("Dive Sites") { }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DiveSitesForAllView>
                (
                    from diveSites in diving4LifeEntities.DiveSites
                    select new DiveSitesForAllView
                    {
                        IdDiveSite = diveSites.IdDiveSite,
                        SiteName = diveSites.SiteName,
                        Location = diveSites.Location,
                        Description = diveSites.Description,
                    }
            );
        }

        public override void Delete(DiveSitesForAllView record)
        {
            var diveSiteToDelete = (from item in diving4LifeEntities.DiveSites
                                    where item.IdDiveSite == record.IdDiveSite
                                    select item
                                   ).SingleOrDefault();


            if (diveSiteToDelete != null)
            {
                diving4LifeEntities.DiveSites.Remove(diveSiteToDelete);
                diving4LifeEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Record not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
