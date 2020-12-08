using System;
namespace dSTORMWeb.DAL.Models
{
    public class Experiment : BaseModel
    {
        public int InitialVideoId { get; set; }

        public int PhysicalPropertyId { get; set; }

        public int SetupId { get; set; }

        public int FluorophoreResearchObjectId { get; set; }
    }
}
