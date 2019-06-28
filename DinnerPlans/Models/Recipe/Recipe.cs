using DinnerPlans.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DinnerPlans.Models
{
    [JsonObject]
    public class Recipe
    {
        public Recipe()
        {
            ID = new RecipeID(RecipeDataHandler.GenerateUniqueRandomID());
            NutritionData = new NutritionData(NutritionDataType.Recipe);
            IngredientEntries = new List<IngredientEntry>();
        }

        [JsonConstructor]
        public Recipe(RecipeID iD, List<IngredientEntry> ingredientEntries)
        {
            IngredientEntries = ingredientEntries;
            this.ID = iD;
        }

        // Public
        public IId ID { get; set; }

        [JsonProperty]
        public string Instruction { get; set; }

        [JsonProperty]
        public NutritionData NutritionData { get; set; }

        public decimal TotalWeight { get; private set; }

        [JsonProperty]
        public string Title { get; set; }

        public List<IngredientEntry> IngredientEntries { get; set; }
    }
}