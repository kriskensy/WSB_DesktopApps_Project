﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.ViewModels.Certifications;
using MVVMFirma.ViewModels.Dives;
using MVVMFirma.ViewModels.Equipment;
using MVVMFirma.ViewModels.General;
using MVVMFirma.Views;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System.Windows;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper.Messages;
using MVVMFirma.ViewModels.Reports;
using MVVMFirma.Themes;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ReadOnlyCollection<CommandViewModel> _ReportCommands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<AddMessage>(this, message => openForAdd(message.MessageName));
            Messenger.Default.Register<ShowAllMessage>(this, message => openForShowAll(message.MessageName));
            Messenger.Default.Register<EditMessage>(this, message => openForEdit(message.MessageName));
            Messenger.Default.Register<OpenViewMessage>(this, OpenView);

            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Users",
                    new BaseCommand(() => this.ShowAllUsers()), FontAwesome.Sharp.IconChar.User),

                new CommandViewModel(
                    "Buddys",
                    new BaseCommand(() => this.ShowAllBuddys()), FontAwesome.Sharp.IconChar.Users),

                new CommandViewModel(
                    "Certificates",
                    new BaseCommand(() => this.ShowAllCertificates()), FontAwesome.Sharp.IconChar.Stamp),

                new CommandViewModel(
                    "Certification Organizations",
                    new BaseCommand(() => this.ShowAllCertificationOrganizations()), FontAwesome.Sharp.IconChar.Building),

                new CommandViewModel(
                    "Dive Conditions",
                    new BaseCommand(() => this.ShowAllDiveConditions()), FontAwesome.Sharp.IconChar.TemperatureQuarter),

                new CommandViewModel(
                    "Dive Logs",
                    new BaseCommand(() => this.ShowAllDiveLogs()), FontAwesome.Sharp.IconChar.Book),

                new CommandViewModel(
                    "Dive Sites",
                    new BaseCommand(() => this.ShowAllDiveSites()), FontAwesome.Sharp.IconChar.MapLocationDot),

                new CommandViewModel(
                    "Statistics",
                    new BaseCommand(() => this.ShowAllStatistics()), FontAwesome.Sharp.IconChar.ChartBar),

                new CommandViewModel(
                    "Dive Types",
                    new BaseCommand(() => this.ShowAllDiveTypes()), FontAwesome.Sharp.IconChar.FishFins),

                new CommandViewModel(
                    "Emergency Contacts",
                    new BaseCommand(() => this.ShowAllEmergencyContacts()), FontAwesome.Sharp.IconChar.AddressBook),

                new CommandViewModel(
                    "Equipment Categories",
                    new BaseCommand(() => this.ShowAllEquipmentCategories()), FontAwesome.Sharp.IconChar.List),

                new CommandViewModel(
                    "Equipment Manufacturer",
                    new BaseCommand(() => this.ShowAllEquipmentManufacturer()), FontAwesome.Sharp.IconChar.Industry),

                new CommandViewModel(
                    "Equipment",
                    new BaseCommand(() => this.ShowAllEquipment()), FontAwesome.Sharp.IconChar.Toolbox),

                new CommandViewModel(
                    "Maintenance Schedules",
                    new BaseCommand(() => this.ShowAllMaintenanceSchedules()), FontAwesome.Sharp.IconChar.CalendarDays),

                new CommandViewModel(
                    "Trainig Types",
                    new BaseCommand(() => this.ShowAllTrainigTypes()), FontAwesome.Sharp.IconChar.FishFins),
            };
        }
        #endregion

        #region ReportCommands
        public ReadOnlyCollection<CommandViewModel> ReportCommands
        {
            get
            {
                if (_ReportCommands == null)
                {
                    List<CommandViewModel> cmds = this.CreateReportCommands();
                    _ReportCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _ReportCommands;
            }
        }

        private List<CommandViewModel> CreateReportCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Dive duration report",
                    new BaseCommand(()=> this.CreateView(new DiveDurationReportViewModel())), FontAwesome.Sharp.IconChar.ChartLine),

                new CommandViewModel(
                    "SAC report",
                    new BaseCommand(()=> this.CreateView(new SACreportViewModel())), FontAwesome.Sharp.IconChar.ChartLine),

                new CommandViewModel(
                    "Safety report",
                    new BaseCommand(()=> this.CreateView(new SafetyReportViewModel())), FontAwesome.Sharp.IconChar.ChartLine),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }

        #endregion

        #region Helpers basic
        private void CreateView(WorkspaceViewModel newItem) //ta funkcja dodaje do listy Workspace dodaje i aktywuje 'new'.
        {
            this.Workspaces.Add(newItem);//to jest dodanie zakladki do kolekcji zakladek
            this.SetActiveWorkspace(newItem);//aktywowanie zakladki
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion

        #region Helpers ShowAll methodes
        private void ShowAllBuddys()
        {
            AllBuddysViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllBuddysViewModel)
                as AllBuddysViewModel;
            if (workspace == null)
            {
                workspace = new AllBuddysViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllCertificates()
        {
            AllCertificatesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllCertificatesViewModel)
                as AllCertificatesViewModel;
            if (workspace == null)
            {
                workspace = new AllCertificatesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllCertificationOrganizations()
        {
            AllCertificationOrganizationViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllCertificationOrganizationViewModel)
                as AllCertificationOrganizationViewModel;
            if (workspace == null)
            {
                workspace = new AllCertificationOrganizationViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDiveConditions()
        {
            AllDiveConditionsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDiveConditionsViewModel)
                as AllDiveConditionsViewModel;
            if (workspace == null)
            {
                workspace = new AllDiveConditionsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDiveLogs()
        {
            AllDiveLogsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDiveLogsViewModel)
                as AllDiveLogsViewModel;
            if (workspace == null)
            {
                workspace = new AllDiveLogsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDiveSites()
        {
            AllDiveSitesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDiveSitesViewModel)
                as AllDiveSitesViewModel;
            if (workspace == null)
            {
                workspace = new AllDiveSitesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllStatistics()
        {
            AllDiveStatisticViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDiveStatisticViewModel)
                as AllDiveStatisticViewModel;
            if (workspace == null)
            {
                workspace = new AllDiveStatisticViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDiveTypes()
        {
            AllDiveTypesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDiveTypesViewModel)
                as AllDiveTypesViewModel;
            if (workspace == null)
            {
                workspace = new AllDiveTypesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEmergencyContacts()
        {
            AllEmergencyContactsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEmergencyContactsViewModel)
                as AllEmergencyContactsViewModel;
            if (workspace == null)
            {
                workspace = new AllEmergencyContactsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEquipmentCategories()
        {
            AllEquipmentCategoriesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEquipmentCategoriesViewModel)
                as AllEquipmentCategoriesViewModel;
            if (workspace == null)
            {
                workspace = new AllEquipmentCategoriesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEquipmentManufacturer()
        {
            AllEquipmentManufacturerViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEquipmentManufacturerViewModel)
                as AllEquipmentManufacturerViewModel;
            if (workspace == null)
            {
                workspace = new AllEquipmentManufacturerViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEquipment()
        {
            AllEquipmentViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEquipmentViewModel)
                as AllEquipmentViewModel;
            if (workspace == null)
            {
                workspace = new AllEquipmentViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllMaintenanceSchedules()
        {
            AllMaintenanceScheduleViewModule workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllMaintenanceScheduleViewModule)
                as AllMaintenanceScheduleViewModule;
            if (workspace == null)
            {
                workspace = new AllMaintenanceScheduleViewModule();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllTrainigTypes()
        {
            AllTypeOfTrainingViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllTypeOfTrainingViewModel)
                as AllTypeOfTrainingViewModel;
            if (workspace == null)
            {
                workspace = new AllTypeOfTrainingViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllUsers()
        {
            AllUsersViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllUsersViewModel)
                as AllUsersViewModel;
            if (workspace == null)
            {
                workspace = new AllUsersViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        #endregion

        #region Helpers open methodes
        private void OpenView(OpenViewMessage message)
        {
            CreateView(message.ViewToOpen);
        }

        private void openForShowAll(string name)
        {
            switch (name)
            {
                case "EquipmentAll":
                    ShowAllEquipment();
                    break;
                case "DiveSitesAll":
                    ShowAllDiveSites();
                    break;
                case "DiveLogsAll":
                    ShowAllDiveLogs();
                    break;
                default: //info na konsolę
                    throw new ArgumentException($"Add button for: {name} doesn't work.");
            }
        }

        private void openForEdit(string name)
        {
            switch (name)
            {
                case "CertificatesEdit":
                    CreateView(new NewCertificatesViewModel());
                    break;
                case "Certification OrganizationEdit":
                    CreateView(new NewCertificationOrganizationViewModel());
                    break;
                case "Dive ConditionsEdit":
                    CreateView(new NewDiveConditionsViewModel());
                    break;
                case "Dive LogEdit":
                    CreateView(new NewDiveLogsViewModel());
                    break;
                case "Dive SitesEdit":
                    CreateView(new NewDiveSitesViewModel());
                    break;
                case "StatisticEdit":
                    CreateView(new NewDiveStatisticViewModel());
                    break;
                case "Dive TypesEdit":
                    CreateView(new NewDiveTypesViewModel());
                    break;
                case "Training TypesEdit":
                    CreateView(new NewTypeOfTrainingViewModel());
                    break;
                case "EQ CategoriesEdit":
                    CreateView(new NewEquipmentCategoriesViewModel());
                    break;
                case "EQ ManufacturerEdit":
                    CreateView(new NewEquipmentManufacturerViewModel());
                    break;
                case "EquipmentEdit":
                    CreateView(new NewEquipmentViewModel());
                    break;
                case "Maintenance ScheduleEdit":
                    CreateView(new NewMaintenanceScheduleViewModel());
                    break;
                case "BuddysEdit":
                    CreateView(new NewBuddysViewModel());
                    break;
                case "Emergency ContactEdit":
                    CreateView(new NewEmergencyContactsViewModel());
                    break;
                case "UsersEdit":
                    CreateView(new NewUsersViewModel());
                    break;
                default: //info na konsolę
                    throw new ArgumentException($"Edit button for: {name} doesn't work.");
            }
        }
        private void openForAdd(string name)
        {
            switch (name)
            {
                case "CertificatesAdd":
                    CreateView(new NewCertificatesViewModel());
                    break;
                case "Certification OrganizationAdd":
                    CreateView(new NewCertificationOrganizationViewModel());
                    break;
                case "Dive ConditionsAdd":
                    CreateView(new NewDiveConditionsViewModel());
                    break;
                case "Dive LogAdd":
                    CreateView(new NewDiveLogsViewModel());
                    break;
                case "Dive SitesAdd":
                    CreateView(new NewDiveSitesViewModel());
                    break;
                case "StatisticAdd":
                    CreateView(new NewDiveStatisticViewModel());
                    break;
                case "Dive TypesAdd":
                    CreateView(new NewDiveTypesViewModel());
                    break;
                case "Training TypesAdd":
                    CreateView(new NewTypeOfTrainingViewModel());
                    break;
                case "EQ CategoriesAdd":
                    CreateView(new NewEquipmentCategoriesViewModel());
                    break;
                case "EQ ManufacturerAdd":
                    CreateView(new NewEquipmentManufacturerViewModel());
                    break;
                case "EquipmentAdd":
                    CreateView(new NewEquipmentViewModel());
                    break;
                case "Maintenance ScheduleAdd":
                    CreateView(new NewMaintenanceScheduleViewModel());
                    break;
                case "BuddysAdd":
                    CreateView(new NewBuddysViewModel());
                    break;
                case "Emergency ContactAdd":
                    CreateView(new NewEmergencyContactsViewModel());
                    break;
                case "UsersAdd":
                    CreateView(new NewUsersViewModel());
                    break;
                default: //info na konsolę
                    throw new ArgumentException($"Add button for: {name} doesn't work.");
            }
        }
        #endregion

        #region Helpers CloseAllTabs
        private BaseCommand _CloseAllTabsCommand;

        public ICommand CloseAllTabsCommand
        {
            get
            {
                if (_CloseAllTabsCommand == null)
                    _CloseAllTabsCommand = new BaseCommand(() => CloseAllTabs());
                return _CloseAllTabsCommand;
            }
        }

        public void CloseAllTabs()
        {
            foreach (WorkspaceViewModel workspace in _Workspaces.ToList())
            {
                workspace.OnRequestClose();
                _Workspaces.Remove(workspace);
            }
        }
        #endregion
    }
}
