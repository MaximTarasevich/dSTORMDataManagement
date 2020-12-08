using System;
namespace dSTORMWeb.Shared.Models
{
    public class ObjectiveEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public double Magnification { get; set; }

        public double Resolution { get; set; }

        public string EyePiece { get; set; }

        public string ObjectiveLens { get; set; }

        public string Description { get; set; }
    }
}
