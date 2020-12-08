using System;
namespace dSTORMWeb.DAL.Models
{
    public class Setup : BaseModel
    {
        public int AOTFilterId { get; set; }

        public int CameraId { get; set; }

        public int ObjectiveId { get; set; }

        public int LaserId { get; set; }

        public int MicroscopeId { get; set; }
    }
}
