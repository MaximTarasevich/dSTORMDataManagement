using System;
namespace dSTORMWeb.Shared.Models
{
    public class MicroscopeEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

    }
}
