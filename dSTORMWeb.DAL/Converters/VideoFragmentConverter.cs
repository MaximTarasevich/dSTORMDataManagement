using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class VideoFragmentConverter
    {
        public static VideoFragment ToVideoFragment(this VideoFragmentEntity newEntity, VideoFragment oldEntity = null)
        {
            VideoFragment entity = oldEntity;
            if (entity == null)
            {
                entity = new VideoFragment();

            }
            entity.Frame = newEntity.Frame;
            entity.FrameTime = newEntity.FrameTime;
            entity.InitialVideoId = newEntity.InitialVideoId;
            

            return entity;
        }


        public static VideoFragmentEntity ToVideoFragmentEntity(this VideoFragment model)
        {
            if (model == null)
                return null;

            VideoFragmentEntity entity = new VideoFragmentEntity();
            entity.Id = model.Id;
            entity.Frame = model.Frame;
            entity.FrameTime = model.FrameTime;
            entity.InitialVideoId = model.InitialVideoId;
            return entity;
        }

        public static IEnumerable<VideoFragmentEntity> ToVideoFragmentEntityCollection(this IEnumerable<VideoFragment> items)
        {
            List<VideoFragmentEntity> models = new List<VideoFragmentEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToVideoFragmentEntity()));

            return models;
        }
    }
}
