using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class CameraConverter
    {
        public static Camera ToCamera(this CameraEntity newEntity, Camera oldEntity = null)
        {
            Camera entity = oldEntity;
            if (entity == null)
            {
                entity = new Camera();

            }


            return entity;
        }


        public static CameraEntity ToCameraEntity(this Camera model)
        {
            if (model == null)
                return null;

            CameraEntity entity = new CameraEntity();

            return entity;
        }

        public static IEnumerable<CameraEntity> ToCameraEntityCollection(this IEnumerable<Camera> items)
        {
            List<CameraEntity> models = new List<CameraEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToCameraEntity()));

            return models;
        }
    }
}
