using System;
namespace dSTORMWeb.DAL.Models
{
    public class VideoFragment : BaseModel
    {
        public int InitialVideoId { get; set; }

        public int FrameTime { get; set; }

        public byte[] Frame { get; set; }
    }
}
