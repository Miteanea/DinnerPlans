using System;
using System.Collections.Generic;
using DinnerPlans.Data.DataObjects;

namespace DinnerPlans.Data.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<IngredientDocument> GetIngredients(List<Guid> ingredients);
    }
}
