using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace dSTORMWeb.Client.Models
{
    public class AuthorViewModel : ResponseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "First Name field is to long.")]
        public string FirstName { get; set; }

        [StringLength(45, ErrorMessage = "Middle Name field is to long.")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(45, ErrorMessage = "Last Name field is to long.")]
        public string LastName { get; set; }

        [StringLength(45, ErrorMessage = "Academic Rank field is to long.")]
        public string AcademicRank { get; set; }

        [JsonIgnore]
        [Required]
        public DateTime BirthdayDate { get; set; }

        public string FullName { get; set; }
    }
}
