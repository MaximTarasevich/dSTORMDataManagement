using System;
namespace dSTORMWeb.Shared.Models
{
    public class dSTORMInfoEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int VideoFragmentId { get; set; }

        public double XCoord { get; set; }

        public double YCoord { get; set; }
    }
}
