using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class SetupViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        public int AOTFilterId { get; set; }
        public AOTFilterViewModel AOTFilter { get; set; }
        public string FilterName { get; set; }

        [Required]
        public int CameraId { get; set; }
        public CameraViewModel Camera { get; set; }
        public string CameraName { get; set; }

        [Required]
        public int ObjectiveId { get; set; }
        public ObjectiveViewModel Objective { get; set; }
        public string ObjectiveName { get; set; }

        [Required]
        public int LaserId { get; set; }
        public LaserViewModel Laser { get; set; }
        public string LaserName { get; set; }

        [Required]
        public int MicroscopeId { get; set; }
        public MicroscopeViewModel Microscope { get; set; }
        public string MicroscopeName { get; set; }
    }
}
