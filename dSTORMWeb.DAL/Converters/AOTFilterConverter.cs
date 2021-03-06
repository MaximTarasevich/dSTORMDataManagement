﻿using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class AOTFilterConverter
    {
        public static AOTFilter ToAOTFilter(this AOTFilterEntity newEntity, AOTFilter oldEntity = null)
        {
            AOTFilter entity = oldEntity;
            if (entity == null)
            {
                entity = new AOTFilter();

            }
            entity.Name = newEntity.Name;
            entity.Description = newEntity.Description;
            entity.IntensityValue = newEntity.IntensityValue;
            return entity;
        }


        public static AOTFilterEntity ToAOTFilterEntity(this AOTFilter model)
        {
            if (model == null)
                return null;

            AOTFilterEntity entity = new AOTFilterEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.IntensityValue = model.IntensityValue;
            return entity;
        }

        public static IEnumerable<AOTFilterEntity> ToAOTFilterEntityCollection(this IEnumerable<AOTFilter> items)
        {
            List<AOTFilterEntity> models = new List<AOTFilterEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToAOTFilterEntity()));

            return models;
        }
    }
}
