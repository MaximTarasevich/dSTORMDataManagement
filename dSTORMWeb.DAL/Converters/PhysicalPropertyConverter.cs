using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class PhysicalPropertyConverter
    {

        public static PhysicalProperty ToPhysicalProperty(this PhysicalPropertyEntity newEntity, PhysicalProperty oldEntity = null)
        {
            PhysicalProperty entity = oldEntity;
            if (entity == null)
            {
                entity = new PhysicalProperty();

            }
            entity.Humidity = newEntity.Humidity;
            entity.Temperature = newEntity.Temperature;

            return entity;
        }


        public static PhysicalPropertyEntity ToPhysicalPropertyEntity(this PhysicalProperty model)
        {
            if (model == null)
                return null;

            PhysicalPropertyEntity entity = new PhysicalPropertyEntity();
            entity.Id = model.Id;
            entity.Humidity = model.Humidity;
            entity.Temperature = model.Temperature;

            return entity;
        }

        public static IEnumerable<PhysicalPropertyEntity> ToPhysicalPropertyEntityCollection(this IEnumerable<PhysicalProperty> items)
        {
            List<PhysicalPropertyEntity> models = new List<PhysicalPropertyEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToPhysicalPropertyEntity()));

            return models;
        }
    }
}
