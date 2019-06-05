using System.Collections.ObjectModel;

namespace DinnerPlans.Models
{
    internal interface IRecipe
    {
        RecipeID ID { get; set; }
        ObservableCollection<Ingredient> Ingredients { get; set; }
        string Instruction { get; set; }
        NutritionData NutritionData { get; set; }
        string Title { get; set; }
    }
}