using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class ObjectiveViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Name field is to long.")]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Accommodation invalid (0 - 1000).")]
        public double Magnification { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Accommodation invalid (0 - 1000).")]
        public double Resolution { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "EyePiece field is to long.")]
        public string EyePiece { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "ObjectiveLens field is to long.")]
        public string ObjectiveLens { get; set; }

        [StringLength(255, ErrorMessage = "Description field is to long.")]
        public string Description { get; set; }
    }
}
