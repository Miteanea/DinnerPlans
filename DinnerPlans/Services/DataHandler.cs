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
        public static Recipe GetRecipe(RecipeID id)
        {
            return new Recipe();
        }

        internal static List<RecipeShort> GetRecipes(int pageSize)
        {
            return new List<RecipeShort>
            {
                new RecipeShort( new Recipe { Title = "Recipe 1 ", Origin = Origin.Thai } ),
                new RecipeShort( new Recipe { Title = "Recipe 2 ", Origin = Origin.Italian } ),
                new RecipeShort( new Recipe { Title = "Recipe 3", Origin = Origin.Russian } )
            };
        }
    }
}