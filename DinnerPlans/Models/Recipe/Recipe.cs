using DinnerPlans.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject]
    public class Recipe
    {
        public Recipe()
        {
            ID = new RecipeID( DataHandler.GenerateUniqueRandomID() );
            NutritionData = new NutritionData( NutritionDataType.Recipe );
            IngredientEntries = new List<IngredientEntry>();
        }

        [JsonConstructor]
        public Recipe( List<IngredientEntry> ingredientEntries )
        {
            IngredientEntries = ingredientEntries;
        }

        // Public
        [JsonProperty]
        public RecipeID ID { get; set; }

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