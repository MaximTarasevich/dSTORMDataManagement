using System;
namespace dSTORMWeb.Server.Models
{
    public class ExperimentViewModel
    {
        public int Id { get; set; }

        public int PhysicalPropertyId { get; set; }
        public PhysicalPropertyViewModel PhysicalProperty { get; set; }
        public string PhysicalPropertyName { get; set; }

        public int SetupId { get; set; }
        public SetupViewModel Setup { get; set; }
        public string SetupName { get; set; }

        public int FluorophoreId { get; set; }
        public FluorophoreViewModel Fluorophore { get; set; }
        public string FluorophoreName { get; set; }

        public int ResearchObjectId { get; set; }
        public ResearchObjectViewModel ResearchObject { get; set; }
        public string ResearchObjectName { get; set; }

        public string Name { get; set; }
    }
}
