using System;
namespace dSTORMWeb.DAL.Models
{
    public class FinalImage : BaseModel
    {
        public double Resolution { get; set; }

        public string Format { get; set; }

        public int InitialVideoId { get; set; }
        public InitialVideo InitialVideo { get; set; }

        public byte[] FinalImageBlob { get; set; }

    }
}
