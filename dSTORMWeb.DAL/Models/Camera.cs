using System;
namespace dSTORMWeb.DAL.Models
{
    public class Camera : BaseModel
    {
        public string Objective { get; set; }

        public string Producer { get; set; }

        public double FocalLength { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string MatrixType { get; set; }
    }
}
