using System;
namespace dSTORMWeb.Shared.Models
{
    public class ExperimentEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int InitialVideoId { get; set; }

        public int PhysicalPropertyId { get; set; }

        public int SetupId { get; set; }

        public int FluorophoreResearchObjectId { get; set; }
    }
}
