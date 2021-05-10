using System.Collections.Generic;

namespace DinnerPlans.API.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public NutritionFacts NutritionFacts { get; set; }
    }
}
