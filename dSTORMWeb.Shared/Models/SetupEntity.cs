using System;
namespace dSTORMWeb.Shared.Models
{
    public class SetupEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AOTFilterId { get; set; }
        public AOTFilterEntity AOTFilter { get; set; }

        public int CameraId { get; set; }
        public CameraEntity Camera { get; set; }


        public int ObjectiveId { get; set; }
        public ObjectiveEntity Objective { get; set; }


        public int LaserId { get; set; }
        public LaserEntity Laser { get; set; }


        public int MicroscopeId { get; set; }
        public MicroscopeEntity Microscope { get; set; }

    }
}
