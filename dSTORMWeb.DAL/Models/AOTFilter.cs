using System;
namespace dSTORMWeb.DAL.Models
{
    public class AOTFilter : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double IntensityValue { get; set; }
    }
}
