using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class TypesOfTrainingB : DataBaseClass
    {
        #region Constructor
        public TypesOfTrainingB(Diving4LifeEntities1 db)
            : base(db) { }
        #endregion

        #region Business Functions
        public IQueryable<KeyAndValue> GetTypesOfTrainingKeyAndValueItems()
        {
            return
                (
                    from typeOfTraining in db.TypeOfTraining
                    select new KeyAndValue
                    {
                        Key = typeOfTraining.IdTypeOfTraining,
                        Value = typeOfTraining.TrainingName
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
