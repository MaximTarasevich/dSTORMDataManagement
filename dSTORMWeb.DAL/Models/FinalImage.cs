using System;
namespace dSTORMWeb.DAL.Models
{
    public class FinalImage : BaseModel
    {
        public double Resolution { get; set; }

        public string Format { get; set; }

        public int InitialVideoId { get; set; }


    }
}
