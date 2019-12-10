using DinnerPlans.Models;
using DinnerPlans.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerPlans.Services.DataService

{
    internal class DataService : IDataService
    {
        public DataService(DinnerPlansContext dinnerPlansContext)
        {
            _db = dinnerPlansContext;

            var recipes = _db.Recipes.Include(r => r.Ingredients).ToList();

            Recipes = new ObservableCollection<Recipe>(recipes);
            Ingredients = new ObservableCollection<Ingredient>(_db.Ingredients);
        }

        private readonly DinnerPlansContext _db;

        public ObservableCollection<Recipe> Recipes { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        async Task IDataService.SaveRecipeAsync(Recipe recipeToSave)
        {
            bool existingRecipe = Recipes.
                    Where(recipe => recipe.RecipeId == recipeToSave.RecipeId).
                    Count() > 0 ? true : false;

            if (!existingRecipe)
            {
                Recipes.Add(recipeToSave);
                _db.Recipes.Add(recipeToSave);
                _db.Entry(recipeToSave).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            _db.Entry(recipeToSave).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        async Task IDataService.SaveIngredientAsync(Ingredient ingredientToSave)
        {
            bool existingIngredient = _db.Ingredients.
                       Where(ingredient => ingredient.IngredientId == ingredientToSave.IngredientId).
                       Count() > 0 ? true : false;

            if (!existingIngredient)
            {
                Ingredients.Add(ingredientToSave);
                _db.Ingredients.Add(ingredientToSave);
            }

            await _db.SaveChangesAsync();
        }

        async Task IDataService.DeleteRecipeAsync(Recipe recipe)
        {
            Recipes.Remove(recipe);
            _db.Recipes.Remove(recipe);
            await _db.SaveChangesAsync();
        }

        async Task IDataService.DeleteIngredientAsync(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
            _db.Ingredients.Remove(ingredient);
            await _db.SaveChangesAsync();
        }
    }
}