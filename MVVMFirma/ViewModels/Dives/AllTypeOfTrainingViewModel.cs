﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
