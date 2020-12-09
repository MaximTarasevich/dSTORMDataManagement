using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class ExperimentViewModelConverter
    {
        public static ExperimentViewModel ToExperimentViewModel(this ExperimentEntity entity)
        {
            ExperimentViewModel model = new ExperimentViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            if (entity.PhysicalProperty != null)
            {
                model.PhysicalPropertyId = entity.PhysicalProperty.Id;
                model.PhysicalProperty = entity.PhysicalProperty.ToPhysicalPropertyViewModel();
            }
            if (entity.Setup != null)
            {
                model.SetupId = entity.Setup.Id;
                model.Setup = entity.Setup.ToSetupViewModel();
            }
            if (entity.Fluorophore != null)
            {
                model.FluorophoreId = entity.Fluorophore.Id;
                model.Fluorophore = entity.Fluorophore.ToFluorophoreViewModel();
            }
            if (entity.ResearchObject != null)
            {
                model.ResearchObjectId = entity.ResearchObject.Id;
                model.ResearchObject = entity.ResearchObject.ToResearchObjectViewModel();
            }
            return model;
        }
        public static ExperimentEntity ToExperimentEntity(this ExperimentViewModel model)
        {
            ExperimentEntity entity = new ExperimentEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Name = model.Name;
            entity.PhysicalPropertyId = model.PhysicalPropertyId;
            entity.SetupId = model.SetupId;
            entity.FluorophoreId = model.FluorophoreId;
            entity.ResearchObjectId = model.ResearchObjectId;
            return entity;




        }
    }
}
