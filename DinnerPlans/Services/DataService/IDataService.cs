using DinnerPlans.Models;
using System.Collections.ObjectModel;

namespace DinnerPlans.Services.DataService
{
    public interface IDataService
    {
        void SaveRecipe(Recipe recipeToSave);

        void SaveIngredient(Ingredient ingredient);

        ObservableCollection<Recipe> Recipes { get; }
        ObservableCollection<Ingredient> Ingredients { get; }

        void DeleteRecipe(Recipe recipe);
    }
}