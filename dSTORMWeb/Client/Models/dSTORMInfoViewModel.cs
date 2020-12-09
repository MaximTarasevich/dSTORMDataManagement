using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class dSTORMInfoViewModel : ResponseModel
    {
        public int Id { get; set; }

        public int VideoFragmentId { get; set; }

        [Required]
        public double XCoord { get; set; }
        [Required]
        public double YCoord { get; set; }
    }
}
