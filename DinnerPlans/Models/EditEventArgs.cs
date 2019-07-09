using DinnerPlans.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Views.RecipesViews
{
    class EditEventArgs : EventArgs
    {
        public EditEventArgs( IId recipeId)
        {
            RecipeId = recipeId;
        }
        public IId  RecipeId { get; set; }
    }
}
