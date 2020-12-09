using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class FinalImageViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        public double Resolution { get; set; }

        [Required]
        public string Format { get; set; }

        [Required]
        public int InitialVideoId { get; set; }
        public InitialVideoViewModel InitialVideo { get; set; }
        public string InitialVideoName { get; set; }

        [Required]
        public byte[] FinalImageBlob { get; set; }
    }
}
