using DinnerPlans.Models;
using System.Collections.Generic;

namespace DinnerPlans.Services
{
    internal class IngredientRepository : IIngredientRepository
    {
        public IngredientRepository()
        {
            MetaData = new RepositoryData();
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }

        public RepositoryData MetaData { get; private set; }
    }
}