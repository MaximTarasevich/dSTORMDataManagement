using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class FluorophoreViewModelConverter
    {
        public static FluorophoreViewModel ToFluorophoreViewModel(this FluorophoreEntity entity)
        {
            FluorophoreViewModel model = new FluorophoreViewModel();
            model.Id = entity.Id;
            model.Class = entity.Class;
            model.Emission = entity.Emission;
            model.Absorption = entity.Absorption;
            model.Name = entity.Name;
            return model;
        }
        public static FluorophoreEntity ToFluorophoreEntity(this FluorophoreViewModel model)
        {
            FluorophoreEntity entity = new FluorophoreEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Class = model.Class;
            entity.Emission = model.Emission;
            entity.Absorption = model.Absorption;
            entity.Name = model.Name;
            return entity;




        }
    }
}
