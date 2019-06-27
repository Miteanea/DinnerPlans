using DinnerPlans.Services;
using System.Collections.Generic;

namespace DinnerPlans.Models
{
    internal class RecipeRpository : IRecipeRpository
    {
        public RecipeRpository()
        {
            MetaData = new RepositoryData();
        }

        public RepositoryData MetaData { get; private set; }

        public List<Recipe> Recipes { get; set; }
    }
}