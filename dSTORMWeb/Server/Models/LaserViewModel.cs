using System;
namespace dSTORMWeb.Server.Models
{
    public class LaserViewModel
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public double WaveLength { get; set; }

        public double MaxPower { get; set; }

        public double OutputPower { get; set; }

        public string DescriptionFORM { get; set; }
        public string Name { get; set; }

    }
}
