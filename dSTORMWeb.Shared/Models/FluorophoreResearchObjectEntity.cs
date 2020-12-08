using System;
namespace dSTORMWeb.Shared.Models
{
    public class FluorophoreResearchObjectEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int FluorophoreId { get; set; }

        public int ResearchObjectId { get; set; }
    }
}
