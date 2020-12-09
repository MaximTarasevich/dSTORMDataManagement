using System;
namespace dSTORMWeb.Server.Models
{
    public class VideoFragmentViewModel
    {
        public int Id { get; set; }

        public int InitialVideoId { get; set; }

        public int FrameTime { get; set; }

        public byte[] Frame { get; set; }
    }
}
