using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using dSTORMWeb.Shared;
using dSTORMWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dSTORMWeb.Server.Helpers
{
    public class FilterHelper
    {
        public static Dictionary<string, FilterEntity> BuildBasicFilter(HttpContext context)
        {
            Dictionary<string, FilterEntity> Filters = new Dictionary<string, FilterEntity>();
            var query = context.Request.Query;
            var queryItems = context.Request.Query.ToDictionary(t => t.Key, t => t.Value);
            if (queryItems.Count > 0)
            {
                foreach (var item in queryItems)
                {
                    var filterKey = item.Key.ToString();
                    if (filterKey == "$filter")
                    {

                    }
                    else if (!filterKey.Contains("$"))
                    {
                        var datafield = item.Key;
                        var datavalue = item.Value;
                        if (Filters.ContainsKey(datafield))
                            Filters.Remove(datafield);
                        Filters.Add(datafield, new FilterEntity() { Name = datafield, Type = FilterType.String, Value = new List<string>() { datavalue } });

                        /*if (Filters.ContainsKey(FilterNames.CREATEDON) && datafield == FilterNames.CREATEDON || Filters.ContainsKey(FilterNames.PUBLICATIONDATE) && datafield == FilterNames.PUBLICATIONDATE)
                        {
                            var def = new { eDate = "", sDate = "" };
                            var dates = JsonConvert.DeserializeAnonymousType(datavalue, def);
                            if (!DateTime.TryParseExact(dates.sDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime stDate))
                            {
                                continue;
                            }
                            if (!DateTime.TryParseExact(dates.eDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime enDate))
                            {
                                continue;
                            }
                            Filters.Remove(datafield);
                            Filters.Add(datafield, new FilterEntity() { Name = datafield, Type = FilterType.DateTime, ValueDateTime = new List<DateTime?>() { stDate }, ValueDateTimeEnd = new List<DateTime?>() { enDate } });

                        }
                        if (Filters.ContainsKey(FilterNames.ISBLOCKED) && datafield == FilterNames.ISBLOCKED)
                        {
                            Filters.Remove(FilterNames.ISBLOCKED);
                            Filters.Add(datafield, new FilterEntity() { Name = datafield, Type = FilterType.Boolean, ValueBool = new List<bool?>() { bool.Parse(datavalue) } });
                        }*/

                    }


                }
            }

            return Filters;
        }


        public static Dictionary<string, FilterEntity> BuildMicroscopeFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;

               
            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildPhysicalPropertiesFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }

        public static Dictionary<string, FilterEntity> BuildObjectiveFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }

        public static Dictionary<string, FilterEntity> BuildLaserFilter(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildCameraFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildAOTFilterFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildAuthorFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildSetupFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
        public static Dictionary<string, FilterEntity> BuildInitialVideoFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }

        public static Dictionary<string, FilterEntity> BuildVideoFragmentFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }

        public static Dictionary<string, FilterEntity> BuilddSTORMFilters(HttpContext context)
        {
            Dictionary<string, FilterEntity> filters = BuildBasicFilter(context);

            var query = context.Request.Query;


            return filters;
        }
    }
}
