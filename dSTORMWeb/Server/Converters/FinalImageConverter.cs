using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class FinalImageConverter
    {
        public static FinalImageViewModel ToFinalImageViewModel(this FinalImageEntity entity)
        {
            FinalImageViewModel model = new FinalImageViewModel();
            model.Id = entity.Id;
            model.Format = entity.Format;
            model.Resolution = entity.Resolution;
            if (entity.InitialVideo != null)
            {
                model.InitialVideoId = entity.InitialVideo.Id;
                model.InitialVideo = entity.InitialVideo.ToInitialVideoViewModel();
            }
            return model;
        }
        public static FinalImageEntity ToFinalImageEntity(this FinalImageViewModel model)
        {
            FinalImageEntity entity = new FinalImageEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Format = entity.Format;
            entity.Resolution = entity.Resolution;
            entity.InitialVideoId = model.InitialVideoId;

            return entity;




        }
    }
}
