using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class AOTFilterViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Name field is to long.")]
        public string Name { get; set; }

        [StringLength(45, ErrorMessage = "Description field is to long.")]
        public string DescriptionFORM { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Accommodation invalid (0 - 1000).")]
        public double IntensityValue { get; set; }
    }
}
