using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class ResearchObjectViewModelConverter
    {
        public static ResearchObjectViewModel ToResearchObjectViewModel(this ResearchObjectEntity entity)
        {
            ResearchObjectViewModel model = new ResearchObjectViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            return model;
        }
        public static ResearchObjectEntity ToPhysicalPropertyEntity(this ResearchObjectViewModel model)
        {
            ResearchObjectEntity entity = new ResearchObjectEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.Name = model.Name;

            return entity;




        }
    }
}
