using DinnerPlans.Models;
using DinnerPlans.Services;
using System.Collections.ObjectModel;

namespace DinnerPlans.ViewModels
{
    internal class RecipesListViewModel
    {
        public RecipesListViewModel()
        {
            Recipes = DataHandler.RecipeRepository.Recipes;
        }

        public ObservableCollection<Models.Recipe> Recipes { get; set; }
    }
}