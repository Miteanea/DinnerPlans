using DinnerPlans.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace DinnerPlans.Services
{
    internal static class DataHandler
    {
        static DataHandler()
        {
            int startIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf( "bin" );
            _defaultRepositoryFolder = AppDomain.CurrentDomain.BaseDirectory.Remove( startIndex );
            _repoName = "RecipeRepo.json";
        }

        public static void CheckRecipeLibrary()
        {
            // Check if the Recipe Library is Present in the default Folder
            if(LibraryIsInFolder( _defaultRepositoryFolder ))
            {
                _repositoryFolderPath = _defaultRepositoryFolder;
            }
            else
            {
                ShowRepoNotFoundInDefaultFolderMessage();

                _repositoryFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if(_repositoryFolderPath != null)
            {
                RecipeRepository = LoadRecipeLibrary( _repositoryFolderPath + _repoName );
            }
            else
            {
                MessageBox.Show( "Fatal Error in DataHandler" );
                throw new Exception( "Fatal Error in Datahandler.CheckRecipeLibrary()" );
            }
        }

        private static void ShowRepoNotFoundInDefaultFolderMessage()
        {
            MessageBox.Show(
                                "The Recipe Library Was Not Found! Find Recipe Browser Manually!" ,
                                "The Recipe Library Was Not Found!" ,
                                MessageBoxButton.OK ,
                                MessageBoxImage.Warning ,
                                MessageBoxResult.OK ,
                                MessageBoxOptions.DefaultDesktopOnly );
        }

        private static bool LibraryIsInFolder( string defaultRepositoryFolder )
        {
            return File.Exists( defaultRepositoryFolder + @"\RecipeRepo.json" );
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

        private static RecipeRpository LoadRecipeLibrary( string path )
        {
            var list = new RecipeRpository();
            var jsonString = File.ReadAllText( path );

            list = JsonConvert.DeserializeObject<RecipeRpository>( jsonString );

            return list;
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
            var recipes = RecipeRepository.Recipes;

            if(recipes.Where( recipe => recipe.ID == recipeToSave.ID ).Count() == 0)
            {
                recipes.Add( recipeToSave );
            }

            UpdateRecipeLibrary( _repositoryFolderPath + _repoName );
        }

        private static string _defaultRepositoryFolder;
        private static string _repoName;
        private static object _repositoryFolderPath;

        public static RecipeRpository RecipeRepository { get; private set; }
    }
}