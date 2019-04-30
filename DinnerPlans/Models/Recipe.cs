using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public RecipeID ID { get; set; }
        public string Title { get; set; }
        public Origin Origin { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public string Instruction { get; set; }

        public NutritionData NutritionData { get; }
    }

    internal enum Origin
    {
        None = 0,
        Italian,
        Thai,
        Russian
    }
}