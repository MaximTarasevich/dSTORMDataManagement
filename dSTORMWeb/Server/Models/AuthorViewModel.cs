using System;
namespace dSTORMWeb.Server.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AcademicRank { get; set; }

        public DateTime BirthdayDate { get; set; }

        public string FullName { get; set; }
    }
}
