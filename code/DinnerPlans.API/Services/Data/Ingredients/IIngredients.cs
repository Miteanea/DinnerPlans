using DinnerPlans.API.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data
{
    public interface IIngredients
    {
        Ingredient Get(Guid Id);
        IEnumerable<Ingredient> GetIngredients();
    }
}
