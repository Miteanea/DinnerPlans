namespace DinnerPlans.Views.RecipesViews
{
    internal class EditEventArgs
    {
        public EditEventArgs(int id)
        {
            RecipeId = id;
        }

        public int RecipeId { get; set; }
    }
}