using System;
namespace dSTORMWeb.DAL.Models
{
    public class PhysicalProperty : BaseModel 
    {
        public double Humidity { get; set; }

        public double Temperature { get; set; }
    }
}
