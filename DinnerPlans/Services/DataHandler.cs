using DinnerPlans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Services
{
    internal static class DataHandler
    {
        static DataHandler()
        {
        }

        public static Recipe GetRecipe(RecipeID id)
        {
            var recipe = MockRecipes.
                            Where(longRecipe => longRecipe.ID == id).
                            FirstOrDefault();

            return recipe;
        }

        internal static List<RecipeShort> GetShortRecipes()
        {
            var shortRecipeList = new List<RecipeShort>();

            foreach (var longRecipe in MockRecipes)
            {
                var shortRecipe = new RecipeShort(longRecipe);
                shortRecipeList.Add(shortRecipe);
            }
            return shortRecipeList;
        }

        private static List<Recipe> MockRecipes = new List<Recipe>
            {
                 new Recipe { ID = new RecipeID(), Title = "Recipe 1 ", Origin = Origin.Thai   , Instruction = "Instruction 1", Ingredients = new List<Ingredient> { new Ingredient{ Name = "Ing1" , Quantity = 1 } } },
                 new Recipe { ID = new RecipeID(), Title = "Recipe 2 ", Origin = Origin.Italian, Instruction = "Instruction 2", Ingredients = new List<Ingredient> { new Ingredient{ Name = "Ing2" , Quantity = 2 } } },
                 new Recipe { ID = new RecipeID(), Title = "Recipe 3", Origin = Origin.Russian , Instruction = "Instruction 3", Ingredients = new List<Ingredient> { new Ingredient{ Name = "Ing3" , Quantity = 3 } } }
            };

        internal static void SaveRecipe(RecipeID iD)
        {
            throw new NotImplementedException();
        }
    }
}