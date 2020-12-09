using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.DAL.Converters
{
    public static class SetupConverter
    {
        public static Setup ToSetup(this SetupEntity newEntity, Setup oldEntity = null)
        {
            Setup entity = oldEntity;
            if (entity == null)
            {
                entity = new Setup();

            }
            entity.AOTFilterId = newEntity.AOTFilterId;
            entity.CameraId = newEntity.CameraId;
            entity.ObjectiveId = newEntity.ObjectiveId;
            entity.LaserId = newEntity.LaserId;
            entity.MicroscopeId = newEntity.MicroscopeId;
           // if(newEntity.AOTFilter != null)
           //     entity.AOTFilterId = newEntity.AOTFilter.Id;
           // if (newEntity.Camera != null)
            //    entity.CameraId = newEntity.Camera.Id;
           // if (newEntity.Objective != null)
           //     entity.ObjectiveId = newEntity.Objective.Id;
          //  if (newEntity.Laser != null)
          //      entity.LaserId = newEntity.Laser.Id;
          //  if (newEntity.Microscope != null)
          //      entity.MicroscopeId = newEntity.Microscope.Id;

            return entity;
        }


        public static SetupEntity ToSetupEntity(this Setup model)
        {
            if (model == null)
                return null;

            SetupEntity entity = new SetupEntity();
            entity.Id = model.Id;

            if (model.AOTFilter != null)
                entity.AOTFilter = model.AOTFilter.ToAOTFilterEntity();
            if (model.Camera != null)
                entity.Camera = model.Camera.ToCameraEntity();
            if (model.Objective != null)
                entity.Objective = model.Objective.ToObjectiveEntity();
            if (model.Laser != null)
                entity.Laser = model.Laser.ToLaserEntity();
            if (model.Microscope != null)
                entity.Microscope = model.Microscope.ToMicroscopeEntity();


            return entity;
        }

        public static IEnumerable<SetupEntity> ToSetupEntityCollection(this IEnumerable<Setup> items)
        {
            List<SetupEntity> models = new List<SetupEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToSetupEntity()));

            return models;
        }
    }
}
