using DinnerPlans.Models;

namespace DinnerPlans.ViewModels
{
    internal class EditRecipeViewModel
    {
        public EditRecipeViewModel( Recipe recipe )
        {
            if(recipe != null)
            {
                Recipe = recipe;
            }
            else
            {
                Recipe = new Recipe();
            }
        }

        public Recipe Recipe { get; set; }
    }
}