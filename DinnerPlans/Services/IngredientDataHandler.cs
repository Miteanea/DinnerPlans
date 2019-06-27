using DinnerPlans.Models;
using DinnerPlans.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DinnerPlans.Services
{
    internal static class IngredientDataHandler
    {
        public static int GenerateUniqueRandomID()
        {
            bool exists;
            int id;
            Random rnd = new Random();
            do
            {
                id = rnd.Next(int.MinValue, int.MaxValue);
                exists = Ingredients.Count(recipe => recipe.ID.Value == id) > 0;
            } while (exists);

            return id;
        }

        public static IngredientEntryViewModel CreateEntry(IngredientViewModel ingredient, RecipeViewModel recipeViewModel, int quantity = 0)
        {
            var entry = new IngredientEntryViewModel();
            entry.PropertyChanged += recipeViewModel.IngredientEntryChanges;

            entry.Ingredient.ID = ingredient.ID;
            entry.Ingredient.Name = ingredient.Name;
            entry.Ingredient.NutritionData = ingredient.NutritionData;
            entry.Ingredient.Unit = ingredient.Unit;

            entry.Quantity = quantity;
            return entry;
        }

        public static void SaveIngredient(IngredientViewModel ingredientToSave)
        {
            var ingredients = Ingredients;

            if (ingredients.Count(ingredient => ingredient.ID == ingredientToSave.ID) == 0)
            {
                var ingredient = new Ingredient()
                {
                    ID = ingredientToSave.ID,
                    Name = ingredientToSave.Name,
                    NutritionData = ingredientToSave.NutritionData,
                    Unit = ingredientToSave.Unit
                };

                ingredients.Add(ingredient);
            }
            else
            {
                var existingIngr = ingredients.FirstOrDefault(ingredient => ingredient.ID == ingredientToSave.ID);
                if (
                    existingIngr.ID != ingredientToSave.ID ||
                    existingIngr.Name != ingredientToSave.Name ||
                    existingIngr.NutritionData != ingredientToSave.NutritionData ||
                    existingIngr.Unit != ingredientToSave.Unit
                    )
                {
                    libraryUpdater.UpdateLibrary(Ingredients);
                }
            }
        }

        public static void SaveIngredientChanges()
        {
            var ingredients = Ingredients;
            throw new NotImplementedException();
        }

        public static List<Ingredient> Ingredients { get; set; }

        public static ILibraryUpdater<Ingredient> libraryUpdater;

        private static IngredientViewModel MapIngredientToVM(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        internal static ObservableCollection<Ingredient> GetIngredients()
        {
            var ingr = new ObservableCollection<Ingredient>();
            foreach (var ing in Ingredients)
            {
                ingr.Add(ing);
            }
            return ingr;
        }
    }
}