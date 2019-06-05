using System.Collections.Generic;

namespace DinnerPlans.Models
{
    internal static class MeasureUnits
    {
        public static Dictionary<UnitType , string> UnitMeasurementStrings = new Dictionary<UnitType , string>
        {
            { UnitType.Grams , "gr" },
            { UnitType.Milliliters , "ml" },
            { UnitType.Pieces , "pcs" },
        };
    }
}