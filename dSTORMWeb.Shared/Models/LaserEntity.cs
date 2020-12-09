using System;
namespace dSTORMWeb.Shared.Models
{ 
    public class LaserEntity
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public double WaveLength { get; set; }

        public double MaxPower { get; set; }

        public double OutputPower { get; set; }

        public string Description { get; set; }
    }
}
