using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper.Messages;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels.Dives
{
    public class AllTypeOfTrainingViewModel : AllViewModel<TypeOfTrainingForAllView>
    {
        #region Constructor
        public AllTypeOfTrainingViewModel()
            : base("Training Types") { }
        #endregion

        #region Sorting and Filtering
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Training name" };
        }

        public override void Sort()
        {
            if (SortField == "Training name")
                List = new ObservableCollection<TypeOfTrainingForAllView>(List.OrderBy(item => item.TrainingName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Description" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Description")
                List = new ObservableCollection<TypeOfTrainingForAllView>(List.Where(item => item.Description != null && item.Description.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
        #endregion

        #region Properties
        private TypeOfTrainingForAllView _SelectedTypeOfTraining;

        public TypeOfTrainingForAllView SelectedTypeOfTraining
        {
            get
            {
                return _SelectedTypeOfTraining;
            }
            set
            {
                _SelectedTypeOfTraining = value;
                if (WhoRequestedToOpen != null)
                {
                    Messenger.Default.Send<ObjectSenderMessage<TypeOfTrainingForAllView>>
                    (new ObjectSenderMessage<TypeOfTrainingForAllView>()
                    { WhoRequestedToOpen = WhoRequestedToOpen, Object = _SelectedTypeOfTraining });

                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypeOfTrainingForAllView>
                (
                    from typeOfTraining in diving4LifeEntities.TypeOfTraining
                    select new TypeOfTrainingForAllView
                    {
                        IdTypeOfTraining = typeOfTraining.IdTypeOfTraining,
                        TrainingName = typeOfTraining.TrainingName,
                        Description = typeOfTraining.Description,
                    }
            );
        }

        public override void Delete(TypeOfTrainingForAllView record)
        {
            var trainingTypeToDelete = (from item in diving4LifeEntities.TypeOfTraining
                                        where item.IdTypeOfTraining == record.IdTypeOfTraining
                                        select item
                                   ).SingleOrDefault();


            if (trainingTypeToDelete != null)
            {
                diving4LifeEntities.TypeOfTraining.Remove(trainingTypeToDelete);
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
