using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.Shared.Models;
using dSTORMWeb.DAL.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class ResearchObjectConverter
    {
        public static ResearchObject ToResearchObject(this ResearchObjectEntity newEntity, ResearchObject oldEntity = null)
        {
            ResearchObject entity = oldEntity;
            if (entity == null)
            {
                entity = new ResearchObject();

            }
            entity.Name = newEntity.Name;

            return entity;
        }


        public static ResearchObjectEntity ToResearchObjectEntity(this ResearchObject model)
        {
            if (model == null)
                return null;

            ResearchObjectEntity entity = new ResearchObjectEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            return entity;
        }

        public static IEnumerable<ResearchObjectEntity> ToResearchObjectEntityCollection(this IEnumerable<ResearchObject> items)
        {
            List<ResearchObjectEntity> models = new List<ResearchObjectEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToResearchObjectEntity()));

            return models;
        }
    }
}
