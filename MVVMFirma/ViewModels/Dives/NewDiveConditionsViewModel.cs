using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.Dives
{
    public class NewDiveConditionsViewModel : NewViewModel<DiveConditions>
    {
        #region Properties
        public int IdDiveLog
        {
            get
            {
                return item.IdDiveLog;
            }
            set
            {
                item.IdDiveLog = value;
                OnPropertyChanged(() => IdDiveLog);
            }
        }

        public decimal Temperature
        {
            get
            {
                return item.Temperature;
            }
            set
            {
                item.Temperature = value;
                OnPropertyChanged(() => Temperature);
            }
        }

        public string WaterCurrent
        {
            get
            {
                return item.WaterCurrent;
            }
            set
            {
                item.WaterCurrent = value;
                OnPropertyChanged(() => WaterCurrent);
            }
        }

        public string Visibility
        {
            get
            {
                return item.Visibility;
            }
            set
            {
                item.Visibility = value;
                OnPropertyChanged(() => Visibility);
            }
        }

        public string Notes
        {
            get
            {
                return item.Notes;
            }
            set
            {
                item.Notes = value;
                OnPropertyChanged(() => Notes);
            }
        }
        #endregion

        #region Constructor
        public NewDiveConditionsViewModel()
            : base("Dive Condition")
        {
            item = new DiveConditions();
        }
        #endregion

        #region XXXXXXXXX

        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.DiveConditions.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion
    }
}
