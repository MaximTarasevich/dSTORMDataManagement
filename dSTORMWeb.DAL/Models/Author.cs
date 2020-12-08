using System;
namespace dSTORMWeb.DAL.Models
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AcademicRank { get; set; }
    }
}
