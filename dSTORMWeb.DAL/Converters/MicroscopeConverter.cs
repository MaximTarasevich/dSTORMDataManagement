using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.DAL.Converters
{
    public static class MicroscopeConverter
    {
        public static Microscope ToMicroscope(this MicroscopeEntity newEntity, Microscope oldEntity = null)
        {
            Microscope entity = oldEntity;
            if (entity == null)
            {
                entity = new Microscope();

            }
            entity.Model = newEntity.Model;
            entity.Type = newEntity.Type;
            entity.Producer = newEntity.Producer;

            return entity;
        }


        public static MicroscopeEntity ToMicroscopeEntity(this Microscope model)
        {
            if (model == null)
                return null;

            MicroscopeEntity entity = new MicroscopeEntity();
            entity.Id = model.Id;
            entity.Model = model.Model;
            entity.Type = model.Type;
            entity.Producer = model.Producer;
            return entity;
        }

        public static IEnumerable<MicroscopeEntity> ToMicroscopeEntityCollection(this IEnumerable<Microscope> items)
        {
            List<MicroscopeEntity> models = new List<MicroscopeEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToMicroscopeEntity()));

            return models;
        }
    }
}
