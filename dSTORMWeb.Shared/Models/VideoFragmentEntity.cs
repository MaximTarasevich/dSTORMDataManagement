using System;
namespace dSTORMWeb.Shared.Models
{
    public class VideoFragmentEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int InitialVideoId { get; set; }

        public int FrameTime { get; set; }

        public byte[] Frame { get; set; }
    }
}
