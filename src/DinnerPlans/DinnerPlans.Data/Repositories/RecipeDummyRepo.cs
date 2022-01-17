using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;

namespace DinnerPlans.Data.Repositories
{
    public class RecipeDummyRepo : IRecipeRepository
    {
        public IEnumerable<RecipeDocument> GetUserRecipes(List<Guid> recipes)
        {
            return RecipeDummyRepoStorage.Recipes.Where(_ => recipes.Contains(_.Id));
        }
    }

    public static class RecipeDummyRepoStorage
    {
        public static List<RecipeDocument> Recipes
        {
            get { return _recipes; }
        }

        private static List<RecipeDocument> _recipes = new List<RecipeDocument>()
        {
            new RecipeDocument()
            {
                Id = new Guid("")
            }
        };
    }
}