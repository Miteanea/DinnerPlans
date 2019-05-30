using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public enum UnitType
    {
        None = 0,
        Grams,
        Milliliters,
        Pieces
    }
}