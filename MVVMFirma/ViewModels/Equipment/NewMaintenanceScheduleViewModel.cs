using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;

namespace MVVMFirma.ViewModels.Equipment
{
    public class NewMaintenanceScheduleViewModel : NewViewModel<MaintenanceSchedule>
    {
        #region Properties
        public int IdEquipment
        {
            get
            {
                return item.IdEquipment;
            }
            set
            {
                item.IdEquipment = value;
                OnPropertyChanged(() => IdEquipment);
            }
        }

        public DateTime ScheduledDate
        {
            get
            {
                return item.ScheduledDate;
            }
            set
            {
                item.ScheduledDate = value;
                OnPropertyChanged(() => ScheduledDate);
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

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }
        #endregion

        #region Constructor
        public NewMaintenanceScheduleViewModel()
            : base("Maintenance Schedule")
        {
            item = new MaintenanceSchedule();
            ScheduledDate = DateTime.Now;
        }
        #endregion

        //#region Combobox
        ////ewentualnie zamienić na okno modalne co lepiej pasuje
        //public IEnumerable<KeyAndValue> MaintenanceSchedulesItems
        //{
        //    get
        //    {
        //        return new EquipmentB(diving4LifeEntities).GetEquipmentKeyAndValueItems();
        //    }
        //}
        //#endregion

        #region Command
        private BaseCommand _ShowAllEquipment;

        public ICommand ShowAllEquipment
        {
            get
            {
                if (_ShowAllEquipment == null)
                    _ShowAllEquipment = new BaseCommand(() => showAllEquipment());
                return _ShowAllEquipment;
            }
        }

        private void showAllEquipment()
        {
            Messenger.Default.Send<ShowAllMessage>(new ShowAllMessage { MessageName = "EquipmentAll" });
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            diving4LifeEntities.MaintenanceSchedule.Add(item);
            diving4LifeEntities.SaveChanges();
        }
        #endregion

        #region Validation
        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Status):
                    return string.IsNullOrEmpty(Status) ? "Status cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
