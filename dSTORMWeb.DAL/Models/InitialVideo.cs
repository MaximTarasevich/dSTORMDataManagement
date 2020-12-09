using System;
namespace dSTORMWeb.DAL.Models
{
    public class InitialVideo : BaseModel
    {
        public string Format { get; set; }

        public double Resolution { get; set; }

        public int FrameFrequency { get; set; }

        public double Size { get; set; }

        public double Duration { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public byte[] VideoBlob { get; set; }

        public int ExperimentId { get; set; }

    }
}
