using System;
namespace dSTORMWeb.Shared.Models
{
    public class SetupEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AOTFilterId { get; set; }

        public int CameraId { get; set; }

        public int ObjectiveId { get; set; }

        public int LaserId { get; set; }

        public int MicroscopeId { get; set; }
    }
}
