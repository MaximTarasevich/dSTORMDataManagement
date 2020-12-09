using System;
namespace dSTORMWeb.Server.Models
{
    public class FluorophoreViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Emission { get; set; }

        public double Absorption { get; set; }

        public string Class { get; set; }
    }
}
