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
            entity.Format = newEntity.Format;
            entity.Resolution = newEntity.Resolution;
            entity.FrameFrequency = newEntity.FrameFrequency;
            entity.Size = newEntity.Size;
            entity.Duration = newEntity.Duration;
            entity.Name = newEntity.Name;
            entity.Description = newEntity.Description;
            entity.AuthorId = newEntity.AuthorId;
            entity.VideoBlob = newEntity.VideoBlob;
            return entity;
        }


        public static InitialVideoEntity ToInitialVideoEntity(this InitialVideo model)
        {
            if (model == null)
                return null;

            InitialVideoEntity entity = new InitialVideoEntity();
            entity.Id = model.Id;
            entity.Format = model.Format;
            entity.Resolution = model.Resolution;
            entity.FrameFrequency = model.FrameFrequency;
            entity.Size = model.Size;
            entity.Duration = model.Duration;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.VideoBlob = model.VideoBlob;
            if (model.Author != null) {
                entity.AuthorId = model.AuthorId;
                entity.Author = model.Author.ToAuthorEntity();
            }

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
