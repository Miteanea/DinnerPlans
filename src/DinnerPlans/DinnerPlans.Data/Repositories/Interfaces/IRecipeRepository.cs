using System;
using System.Collections.Generic;
using DinnerPlans.Data.DataObjects;

namespace DinnerPlans.Data.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<RecipeDocument> GetUserRecipes(List<Guid> recipes);
    }
}
