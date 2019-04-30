using DinnerPlans.Models;
using DinnerPlans.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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