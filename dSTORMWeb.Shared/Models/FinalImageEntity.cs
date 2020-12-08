using System;
namespace dSTORMWeb.Shared.Models
{
    public class FinalImageEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public double Resolution { get; set; }

        public string Format { get; set; }

        public int InitialVideoId { get; set; }


    }
}
