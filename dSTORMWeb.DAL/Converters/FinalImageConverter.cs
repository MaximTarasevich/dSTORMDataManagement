using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class FinalImageConverter
    {
        public static FinalImage ToFinalImage(this FinalImageEntity newEntity, FinalImage oldEntity = null)
        {
            FinalImage entity = oldEntity;
            if (entity == null)
            {
                entity = new FinalImage();

            }
            entity.Format = newEntity.Format;
            entity.Resolution = newEntity.Resolution;
            entity.FinalImageBlob = newEntity.FinalImageBlob;
            entity.InitialVideoId = newEntity.InitialVideoId;
            return entity;
        }


        public static FinalImageEntity ToFinalImageEntity(this FinalImage model)
        {
            if (model == null)
                return null;

            FinalImageEntity entity = new FinalImageEntity();
            entity.Id = model.Id;
            entity.Format = model.Format;
            entity.Resolution = model.Resolution;
            entity.FinalImageBlob = model.FinalImageBlob;
            entity.InitialVideoId = model.InitialVideoId;
            if (model.InitialVideo != null)
                entity.InitialVideo = model.InitialVideo.ToInitialVideoEntity();
            return entity;
        }

        public static IEnumerable<FinalImageEntity> ToFinalImageEntityCollection(this IEnumerable<FinalImage> items)
        {
            List<FinalImageEntity> models = new List<FinalImageEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToFinalImageEntity()));

            return models;
        }
    }
}
