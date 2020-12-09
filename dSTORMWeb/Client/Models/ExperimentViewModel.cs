using System;
using System.ComponentModel.DataAnnotations;

namespace dSTORMWeb.Client.Models
{
    public class ExperimentViewModel : ResponseModel
    {

        public int Id { get; set; }

        [Required]
        public int? PhysicalPropertyId { get; set; }
        public PhysicalPropertyViewModel PhysicalProperty { get; set; }
        public string PhysicalPropertyName { get; set; }

        [Required]
        public int? SetupId { get; set; }
        public SetupViewModel Setup { get; set; }
        public string SetupName { get; set; }

        [Required]
        public int? FluorophoreId { get; set; }
        public FluorophoreViewModel Fluorophore { get; set; }
        public string FluorophoreName { get; set; }

        [Required]
        public int? ResearchObjectId { get; set; }
        public ResearchObjectViewModel ResearchObject { get; set; }
        public string ResearchObjectName { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
