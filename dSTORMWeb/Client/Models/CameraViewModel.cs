using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class CameraViewModel: ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Producer field is to long.")]
        public string Objective { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Producer field is to long.")]
        public string Producer { get; set; }

        [Required]
        [Range(-1000, 1000, ErrorMessage = "Accommodation invalid (-1000 - 1000).")]
        public double FocalLength { get; set; }

        [StringLength(255, ErrorMessage = "Producer field is to long.")]
        public string DescriptionFORM { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Producer field is to long.")]
        public string Model { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Producer field is to long.")]
        public string MatrixType { get; set; }
    }
}
