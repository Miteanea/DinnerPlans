using System.Collections.Generic;

namespace DinnerPlans.Models
{
    internal class Recipe
    {
        public Recipe()
        {
            ID = GetID();
        }

        private RecipeID GetID()
        {
            return new RecipeID();
        }

        public RecipeID ID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public Origin Origin
        {
            get; set;
        }

        public List<Ingredient> Ingredients
        {
            get; set;
        }

        public string Instruction
        {
            get; set;
        }

        public int QuantityGr
        {
            get; set;
        }

        public NutritionData NutritionData
        {
            get
            {
                return _nutritionData;
            }
        }

        private NutritionData _nutritionData;

        // When the Ingredients list is modified Recalculate _nutritionData of a Recipe
    }

    internal enum Origin
    {
        None = 0,
        Italian,
        Thai,
        Russian
    }
}