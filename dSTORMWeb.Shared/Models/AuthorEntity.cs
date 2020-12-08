using System;
namespace dSTORMWeb.Shared.Models
{
    public class AuthorEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AcademicRank { get; set; }
    }
}
