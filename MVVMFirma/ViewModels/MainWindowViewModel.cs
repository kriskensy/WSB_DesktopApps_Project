using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.Views;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
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
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllTowar())),

                new CommandViewModel(
                    "Towar",
                    new BaseCommand(() => this.CreateTowar())),

                new CommandViewModel(
                    "Buddys",
                    new BaseCommand(() => this.ShowAllBuddys())),

                new CommandViewModel(
                    "Certificates",
                    new BaseCommand(() => this.ShowAllCertificates())),

                new CommandViewModel(
                    "Certification Organizations",
                    new BaseCommand(() => this.ShowAllCertificationOrganizations())),

                new CommandViewModel(
                    "Dive Conditions",
                    new BaseCommand(() => this.ShowAllDiveConditions())),

                new CommandViewModel(
                    "Dive Log",
                    new BaseCommand(() => this.ShowAllDiveLogs())),

                new CommandViewModel(
                    "Dive Sites",
                    new BaseCommand(() => this.ShowAllDiveSites())),

                new CommandViewModel(
                    "Statistics",
                    new BaseCommand(() => this.ShowAllStatistics())),

                new CommandViewModel(
                    "Dive Types",
                    new BaseCommand(() => this.ShowAllDiveTypes())),

                new CommandViewModel(
                    "Emergency Contacts",
                    new BaseCommand(() => this.ShowAllEmergencyContacts())),

                new CommandViewModel(
                    "Equipment Categories",
                    new BaseCommand(() => this.ShowAllEquipmentCategories())),

                new CommandViewModel(
                    "Equipment Manufacturer",
                    new BaseCommand(() => this.ShowAllEquipmentManufacturer())),

                new CommandViewModel(
                    "Equipment",
                    new BaseCommand(() => this.ShowAllEquipment())),

                new CommandViewModel(
                    "Maintenance Schedules",
                    new BaseCommand(() => this.ShowAllMaintenanceSchedules())),

                new CommandViewModel(
                    "Trainig Types",
                    new BaseCommand(() => this.ShowAllTrainigTypes())),

                new CommandViewModel(
                    "Users",
                    new BaseCommand(() => this.ShowAllUsers())),
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
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

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

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
