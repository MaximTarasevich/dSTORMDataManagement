using System;
namespace dSTORMWeb.DAL.Models
{
    public class Experiment : BaseModel
    {
        public int PhysicalPropertyId { get; set; }
        public PhysicalProperty PhysicalProperty { get; set; }

        public int SetupId { get; set; }
        public Setup Setup { get; set; }

        public int FluorophoreId { get; set; }
        public Fluorophore Fluorophore { get; set; }

        public int ResearchObjectId { get; set; }
        public ResearchObject ResearchObject { get; set; }

        public string Name { get; set; }

    }
}
