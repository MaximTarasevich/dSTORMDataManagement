﻿using System;
namespace dSTORMWeb.Server.Models
{
    public class SetupViewModel
    {
        public int Id { get; set; }

        public int AOTFilterId { get; set; }
        public AOTFilterViewModel AOTFilter { get; set; }
        public string FilterName { get; set; }

        public int CameraId { get; set; }
        public CameraViewModel Camera { get; set; }
        public string CameraName { get; set; }

        public int ObjectiveId { get; set; }
        public ObjectiveViewModel Objective { get; set; }
        public string ObjectiveName { get; set; }

        public int LaserId { get; set; }
        public LaserViewModel Laser { get; set; }
        public string LaserName { get; set; }

        public int MicroscopeId { get; set; }
        public MicroscopeViewModel Microscope { get; set; }
        public string MicroscopeName { get; set; }

        public string Name { get; set; }
    }
}
