using System;

namespace DinnerPlans.API.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public MeasurementUnit Unit { get; set; }
        public NutritionFacts NutritionFacts { get; set; }
    }
}