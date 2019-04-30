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
                 new Recipe { ID = new RecipeID(), Title = "Recipe 1 ", Origin = Origin.Thai } ,
                 new Recipe { ID = new RecipeID(), Title = "Recipe 2 ", Origin = Origin.Italian } ,
                 new Recipe { ID = new RecipeID(), Title = "Recipe 3", Origin = Origin.Russian }
            };
    }
}