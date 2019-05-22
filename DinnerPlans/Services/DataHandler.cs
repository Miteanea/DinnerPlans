using DinnerPlans.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        internal static void CheckIngredientsLibrary()
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

                    recipeRepo = JsonConvert.DeserializeObject<RecipeRpository>( jsonString );

                    return recipeRepo.Recipes;

                case RepositoryType.Ingredients:
                    IngredientRepository ingredientsRepo = new IngredientRepository();
                    jsonString = File.ReadAllText( path );

                    ingredientsRepo = JsonConvert.DeserializeObject<IngredientRepository>( jsonString );

                    return ingredientsRepo.Ingredients;

                default:
                    return null;
            }
        }

        private static void UpdateRecipeLibrary( string path )
        {
            var list = RecipeRepository;
            var jsonString = JsonConvert.SerializeObject( list );

            File.WriteAllText( path , jsonString );
        }

        public static Recipe GetRecipe( RecipeID id )
        {
            var recipe = RecipeRepository.Recipes.
                            Where( longRecipe => longRecipe.ID == id ).
                            FirstOrDefault();

            return recipe;
        }

        public static List<RecipeShort> GetShortRecipes()
        {
            var shortRecipeList = new List<RecipeShort>();

            foreach(var longRecipe in RecipeRepository.Recipes)
            {
                var shortRecipe = new RecipeShort( longRecipe );
                shortRecipeList.Add( shortRecipe );
            }
            return shortRecipeList;
        }

        public static void SaveRecipe( Recipe recipeToSave )
        {
            var metaData = RecipeRepository.MetaData;
            var recipes = RecipeRepository.Recipes;

            if(recipes.Where( recipe => recipe.ID == recipeToSave.ID ).Count() == 0)
            {
                recipes.Add( recipeToSave );
            }

            UpdateRecipeLibrary( metaData.RepoFolderPath + metaData.RepoName );
        }

        public static RecipeRpository RecipeRepository { get; private set; }
        public static IngredientRepository IngredientsRepository { get; private set; }

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

    internal class RepositoryData
    {
        public RepositoryType Type;
        public string DefaultRepoFolder;
        public string RepoName;
        public string RepoFolderPath;
    }

    public enum RepositoryType
    {
        None = 0,
        Recipes,
        Ingredients
    }
}