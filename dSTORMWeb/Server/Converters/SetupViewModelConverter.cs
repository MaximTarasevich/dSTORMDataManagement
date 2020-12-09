using System;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class SetupViewModelConverter
    {
        public static SetupViewModel ToSetupViewModel(this SetupEntity entity)
        {
            SetupViewModel model = new SetupViewModel();
            model.Id = entity.Id;
            if(entity.AOTFilter != null)
            {
                model.AOTFilterId = entity.AOTFilter.Id;
                model.AOTFilter = entity.AOTFilter.ToAOTFilterViewModel();
            }
            if (entity.Camera != null)
            {
                model.CameraId = entity.Camera.Id;
                model.Camera = entity.Camera.ToCameraViewModel();
            }
            if (entity.Objective != null)
            {
                model.ObjectiveId = entity.Objective.Id;
                model.Objective = entity.Objective.ToObjectiveViewModel();
            }
            if (entity.Laser != null)
            {
                model.LaserId = entity.Laser.Id;
                model.Laser = entity.Laser.ToLaserViewModel();
            }
            if (entity.Microscope != null)
            {
                model.MicroscopeId = entity.Microscope.Id;
                model.Microscope = entity.Microscope.ToMicroscopeViewModel();
            }
            return model;
        }
        public static SetupEntity ToSetupEntity(this SetupViewModel model)
        {
            SetupEntity entity = new SetupEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.AOTFilterId = model.AOTFilterId;
            entity.CameraId = model.CameraId;
            entity.ObjectiveId = model.ObjectiveId;
            entity.LaserId = model.LaserId;
            entity.MicroscopeId = model.MicroscopeId;

            return entity;




        }
    }
}
