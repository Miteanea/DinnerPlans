using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Models
{
    internal class RecipeRpository
    {
        public RecipeRpository()
        {
            Recipes = new List<Recipe>();
        }

        public List<Recipe> Recipes { get; set; }
    }
}