using System;
namespace dSTORMWeb.Shared.Models
{
    public class PhysicalPropertyEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public double Humidity { get; set; }

        public double Temperature { get; set; }
    }
}
