using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class AOTFilterViewModelConverter
    {
        public static AOTFilterViewModel ToAOTFilterViewModel(this AOTFilterEntity entity)
        {
            AOTFilterViewModel model = new AOTFilterViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.IntensityValue = entity.IntensityValue;
            model.DescriptionFORM = entity.Description;
            return model;
        }
        public static AOTFilterEntity ToAOTFilterEntity(this AOTFilterViewModel model)
        {
            AOTFilterEntity entity = new AOTFilterEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Name = model.Name;
            entity.IntensityValue = model.IntensityValue;
            entity.Description = model.DescriptionFORM;
            return entity;




        }
    }
}
