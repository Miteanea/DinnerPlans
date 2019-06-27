using DinnerPlans.Services;
using DinnerPlans.Services.LibraryUpdaters;
using System.Windows;

namespace DinnerPlans
{
    public partial class App : Application
    {
        public App()
        {
            LoadRepositories();
        }

        private void LoadRepositories()
        {
            var factory = new RepositoryFactory();
            var recipeRepo = factory.GetRecipeRepository();
            var ingredientRepo = factory.GetIngredientRepository();

            var repoLoader = new RepositoryLoader();

            recipeRepo = repoLoader.CheckRecipeLibrary(recipeRepo);
            ingredientRepo = repoLoader.CheckIngredientsLibrary(ingredientRepo);

            RecipeDataHandler.Recipes = recipeRepo.Recipes;
            RecipeDataHandler.libraryUpdater = new RecipeLibraryUpdater(recipeRepo.MetaData.FullPath);

            IngredientDataHandler.Ingredients = ingredientRepo.Ingredients;
            IngredientDataHandler.libraryUpdater = new IngredientLibraryUpdater(ingredientRepo.MetaData.FullPath);
        }
    }
}