using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{

    public static class PhysicalPropertyViewModelConverter
    {
        public static PhysicalPropertyViewModel ToPhysicalPropertyViewModel(this PhysicalPropertyEntity entity)
        {
            PhysicalPropertyViewModel model = new PhysicalPropertyViewModel();
            model.Id = entity.Id;
            model.Temperature = entity.Temperature;
            model.Humidity = entity.Humidity;
            return model;
        }
        public static PhysicalPropertyEntity ToPhysicalPropertyEntity(this PhysicalPropertyViewModel model)
        {
            PhysicalPropertyEntity entity = new PhysicalPropertyEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Humidity = model.Humidity;
            entity.Temperature = model.Temperature;

            return entity;




        }
    }
}
