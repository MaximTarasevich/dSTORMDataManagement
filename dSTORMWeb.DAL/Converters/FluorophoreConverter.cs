using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.Shared.Models;
using dSTORMWeb.DAL.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class FluorophoreConverter
    {
        public static Fluorophore ToFluorophore(this FluorophoreEntity newEntity, Fluorophore oldEntity = null)
        {
            Fluorophore entity = oldEntity;
            if (entity == null)
            {
                entity = new Fluorophore();

            }
            entity.Name = newEntity.Name;
            entity.Emission = newEntity.Emission;
            entity.Absorption = newEntity.Absorption;
            entity.Class = newEntity.Class;

            return entity;
        }


        public static FluorophoreEntity ToFluorophoreEntity(this Fluorophore model)
        {
            if (model == null)
                return null;

            FluorophoreEntity entity = new FluorophoreEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Emission = model.Emission;
            entity.Absorption = model.Absorption;
            entity.Class = model.Class;

            return entity;
        }

        public static IEnumerable<FluorophoreEntity> ToFluorophoreEntityCollection(this IEnumerable<Fluorophore> items)
        {
            List<FluorophoreEntity> models = new List<FluorophoreEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToFluorophoreEntity()));

            return models;
        }
    }
}
