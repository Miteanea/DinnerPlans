using DinnerPlans.API.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data.Recipes
{
    public interface IRecipes
    {
        Recipe Get(Guid guid);
        IEnumerable<Recipe> GetRecipes();
    }
}
