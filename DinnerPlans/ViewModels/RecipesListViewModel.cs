using DinnerPlans.Models;
using System.Collections.ObjectModel;

namespace DinnerPlans.ViewModels
{
    internal class RecipesListViewModel
    {
        public ObservableCollection<RecipeViewModel> Recipes { get; set; }
    }
}