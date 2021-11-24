using DinnerPlans.API.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.DataAccess
{
    public interface IRecipeDataBase
    {
        List<Recipe> GetAllRecipes();
        List<Recipe> GetAllRecipesForUser(Guid userId);
    }
}
