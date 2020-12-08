using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.DAL.Converters
{
    public static class SetupConverter
    {
        public static Setup ToSetup(this SetupEntity newEntity, Setup oldEntity = null)
        {
            Setup entity = oldEntity;
            if (entity == null)
            {
                entity = new Setup();

            }


            return entity;
        }


        public static SetupEntity ToSetupEntity(this Setup model)
        {
            if (model == null)
                return null;

            SetupEntity entity = new SetupEntity();

            return entity;
        }

        public static IEnumerable<SetupEntity> ToSetupEntityCollection(this IEnumerable<Setup> items)
        {
            List<SetupEntity> models = new List<SetupEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToSetupEntity()));

            return models;
        }
    }
}
