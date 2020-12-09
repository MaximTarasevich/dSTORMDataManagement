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

            entity.PhysicalPropertyId = newEntity.PhysicalPropertyId;
            entity.SetupId = newEntity.SetupId;
            entity.FluorophoreId = newEntity.FluorophoreId;
            entity.ResearchObjectId = newEntity.ResearchObjectId;
            entity.Name = newEntity.Name;
            return entity;
        }


        public static ExperimentEntity ToExperimentEntity(this Experiment model)
        {
            if (model == null)
                return null;

            ExperimentEntity entity = new ExperimentEntity();

            entity.Id = model.Id;
            entity.Name = model.Name;
            if (model.PhysicalProperty != null)
                entity.PhysicalProperty = model.PhysicalProperty.ToPhysicalPropertyEntity();
            if (model.Setup != null)
                entity.Setup = model.Setup.ToSetupEntity();
            if (model.Fluorophore != null)
                entity.Fluorophore = model.Fluorophore.ToFluorophoreEntity();
            if (model.ResearchObject != null)
                entity.ResearchObject = model.ResearchObject.ToResearchObjectEntity();

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
