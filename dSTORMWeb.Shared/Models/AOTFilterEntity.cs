using System;
namespace dSTORMWeb.Shared.Models
{
    public class AOTFilterEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double IntensityValue { get; set; }
    }
}
