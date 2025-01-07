using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveSitesViewModel : NewViewModel<DiveSites>
    {
        #region Properties
        public string SiteName
        {
            get
            {
                return item.SiteName;
            }
            set
            {
                item.SiteName = value;
                OnPropertyChanged(() => SiteName);
            }
        }

        public string Location
        {
            get
            {
                return item.Location;
            }
            set
            {
                item.Location = value;
                OnPropertyChanged(() => Location);
            }
        }

        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }

        #endregion

        #region Constructor
        public NewDiveSitesViewModel()
            : base("Dive Sites", false)
        {
            item = new DiveSites();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveSites.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(SiteName):
                    return string.IsNullOrEmpty(SiteName) ? "Site name cannot be empty" : string.Empty;
                case nameof(Location):
                    return string.IsNullOrEmpty(Location) ? "Location cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
