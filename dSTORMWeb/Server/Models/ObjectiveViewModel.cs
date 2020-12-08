using System;
namespace dSTORMWeb.Server.Models
{
    public class ObjectiveViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Magnification { get; set; }

        public double Resolution { get; set; }

        public string EyePiece { get; set; }

        public string ObjectiveLens { get; set; }

        public string DescriptionFORM { get; set; }
    }
}
