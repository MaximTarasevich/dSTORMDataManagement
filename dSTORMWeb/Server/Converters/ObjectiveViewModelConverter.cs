using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class ObjectiveViewModelConverter
    {
        public static ObjectiveViewModel ToObjectiveViewModel(this ObjectiveEntity entity)
        {
            ObjectiveViewModel model = new ObjectiveViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Magnification = entity.Magnification;
            model.Resolution = entity.Resolution;
            model.EyePiece = entity.EyePiece;
            model.ObjectiveLens = entity.ObjectiveLens;
            model.DescriptionFORM = entity.Description;

            return model;
        }
        public static ObjectiveEntity ToObjectiveEntity(this ObjectiveViewModel model)
        {
            ObjectiveEntity entity = new ObjectiveEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Name = model.Name;
            entity.Magnification = model.Magnification;
            entity.Resolution = model.Resolution;
            entity.EyePiece = model.EyePiece;
            entity.ObjectiveLens = model.ObjectiveLens;
            entity.Description = model.DescriptionFORM;
            return entity;




        }
    }
}
