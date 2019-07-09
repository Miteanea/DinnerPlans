using DinnerPlans.Services;

namespace DinnerPlans.Views.RecipesViews
{
    internal class EditEventArgs
    {
        public EditEventArgs(IId id)
        {
            RecipeId = id;
        }

        public IId RecipeId { get; set; }

    }
}