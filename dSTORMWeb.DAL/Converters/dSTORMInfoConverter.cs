using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class dSTORMInfoConverter
    {
        public static dSTORMInfo TodSTORMInfo(this dSTORMInfoEntity newEntity, dSTORMInfo oldEntity = null)
        {
            dSTORMInfo entity = oldEntity;
            if (entity == null)
            {
                entity = new dSTORMInfo();

            }


            return entity;
        }


        public static dSTORMInfoEntity TodSTORMInfoEntity(this dSTORMInfo model)
        {
            if (model == null)
                return null;

            dSTORMInfoEntity entity = new dSTORMInfoEntity();

            return entity;
        }

        public static IEnumerable<dSTORMInfoEntity> TodSTORMInfoEntityCollection(this IEnumerable<dSTORMInfo> items)
        {
            List<dSTORMInfoEntity> models = new List<dSTORMInfoEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.TodSTORMInfoEntity()));

            return models;
        }
    }
}
