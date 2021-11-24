using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data.Recipes
{
    public class Filters : List<Filter>
    {
    }

    public class Filter
    {
        public string Property { get; set; }
        public string Value { get; set; }
    }
}