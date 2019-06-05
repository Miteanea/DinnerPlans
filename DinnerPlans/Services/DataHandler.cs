using DinnerPlans.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace DinnerPlans.Services
{
    internal static class DataHandler
    {
        static DataHandler()
        {
            InitializeRepositoryMetadata();
        }

        public static void CheckIngredientsLibrary()
        {
            // Check if the Recipe Library is Present in the default Folder
            var metaData = IngredientsRepository.MetaData;
            if(LibraryIsInFolder( metaData.DefaultRepoFolder , metaData.Type ))
            {
                metaData.RepoFolderPath = metaData.DefaultRepoFolder;
            }
            else
            {
                ShowRepoNotFoundInDefaultFolderMessage( metaData.Type );

                metaData.RepoFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if(metaData.RepoFolderPath != null)
            {
                IngredientsRepository.Ingredients = LoadRepo( metaData.RepoFolderPath + metaData.RepoName , metaData.Type ) as ObservableCollection<Ingredient>;
            }
            else
            {
                MessageBox.Show( "Fatal Error in DataHandler" );
                throw new Exception( "Fatal Error in Datahandler.CheckIngredientsLibrary()" );
            }
        }

        public static void CheckRecipeLibrary()
        {
            // Check if the Recipe Library is Present in the default Folder
            var metaData = RecipeRepository.MetaData;
            if(LibraryIsInFolder( metaData.DefaultRepoFolder , metaData.Type ))
            {
                metaData.RepoFolderPath = metaData.DefaultRepoFolder;
            }
            else
            {
                ShowRepoNotFoundInDefaultFolderMessage( metaData.Type );

                metaData.RepoFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if(metaData.RepoFolderPath != null)
            {
                RecipeRepository.Recipes = LoadRepo( metaData.RepoFolderPath + metaData.RepoName , metaData.Type ) as ObservableCollection<Recipe>;
            }
            else
            {
                MessageBox.Show( "Fatal Error in DataHandler" );
                throw new Exception( "Fatal Error in Datahandler.CheckRecipeLibrary()" );
            }
        }

        public static Recipe GetRecipe( RecipeID id )
        {
            var recipe = RecipeRepository.Recipes.
                            Where( longRecipe => longRecipe.ID == id ).
                            FirstOrDefault();

            return recipe;
        }

        public static void SaveRecipe( Recipe recipeToSave )
        {
            var metaData = RecipeRepository.MetaData;
            var recipes = RecipeRepository.Recipes;

            if(recipes.Where( recipe => recipe.ID == recipeToSave.ID ).Count() == 0)
            {
                recipes.Add( recipeToSave );
            }

            UpdateLibrary( metaData.RepoFolderPath + metaData.RepoName , RecipeRepository.Recipes );
        }

        public static void SaveIngredient( Ingredient ingredientToSave )
        {
            var metaData = IngredientsRepository.MetaData;
            var ingredients = IngredientsRepository.Ingredients;

            if(ingredients.Where( ingredient => ingredient.ID == ingredientToSave.ID ).Count() == 0)
            {
                ingredients.Add( ingredientToSave );
            }

            UpdateLibrary( metaData.RepoFolderPath + metaData.RepoName , IngredientsRepository.Ingredients );
        }

        public static void SaveIngredientChanges()
        {
            var metaData = IngredientsRepository.MetaData;
            var ingredients = IngredientsRepository.Ingredients;
            UpdateLibrary( metaData.RepoFolderPath + metaData.RepoName , IngredientsRepository.Ingredients );
        }

        public static IRecipeRpository RecipeRepository { get; private set; }
        public static IIngredientRepository IngredientsRepository { get; private set; }

        private static void ShowRepoNotFoundInDefaultFolderMessage( RepositoryType type )
        {
            string typeStr = type.ToString();
            MessageBox.Show(
                                $"The {typeStr} Library Was Not Found! Find Recipe Browser Manually!" ,
                                "The Recipe Library Was Not Found!" ,
                                MessageBoxButton.OK ,
                                MessageBoxImage.Warning ,
                                MessageBoxResult.OK ,
                                MessageBoxOptions.DefaultDesktopOnly );
        }

        private static bool LibraryIsInFolder( string defaultRepositoryFolder , RepositoryType type )
        {
            switch(type)
            {
                case RepositoryType.None:
                    break;

                case RepositoryType.Recipes:
                    return File.Exists( defaultRepositoryFolder + @"\RecipeRepo.json" );

                case RepositoryType.Ingredients:
                    return File.Exists( defaultRepositoryFolder + @"\IngredientsRepo.json" );
            }
            return false;
        }

        private static string GetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private static object LoadRepo( string path , RepositoryType type )
        {
            string jsonString;
            switch(type)
            {
                case RepositoryType.None:
                    return null;

                case RepositoryType.Recipes:
                    RecipeRpository recipeRepo = new RecipeRpository();
                    jsonString = File.ReadAllText( path );

                    recipeRepo.Recipes = JsonConvert.DeserializeObject<ObservableCollection<Recipe>>( jsonString );

                    return recipeRepo.Recipes;

                case RepositoryType.Ingredients:
                    IngredientRepository ingredientsRepo = new IngredientRepository();
                    jsonString = File.ReadAllText( path );

                    ingredientsRepo.Ingredients = JsonConvert.DeserializeObject<ObservableCollection<Ingredient>>( jsonString );

                    return ingredientsRepo.Ingredients;

                default:
                    return null;
            }
        }

        private static void UpdateLibrary( string path , object repo )
        {
            var jsonString = JsonConvert.SerializeObject( repo );

            File.WriteAllText( path , jsonString );
        }

        private static void InitializeRepositoryMetadata()
        {
            int startIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf( "bin" );

            RecipeRepository = new RecipeRpository();
            RecipeRepository.MetaData.DefaultRepoFolder = AppDomain.CurrentDomain.BaseDirectory.Remove( startIndex ) + @"JsonRepos\";
            RecipeRepository.MetaData.RepoName = "RecipeRepo.json";
            RecipeRepository.MetaData.Type = RepositoryType.Recipes;

            IngredientsRepository = new IngredientRepository();
            IngredientsRepository.MetaData.DefaultRepoFolder = AppDomain.CurrentDomain.BaseDirectory.Remove( startIndex ) + @"JsonRepos\";
            IngredientsRepository.MetaData.RepoName = "IngredientsRepo.json";
            IngredientsRepository.MetaData.Type = RepositoryType.Ingredients;
        }
    }
}