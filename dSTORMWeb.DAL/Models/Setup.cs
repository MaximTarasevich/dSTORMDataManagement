using System;
namespace dSTORMWeb.DAL.Models
{
    public class Setup : BaseModel
    {
        public int AOTFilterId { get; set; }
        public AOTFilter AOTFilter { get; set; }

        public int CameraId { get; set; }
        public Camera Camera { get; set; }

        public int ObjectiveId { get; set; }
        public Objective Objective { get; set; }

        public int LaserId { get; set; }
        public Laser Laser { get; set; }

        public int MicroscopeId { get; set; }
        public Microscope Microscope { get; set; }
    }
}
