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
            Ingredients = recipe.IngredientEntries;
        }

        public RecipeID ID { get; set; }

        public string Instruction { get; set; }

        public NutritionData NutritionData { get; set; }

        public string Title { get; set; }

        public ObservableCollection<IngredientEntry> Ingredients { get; set; }
    }
}