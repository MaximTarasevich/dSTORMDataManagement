using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class VideoFragmentViewModel : ResponseModel
    {
        public int Id { get; set; }

        public int InitialVideoId { get; set; }

        [Required]
        public int FrameTime { get; set; }

        [Required]
        public byte[] Frame { get; set; }
    }
}
