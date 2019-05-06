using DinnerPlans.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        }

        public static List<Recipe> RecipeRepository { get; private set; }

        public static void CheckRecipeLibrary()
        {
            // Check if the Recipe Library is Present in the default Folder

            if(LibraryIsInFolder( _defaultRepositoryFolder ))
            {
                _repositoryFolderPath = _defaultRepositoryFolder;
            }
            else
            {
                MessageBox.Show(
                    "The Recipe Library Was Not Found! Find Recipe Browser Manually!" ,
                    "The Recipe Library Was Not Found!" ,
                    MessageBoxButton.OK ,
                    MessageBoxImage.Warning ,
                    MessageBoxResult.OK ,
                    MessageBoxOptions.DefaultDesktopOnly );

                // create PopUp Window That Prompts User To Find the File on the FileSystem or Create New Recipe DataBase
                _repositoryFolderPath = GetFilePath();
            }

            // Load Recipes Into Memory
            if(_repositoryFolderPath != null)
            {
                RecipeRepository = LoadRecipeLibrary( _repositoryFolderPath );
            }
            else
            {
                MessageBox.Show( "Fatal Error in DataHandler" );
                throw new Exception( "Fatal Error in Datahandler.CheckRecipeLibrary()" );
            }
        }

        private static bool LibraryIsInFolder( string defaultRepositoryFolder )
        {
            return false;
            // throw new NotImplementedException();
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

        private static List<Recipe> LoadRecipeLibrary( object repositoryFolderPath )
        {
            throw new NotImplementedException();
        }

        public static Recipe GetRecipe( RecipeID id )
        {
            var recipe = RecipeRepository.
                            Where( longRecipe => longRecipe.ID == id ).
                            FirstOrDefault();

            return recipe;
        }

        public static List<RecipeShort> GetShortRecipes()
        {
            var shortRecipeList = new List<RecipeShort>();

            foreach(var longRecipe in RecipeRepository)
            {
                var shortRecipe = new RecipeShort( longRecipe );
                shortRecipeList.Add( shortRecipe );
            }
            return shortRecipeList;
        }

        public static void SaveRecipe( RecipeID iD )
        {
            // If the recipe ID is in the library
            // Overwrite the data
            // Else
            // create a new Entry in the library

            throw new NotImplementedException();
        }

        private static string _defaultRepositoryFolder;
        private static object _repositoryFolderPath;
    }
}