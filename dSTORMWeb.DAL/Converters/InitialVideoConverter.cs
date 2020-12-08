using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class InitialVideoConverter
    {
        public static InitialVideo ToInitialVideo(this InitialVideoEntity newEntity, InitialVideo oldEntity = null)
        {
            InitialVideo entity = oldEntity;
            if (entity == null)
            {
                entity = new InitialVideo();

            }


            return entity;
        }


        public static InitialVideoEntity ToInitialVideoEntity(this InitialVideo model)
        {
            if (model == null)
                return null;

            InitialVideoEntity entity = new InitialVideoEntity();

            return entity;
        }

        public static IEnumerable<InitialVideoEntity> ToInitialVideoEntityCollection(this IEnumerable<InitialVideo> items)
        {
            List<InitialVideoEntity> models = new List<InitialVideoEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToInitialVideoEntity()));

            return models;
        }
    }
}
