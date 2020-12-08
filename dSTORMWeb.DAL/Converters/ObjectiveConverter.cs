using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class ObjectiveConverter
    {
        public static Objective ToObjective(this ObjectiveEntity newEntity, Objective oldEntity = null)
        {
            Objective entity = oldEntity;
            if (entity == null)
            {
                entity = new Objective();

            }
            entity.Name = newEntity.Name;
            entity.Magnification = newEntity.Magnification;
            entity.Resolution = newEntity.Resolution;
            entity.EyePiece = newEntity.EyePiece;
            entity.ObjectiveLens = newEntity.ObjectiveLens;
            entity.Description = newEntity.Description;

            return entity;
        }


        public static ObjectiveEntity ToObjectiveEntity(this Objective model)
        {
            if (model == null)
                return null;

            ObjectiveEntity entity = new ObjectiveEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Magnification = model.Magnification;
            entity.Resolution = model.Resolution;
            entity.EyePiece = model.EyePiece;
            entity.ObjectiveLens = model.ObjectiveLens;
            entity.Description = model.Description;

            return entity;
        }

        public static IEnumerable<ObjectiveEntity> ToObjectiveEntityCollection(this IEnumerable<Objective> items)
        {
            List<ObjectiveEntity> models = new List<ObjectiveEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToObjectiveEntity()));

            return models;
        }
    }
}
