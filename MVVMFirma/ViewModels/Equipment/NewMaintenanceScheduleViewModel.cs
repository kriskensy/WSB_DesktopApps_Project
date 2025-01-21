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

        public string EquipmentName { get; set; } //props do wyświetlania ekwipunku przez okno modalne

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
            : base("Maintenance Schedule", false)
        {
            item = new MaintenanceSchedule();
            ScheduledDate = DateTime.Now;
            Messenger.Default.Register<ObjectSenderMessage<EquipmentForAllView>>(this, getSelectedEquipment);
        }
        #endregion

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
            Messenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            { WhoRequestedToOpen = this, ViewToOpen = new AllEquipmentViewModel() 
            { WhoRequestedToOpen = this } });
        }
        #endregion

        #region Helpers
        private void getSelectedEquipment(ObjectSenderMessage<EquipmentForAllView> message)
        {
            if (message.WhoRequestedToOpen != this)
            {
                return;
            }
            EquipmentForAllView equipment = message.Object;
            IdEquipment = equipment.IdEquipment;
            EquipmentName = equipment.EquipmentName;
        }

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
                case nameof(IdEquipment):
                    return !Helper.Validators.ForeignKeyValidator.IsForeignKeySelected(IdEquipment) ?
                    "Equipment name cannot be empty" : string.Empty;
                case nameof(Status):
                    return string.IsNullOrEmpty(Status) ? "Status cannot be empty" : string.Empty;
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
