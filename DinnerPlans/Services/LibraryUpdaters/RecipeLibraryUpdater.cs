using DinnerPlans.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.Services.LibraryUpdaters
{
    internal class RecipeLibraryUpdater : ILibraryUpdater<Recipe>
    {
        private string _repositoryPath;

        public RecipeLibraryUpdater(string ingredientRepoPath)
        {
            _repositoryPath = ingredientRepoPath;
        }

        public List<Recipe> Repo { get; set; }

        public void UpdateLibrary(object repo)
        {
            UpdateRecipes();
        }

        private void UpdateRecipes()
        {
            throw new NotImplementedException();
        }
    }
}