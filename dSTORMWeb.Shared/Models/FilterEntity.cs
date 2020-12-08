using System;
using System.Collections.Generic;

namespace dSTORMWeb.Shared.Models
{
    public class FilterEntity
    {

        public string Name { get; set; }

        public FilterCondition Condition { get; set; }

        public FilterType Type { get; set; }

        public List<string> Value { get; set; }
        public List<int?> ValueInt { get; set; }
        public List<bool?> ValueBool { get; set; }
        public List<DateTime?> ValueDateTime { get; set; }
        public List<DateTime?> ValueDateTimeEnd { get; set; }
    }


    public enum FilterType
    {
        String,
        Integer,
        Boolean,
        DateTime
    }

    public enum FilterCondition
    {
        Equal,
        NotEqual,
        Contains,
        NotContains
    }
}
