using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class LaserViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Name field is to long.")]
        public string Producer { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Name field is to long.")]
        public string Model { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Name field is to long.")]
        public string Type { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Accommodation invalid (0 - 1000).")]
        public double WaveLength { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Accommodation invalid (0 - 10000).")]
        public double MaxPower { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Accommodation invalid (0 - 10000).")]
        public double OutputPower { get; set; }

        [StringLength(255, ErrorMessage = "Description field is to long.")]
        public string DescriptionFORM { get; set; }
    }
}
