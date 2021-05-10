using DinnerPlans.API.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data.Recipes
{
    public class Recipes : IRecipes
    {
        public Recipe Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
