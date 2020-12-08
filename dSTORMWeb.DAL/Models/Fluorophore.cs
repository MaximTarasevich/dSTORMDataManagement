using System;
namespace dSTORMWeb.DAL.Models
{
    public class Fluorophore : BaseModel
    {
        public string Name { get; set; }

        public double Emission { get; set; }

        public double Absorption { get; set; }

        public string Class { get; set; }
    }
}
