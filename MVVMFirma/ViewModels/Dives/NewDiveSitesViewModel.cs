using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Certifications;

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
            diving4LifeEntities.DiveSites.Add(item);
        }

        public NewDiveSitesViewModel(int idDiveSite)
            : base("Dive Sites", true)
        {
            item = diving4LifeEntities.DiveSites.Find(idDiveSite);
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.SaveChanges();
            Messenger.Default.Send<ReloadViewMessage>(new ReloadViewMessage()
            { ViewModelTypeToReload = typeof(AllDiveSitesViewModel) });
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
