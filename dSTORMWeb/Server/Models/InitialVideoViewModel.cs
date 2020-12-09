using System;
namespace dSTORMWeb.Server.Models
{
    public class InitialVideoViewModel
    {
        public int Id { get; set; }

        public string Format { get; set; }

        public double Resolution { get; set; }

        public int FrameFrequency { get; set; }

        public double Size { get; set; }

        public double Duration { get; set; }

        public string Name { get; set; }

        public string DescriptionFORM { get; set; }

        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }

        public byte[] VideoBlob { get; set; }

    }
}
