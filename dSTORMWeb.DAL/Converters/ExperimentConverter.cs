using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class ExperimentConverter
    {
        public static Experiment ToExperiment(this ExperimentEntity newEntity, Experiment oldEntity = null)
        {
            Experiment entity = oldEntity;
            if (entity == null)
            {
                entity = new Experiment();

            }


            return entity;
        }


        public static ExperimentEntity ToExperimentEntity(this Experiment model)
        {
            if (model == null)
                return null;

            ExperimentEntity entity = new ExperimentEntity();

            return entity;
        }

        public static IEnumerable<ExperimentEntity> ToExperimentEntityCollection(this IEnumerable<Experiment> items)
        {
            List<ExperimentEntity> models = new List<ExperimentEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToExperimentEntity()));

            return models;
        }
    }
}
