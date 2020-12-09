using System;
namespace dSTORMWeb.Server.Models
{
    public class FinalImageViewModel
    {
        public int Id { get; set; }

        public double Resolution { get; set; }

        public string Format { get; set; }

        public int InitialVideoId { get; set; }
        public InitialVideoViewModel InitialVideo { get; set; }
        public string InitialVideoName { get; set; }

        public byte[] FinalImageBlob { get; set; }

    }
}
