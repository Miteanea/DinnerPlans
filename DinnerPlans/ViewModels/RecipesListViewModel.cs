using DinnerPlans.Models;
using DinnerPlans.Services;
using System.Collections.Generic;

namespace DinnerPlans.ViewModels
{
    internal class RecipesListViewModel
    {
        public RecipesListViewModel()
        {
            Recipes = DataHandler.GetShortRecipes();
        }

        public List<RecipeShort> Recipes { get; set; }
    }
}