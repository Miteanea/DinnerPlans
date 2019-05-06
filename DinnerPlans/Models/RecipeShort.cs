namespace DinnerPlans.Models
{
    internal class RecipeShort
    {
        public RecipeShort( Recipe recipe )
        {
            ID = recipe.ID;
            Title = recipe.Title;
            Origin = recipe.Origin;
        }

        public RecipeID ID { get; set; }
        public string Title { get; set; }
        public Origin Origin { get; set; }
    }
}