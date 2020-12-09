using System;
namespace dSTORMWeb.Shared.Models
{
    public class InitialVideoEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Format { get; set; }

        public double Resolution { get; set; }

        public int FrameFrequency { get; set; }

        public double Size { get; set; }

        public double Duration { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }

        public byte[] VideoBlob { get; set; }

    }
}
