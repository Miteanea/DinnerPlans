using DinnerPlans.Models;
using DinnerPlans.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DinnerPlans.Services
{
    /// <summary>
    /// Serves as a connection between Data and View;
    /// Conversion of Model to Viewodels is handled here
    /// </summary>
    internal static class RecipeDataHandler
    {
        public static int GenerateUniqueRandomID()
        {
            bool exists;
            int id;
            Random rnd = new Random();
            do
            {
                id = rnd.Next(int.MinValue, int.MaxValue);
                exists = Recipes.Count(recipe => recipe.ID.Value == id) > 0;
            } while (exists);

            return id;
        }

        internal static ObservableCollection<RecipeViewModel> GetRecipeViewModelsForListView()
        {
            ObservableCollection<RecipeViewModel> viewModels = new ObservableCollection<RecipeViewModel>();

            foreach (Recipe recipe in Recipes)
            {
                var recipeVM = MapRecipeToVM(recipe);
                viewModels.Add(recipeVM);
            }

            return viewModels;
        }

        public static RecipeViewModel GetRecipe(IId id)
        {
            var recipe = Recipes.FirstOrDefault(longRecipe => longRecipe.ID == id);

            var viewModel = MapRecipeToVM(recipe);

            return viewModel;
        }

        public static IngredientEntryViewModel CreateEntry(IngredientViewModel ingredient, RecipeViewModel recipeViewModel, int quantity = 0)
        {
            var entry = new IngredientEntryViewModel(quantity);

            entry.PropertyChanged += recipeViewModel.IngredientEntryChanges;
            entry.Ingredient = ingredient;

            return entry;
        }

        public static void SaveRecipe(RecipeViewModel recipeToSave)
        {
            var recipes = Recipes;

            if (recipes.Count(recipe => recipe.ID == recipeToSave.ID) == 0)
            {
                var recipe = new Recipe()
                {
                    ID = recipeToSave.ID,
                    IngredientEntries = recipeToSave.Ingredients.Select(ingredient =>
                       new IngredientEntry(ingredient)).ToList(),
                    Instruction = recipeToSave.Instruction,
                    NutritionData = recipeToSave.NutritionData,
                    Title = recipeToSave.Title
                };
                recipes.Add(recipe);
            }
        }

        public static List<Recipe> Recipes { get; set; }

        public static ILibraryUpdater<Recipe> libraryUpdater;

        private static RecipeViewModel MapRecipeToVM(Recipe recipe)
        {
            var VM = new RecipeViewModel();

            if (recipe != null)
            {
                VM.ID = recipe.ID;
                VM.Instruction = recipe.Instruction;
                VM.Title = recipe.Title;

                var ingredientsColl = recipe.IngredientEntries.Select(entry =>
                {
                    return new IngredientEntryViewModel(entry.Quantity)
                    {
                        Ingredient = new IngredientViewModel(
                          nutritionData: entry.Ingredient.NutritionData)
                        {
                            ID = entry.Ingredient.ID,
                            Name = entry.Ingredient.Name,
                            Unit = entry.Ingredient.Unit
                        },
                    };
                }).ToList();

                ObservableCollection<IngredientEntryViewModel> ingredientEntryViewModels = new ObservableCollection<IngredientEntryViewModel>();
                foreach (var item in ingredientsColl)
                {
                    ingredientEntryViewModels.Add(item);
                }

                VM.Ingredients = ingredientEntryViewModels;

                foreach (IngredientEntryViewModel entry in VM.Ingredients)
                {
                    entry.PropertyChanged += VM.IngredientEntryChanges;
                }

                VM.UpdateRecipe();
            }

            return VM;
        }
    }
}