using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class MicroscopeViewModelConverter
    {
        public static MicroscopeViewModel ToMicroscopeViewModel(this MicroscopeEntity entity)
        {
            MicroscopeViewModel model = new MicroscopeViewModel();
            model.Id = entity.Id;
            model.Model = entity.Model;
            model.Type = entity.Type;
            model.Producer = entity.Producer;
            return model;
        }
        public static MicroscopeEntity ToMicroscopeEntity(this MicroscopeViewModel model)
        {
            MicroscopeEntity entity = new MicroscopeEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Model = model.Model;
            entity.Type = model.Type;
            entity.Producer = model.Producer;

            return entity;




        }
    }
}
