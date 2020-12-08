using System;
namespace dSTORMWeb.DAL.Models
{
    public class Objective : BaseModel
    {
        public string Name { get; set; }

        public double Magnification { get; set; }

        public double Resolution { get; set; }

        public string EyePiece { get; set; }

        public string ObjectiveLens { get; set; }

        public string Description { get; set; }
    }
}
