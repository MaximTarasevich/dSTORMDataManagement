using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.DAL.Converters
{
    public static class LaserConverter
    {
        public static Laser ToLaser(this LaserEntity newEntity, Laser oldEntity = null)
        {
            Laser entity = oldEntity;
            if (entity == null)
            {
                entity = new Laser();

            }
            entity.Producer = newEntity.Producer;
            entity.Model = newEntity.Model;
            entity.Type = newEntity.Type;
            entity.WaveLength = newEntity.WaveLength;
            entity.OutputPower = newEntity.OutputPower;
            entity.MaxPower = newEntity.MaxPower;
            entity.Description = newEntity.Description;
            return entity;
        }


        public static LaserEntity ToLaserEntity(this Laser model)
        {
            if (model == null)
                return null;

            LaserEntity entity = new LaserEntity();
            entity.Id = model.Id;
            entity.Producer = model.Producer;
            entity.Model = model.Model;
            entity.Type = model.Type;
            entity.WaveLength = model.WaveLength;
            entity.OutputPower = model.OutputPower;
            entity.MaxPower = model.MaxPower;
            entity.Description = model.Description;
            return entity;
        }

        public static IEnumerable<LaserEntity> ToLaserEntityCollection(this IEnumerable<Laser> items)
        {
            List<LaserEntity> models = new List<LaserEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToLaserEntity()));

            return models;
        }
    }
}
