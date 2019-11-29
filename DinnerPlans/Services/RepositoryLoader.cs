using DinnerPlans.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace DinnerPlans.Services
{
    internal class RepositoryLoader
    {
        internal RecipeRpository CheckRecipeLibrary(RecipeRpository recipeRepository)
        {
            // Check if the Recipe Library is Present in the default Folder
            var metaData = recipeRepository.MetaData;
            if (LibraryIsInFolder(metaData.DefaultRepoFolder, metaData.Type))
            {
                metaData.RepoFolderPath = metaData.DefaultRepoFolder;
            }
            else
            {
                ShowRepoNotFoundInDefaultFolderMessage(metaData.Type);

                metaData.RepoFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if (metaData.RepoFolderPath != null)
            {
                recipeRepository.Recipes = LoadRepo(metaData.RepoFolderPath + metaData.RepoName, metaData.Type) as List<Recipe>;
            }
            else
            {
                MessageBox.Show("Fatal Error in DataHandler");
                throw new Exception("Fatal Error in Datahandler.CheckRecipeLibrary()");
            }

            return recipeRepository;
        }

        internal IngredientRepository CheckIngredientsLibrary(IngredientRepository ingredientsRepository)
        {
            var metaData = ingredientsRepository.MetaData;
            if (LibraryIsInFolder(metaData.DefaultRepoFolder, metaData.Type))
            {
                metaData.RepoFolderPath = metaData.DefaultRepoFolder;
            }
            else
            {
                ShowRepoNotFoundInDefaultFolderMessage(metaData.Type);

                metaData.RepoFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if (metaData.RepoFolderPath != null)
            {
                ingredientsRepository.Ingredients = LoadRepo(metaData.RepoFolderPath + metaData.RepoName, metaData.Type) as List<Ingredient>;
            }
            else
            {
                MessageBox.Show("Fatal Error in DataHandler");
                throw new Exception("Fatal Error in Datahandler.CheckIngredientsLibrary()");
            }

            return ingredientsRepository;
        }

        private static void ShowRepoNotFoundInDefaultFolderMessage(RepositoryType type)
        {
            string typeStr = type.ToString();
            MessageBox.Show(
                                $"The {typeStr} Library Was Not Found! Find Recipe Browser Manually!",
                                "The Recipe Library Was Not Found!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning,
                                MessageBoxResult.OK,
                                MessageBoxOptions.DefaultDesktopOnly);
        }

        private static bool LibraryIsInFolder(string defaultRepositoryFolder, RepositoryType type)
        {
            switch (type)
            {
                case RepositoryType.None:
                    break;

                case RepositoryType.Recipes:
                    return File.Exists(defaultRepositoryFolder + @"\RecipeRepo.json");

                case RepositoryType.Ingredients:
                    return File.Exists(defaultRepositoryFolder + @"\IngredientsRepo.json");
            }
            return false;
        }

        private static string GetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private static object LoadRepo(string path, RepositoryType type)
        {
            string jsonString;
            switch (type)
            {
                case RepositoryType.None:
                //return null;

                case RepositoryType.Recipes:
                    RecipeRpository recipeRepo = new RecipeRpository();
                    jsonString = File.ReadAllText(path);

                    recipeRepo.Recipes = JsonConvert.DeserializeObject<List<Recipe>>(jsonString);

                    return recipeRepo.Recipes;

                case RepositoryType.Ingredients:
                    IngredientRepository ingredientsRepo = new IngredientRepository();
                    jsonString = File.ReadAllText(path);

                    ingredientsRepo.Ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonString);

                    return ingredientsRepo.Ingredients;

                default:
                    return null;
            }
        }
    }
}