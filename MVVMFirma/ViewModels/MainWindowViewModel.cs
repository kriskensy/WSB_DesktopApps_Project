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
