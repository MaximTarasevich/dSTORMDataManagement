using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class InitialVideoViewModelConverter
    {
        public static InitialVideoViewModel ToInitialVideoViewModel(this InitialVideoEntity entity)
        {
            InitialVideoViewModel model = new InitialVideoViewModel();
            model.Id = entity.Id;
            model.Format = entity.Format;
            model.Resolution = entity.Resolution;
            model.FrameFrequency = entity.FrameFrequency;
            model.Size = entity.Size;
            model.Duration = entity.Duration;
            model.Name = entity.Name;
            model.DescriptionFORM = entity.Description;
            model.VideoBlob = entity.VideoBlob;
            model.ExperimentId = entity.ExperimentId;
            if (entity.Author != null)
            {
                model.AuthorId = entity.Author.Id;
                model.Author = entity.Author.ToAuthorViewModel();
            }
            return model;
        }
        public static InitialVideoEntity ToInitialVideoEntity(this InitialVideoViewModel model)
        {
            InitialVideoEntity entity = new InitialVideoEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Id = model.Id;
            entity.Format = model.Format;
            entity.Resolution = model.Resolution;
            entity.FrameFrequency = model.FrameFrequency;
            entity.Size = model.Size;
            entity.Duration = model.Duration;
            entity.Name = model.Name;
            entity.Description = model.DescriptionFORM;
            entity.AuthorId = model.AuthorId;
            entity.VideoBlob = model.VideoBlob;
            entity.ExperimentId = model.ExperimentId;

            return entity;




        }
    }
}
