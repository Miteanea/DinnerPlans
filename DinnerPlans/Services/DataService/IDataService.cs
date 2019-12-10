using DinnerPlans.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DinnerPlans.Services.DataService
{
    public interface IDataService
    {
        Task SaveRecipeAsync(Recipe recipeToSave);

        Task SaveIngredientAsync(Ingredient ingredient);

        ObservableCollection<Recipe> Recipes { get; set; }
        ObservableCollection<Ingredient> Ingredients { get; set; }

        Task DeleteRecipeAsync(Recipe recipe);

        Task DeleteIngredientAsync(Ingredient Ingredient);
    }
}