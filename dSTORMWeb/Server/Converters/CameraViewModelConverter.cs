﻿using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class CameraViewModelConverter
    {
        public static CameraViewModel ToCameraViewModel(this CameraEntity entity)
        {
            CameraViewModel model = new CameraViewModel();
            model.Id = entity.Id;
            model.Model = entity.Model;
            model.Objective = entity.Objective;
            model.Producer = entity.Producer;
            model.FocalLength = entity.FocalLength;
            model.MatrixType = entity.MatrixType;
            model.DescriptionFORM = entity.Description;
            model.Name = entity.Producer;
            return model;
        }
        public static CameraEntity ToCameraEntity(this CameraViewModel model)
        {
            CameraEntity entity = new CameraEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Model = model.Model;
            entity.Objective = model.Objective;
            entity.Producer = model.Producer;
            entity.FocalLength = model.FocalLength;
            entity.MatrixType = model.MatrixType;
            entity.Description = model.DescriptionFORM;
            return entity;




        }

        public static IEnumerable<CameraViewModel> ToCameraViewModelCollection(this IEnumerable<CameraEntity> items)
        {
            List<CameraViewModel> models = new List<CameraViewModel>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToCameraViewModel()));

            return models;
        }

    }
}
