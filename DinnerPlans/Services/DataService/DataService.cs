using DinnerPlans.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DinnerPlans.Services.DataService

{
    internal class DataService : IDataService
    {
        public DataService()
        {
            var factory = new RepositoryFactory();
            var recipeRepo = factory.GetRecipeRepository();
            var ingredientRepo = factory.GetIngredientRepository();

            var repoLoader = new RepositoryLoader();

            recipeRepo = repoLoader.CheckRecipeLibrary(recipeRepo);
            ingredientRepo = repoLoader.CheckIngredientsLibrary(ingredientRepo);

            Recipes = recipeRepo.Recipes;
            Ingredients = ingredientRepo.Ingredients;

            _recipeRepositoryPath = recipeRepo.MetaData.FullPath;
            _ingredientRepositoryPath = ingredientRepo.MetaData.FullPath;
        }

        private string _recipeRepositoryPath;
        private string _ingredientRepositoryPath;

        ObservableCollection<Recipe> IDataService.Recipes { get { return new ObservableCollection<Recipe>(Recipes); } }
        ObservableCollection<Ingredient> IDataService.Ingredients { get { return new ObservableCollection<Ingredient>(Ingredients); } }

        void IDataService.SaveRecipe(Recipe recipeToSave)
        {
            int idCountInRepository = Recipes.Count(presentRecipe => presentRecipe.ID == recipeToSave.ID);
            bool recipeExists = (idCountInRepository == 1) && recipeToSave.ID != 0;
            bool recipeIdIsDoubled = idCountInRepository > 1;

            if (recipeIdIsDoubled)
            {
                throw new Exception("DataSource is corrupt, doubled IDs");
            }
            else if (recipeExists && !recipeIdIsDoubled)
            {
                Recipes.Remove(Recipes[recipeToSave.ID - 1]);
                Recipes.Add(recipeToSave);
            }
            else if (!recipeExists && !recipeIdIsDoubled)
            {
                recipeToSave.ID = Recipes.Count + 1;
                Recipes.Add(recipeToSave);
            }

            UpdateRecipeRepoFile();
        }

        private void UpdateRecipeRepoFile()
        {
            string serializedRepo = JsonConvert.SerializeObject(Recipes, Formatting.Indented);

            File.WriteAllText(_recipeRepositoryPath, serializedRepo, Encoding.UTF8);
        }

        void IDataService.SaveIngredient(Ingredient ingredientToSave)
        {
            int idCountInRepository = Recipes.Count(presentRecipe => presentRecipe.ID == ingredientToSave.ID);
            bool ingredientExists = (idCountInRepository == 1) && ingredientToSave.ID != 0;
            bool ingredientIdIsDoubled = idCountInRepository > 1;

            if (ingredientIdIsDoubled)
            {
                throw new Exception("DataSource is corrupt, doubled IDs");
            }
            else if (ingredientExists && !ingredientIdIsDoubled)
            {
                Ingredients.Remove(Ingredients[ingredientToSave.ID - 1]);
                Ingredients.Add(ingredientToSave);
            }
            else if (!ingredientExists && !ingredientIdIsDoubled)
            {
                ingredientToSave.ID = Ingredients.Count + 1;
                Ingredients.Add(ingredientToSave);
            }

            //if (ingredients.Count(ingredient => ingredient.ID == ingredientToSave.ID) == 0)
            //{
            //    var ingredient = new Ingredient()
            //    {
            //        ID = ingredientToSave.ID,
            //        Name = ingredientToSave.Name,
            //        NutritionData = ingredientToSave.NutritionData,
            //        Unit = ingredientToSave.Unit
            //    };

            //    ingredients.Add(ingredient);
            //}
            //else
            //{
            //    var existingIngr = ingredients.FirstOrDefault(ingredient => ingredient.ID == ingredientToSave.ID);
            //    if (
            //        existingIngr.ID != ingredientToSave.ID ||
            //        existingIngr.Name != ingredientToSave.Name ||
            //        existingIngr.NutritionData != ingredientToSave.NutritionData ||
            //        existingIngr.Unit != ingredientToSave.Unit
            //        )
            //    {
            //        libraryUpdater.UpdateLibrary(Ingredients);
            //    }
            //}

            UpdateIngredientRepoFile();
            throw new NotImplementedException();
        }

        private void UpdateIngredientRepoFile()
        {
            string serializedRepo = JsonConvert.SerializeObject(Ingredients, Formatting.Indented);

            File.WriteAllText(_ingredientRepositoryPath, serializedRepo, Encoding.UTF8);
        }

        public static List<Recipe> Recipes { get; set; }
        public static List<Ingredient> Ingredients { get; set; }

        public static void SaveIngredientChanges()
        {
            var ingredients = Ingredients;

            throw new NotImplementedException();
        }

        void IDataService.DeleteRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
            UpdateRecipeRepoFile();
        }
    }
}