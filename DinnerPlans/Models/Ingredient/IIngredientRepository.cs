using DinnerPlans.Models;
using System.Collections.Generic;

namespace DinnerPlans.Services
{
    internal interface IIngredientRepository
    {
        List<Ingredient> Ingredients { get; set; }
        RepositoryData MetaData { get; }
    }
}