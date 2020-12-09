using System;
namespace dSTORMWeb.Shared.Models
{
    public class ExperimentEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PhysicalPropertyId { get; set; }
        public PhysicalPropertyEntity PhysicalProperty { get; set; }

        public int SetupId { get; set; }
        public SetupEntity Setup { get; set; }

        public int FluorophoreId { get; set; }
        public FluorophoreEntity Fluorophore { get; set; }

        public int ResearchObjectId { get; set; }
        public ResearchObjectEntity ResearchObject { get; set; }

        public string Name { get; set; }

    }
}
