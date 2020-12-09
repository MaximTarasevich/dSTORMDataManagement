using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class FluorophoreViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Emission { get; set; }
        [Required]
        public double Absorption { get; set; }

        public string Class { get; set; }
    }
}
