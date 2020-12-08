using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class PhysicalPropertyViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 5000, ErrorMessage = "Accommodation invalid (0-5000).")]
        public double Humidity { get; set; }

        [Required]
        [Range(-1000, 1000, ErrorMessage = "Accommodation invalid (-1000 - 1000).")]
        public double Temperature { get; set; }
    }
}
