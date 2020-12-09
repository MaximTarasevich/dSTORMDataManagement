using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class InitialVideoViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string Format { get; set; }

        [Required]
        [Range(0, 5000, ErrorMessage = "Accommodation invalid (0-5000).")]
        public double Resolution { get; set; }

        [Range(0, 120, ErrorMessage = "Accommodation invalid (0-120).")]
        public int FrameFrequency { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Accommodation invalid (0-100000).")]
        public double Size { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Accommodation invalid (0-1000).")]
        public double Duration { get; set; }

        [Required]
        public string Name { get; set; }

        public string DescriptionFORM { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }
        [Required]
        public byte[] VideoBlob { get; set; }

    }
}
