using DinnerPlans.Models;
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
            Recipes = GetRecipes();
        }

        public List<Recipe> Recipes { get; set; }

        private List<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe{ Title = "Recipe 1 ", Origin = Origin.Thai },
                new Recipe{ Title = "Recipe 2 ", Origin = Origin.Italian },
                new Recipe{ Title = "Recipe 3" , Origin = Origin.Russian}
            };
        }
    }
}