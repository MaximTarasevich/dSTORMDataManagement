using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class dSTORMInfoViewModelConverter
    {
        public static dSTORMInfoViewModel TodSTORMInfoViewModel(this dSTORMInfoEntity entity)
        {
            dSTORMInfoViewModel model = new dSTORMInfoViewModel();
            model.Id = entity.Id;
            model.XCoord = entity.XCoord;
            model.YCoord = entity.YCoord;
            model.VideoFragmentId = entity.VideoFragmentId;
            return model;
        }
        public static dSTORMInfoEntity TodSTORMInfoEntity(this dSTORMInfoViewModel model)
        {
            dSTORMInfoEntity entity = new dSTORMInfoEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.XCoord = model.XCoord;
            entity.YCoord = model.YCoord;
            entity.VideoFragmentId = model.VideoFragmentId;
            return entity;
        }
    }
}
