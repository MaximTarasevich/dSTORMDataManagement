using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class MicroscopeViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45,ErrorMessage = "Producer field is to long.")]
        public string Producer { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Model field is to long.")]
        public string Model { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Type field is to long.")]
        public string Type { get; set; }
    }
}
