using DinnerPlans.Models;
using System.Collections.ObjectModel;

namespace DinnerPlans.ViewModels
{
    internal class RecipeViewModel
    {
        public RecipeViewModel( Recipe recipe )
        {
            ID = recipe.ID;
            Instruction = recipe.Instruction;
            NutritionData = recipe.NutritionData;
            Title = recipe.Title;
            Ingredients = recipe.Ingredients;
        }

        public RecipeID ID { get; set; }

        public string Instruction { get; set; }

        public NutritionData NutritionData { get; set; }

        public string Title { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
    }
}