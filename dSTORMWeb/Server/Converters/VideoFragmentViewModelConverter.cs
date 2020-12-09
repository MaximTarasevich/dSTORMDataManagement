using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class VideoFragmentViewModelConverter
    {
        public static VideoFragmentViewModel ToVideoFragmentViewModel(this VideoFragmentEntity entity)
        {
            VideoFragmentViewModel model = new VideoFragmentViewModel();
            model.Id = entity.Id;
            model.InitialVideoId = entity.InitialVideoId;
            model.FrameTime = entity.FrameTime;
            model.Frame = entity.Frame;

            return model;
        }
        public static VideoFragmentEntity ToVideoFragmentEntity(this VideoFragmentViewModel model)
        {
            VideoFragmentEntity entity = new VideoFragmentEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.InitialVideoId = model.InitialVideoId;
            entity.FrameTime = model.FrameTime;
            entity.Frame = model.Frame;

            return entity;




        }
    }
}
