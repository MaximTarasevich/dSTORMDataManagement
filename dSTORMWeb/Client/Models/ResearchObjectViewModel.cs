using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class ResearchObjectViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
