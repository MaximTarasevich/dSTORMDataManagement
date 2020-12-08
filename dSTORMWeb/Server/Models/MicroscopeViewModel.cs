using System;
namespace dSTORMWeb.Server.Models
{
    public class MicroscopeViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }
    }
}
