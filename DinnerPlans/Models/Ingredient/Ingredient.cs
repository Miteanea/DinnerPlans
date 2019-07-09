using DinnerPlans.Services;
using Newtonsoft.Json;

namespace DinnerPlans.Models
{
    [JsonObject]
    public class Ingredient
    {
        public Ingredient()
        {
            ID = GetID();
            _nutritionData = new NutritionData(NutritionDataType.Ingredient);
        }

        [JsonConstructor]
        public Ingredient(IngredientID iD, NutritionData nutritionData)
        {
            ID = iD;
            NutritionData = nutritionData;
        }

        // Public
        public IId ID { get; set; }

        public string Name { get; set; }

        public UnitType Unit { get; set; }

        public NutritionData NutritionData { get; set; }

        // Private
        private IngredientID GetID()
        {
            return new IngredientID(IngredientDataHandler.GenerateUniqueRandomID());
        }

        private NutritionData _nutritionData;
    }
}