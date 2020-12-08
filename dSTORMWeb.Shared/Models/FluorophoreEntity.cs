using System;
namespace dSTORMWeb.Shared.Models
{
    public class FluorophoreEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public double Emission { get; set; }

        public double Absorption { get; set; }

        public string Class { get; set; }
    }
}
