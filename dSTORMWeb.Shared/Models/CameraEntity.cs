using System;
namespace dSTORMWeb.Shared.Models
{
    public class CameraEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Objective { get; set; }

        public string Producer { get; set; }

        public double FocalLength { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string MatrixType { get; set; }
    }
}
