using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class LaserViewModelConverter
    {

        public static LaserViewModel ToLaserViewModel(this LaserEntity entity)
        {
            LaserViewModel model = new LaserViewModel();
            model.Id = entity.Id;
            model.Model = entity.Model;
            model.Type = entity.Type;
            model.Producer = entity.Producer;
            model.WaveLength = entity.WaveLength;
            model.MaxPower = entity.MaxPower;
            model.OutputPower = entity.OutputPower;
            model.DescriptionFORM = entity.Description;
            return model;
        }
        public static LaserEntity ToLaserEntity(this LaserViewModel model)
        {
            LaserEntity entity = new LaserEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Model = model.Model;
            entity.Type = model.Type;
            entity.Producer = model.Producer;
            entity.WaveLength = model.WaveLength;
            entity.MaxPower = model.MaxPower;
            entity.OutputPower = model.OutputPower;
            entity.Description = model.DescriptionFORM;
            return entity;




        }
    }
}
