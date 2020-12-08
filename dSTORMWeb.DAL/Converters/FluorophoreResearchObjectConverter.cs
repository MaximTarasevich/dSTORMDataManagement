using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class FluorophoreResearchObjectConverter
    {
        public static FluorophoreResearchObject ToFluorophoreResearchObject(this FluorophoreResearchObjectEntity newEntity, FluorophoreResearchObject oldEntity = null)
        {
            FluorophoreResearchObject entity = oldEntity;
            if (entity == null)
            {
                entity = new FluorophoreResearchObject();

            }


            return entity;
        }


        public static FluorophoreResearchObjectEntity ToFluorophoreResearchObjectEntity(this FluorophoreResearchObject model)
        {
            if (model == null)
                return null;

            FluorophoreResearchObjectEntity entity = new FluorophoreResearchObjectEntity();

            return entity;
        }

        public static IEnumerable<FluorophoreResearchObjectEntity> ToFluorophoreResearchObjectEntityCollection(this IEnumerable<FluorophoreResearchObject> items)
        {
            List<FluorophoreResearchObjectEntity> models = new List<FluorophoreResearchObjectEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToFluorophoreResearchObjectEntity()));

            return models;
        }
    }
}
