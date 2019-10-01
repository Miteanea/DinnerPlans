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

        private List<Recipe> _updatedRecipes;

        public void UpdateLibrary(List<Recipe> repo)
        {
            _updatedRecipes = repo;
            UpdateRecipes();
        }

        private void UpdateRecipes()
        {
            throw new NotImplementedException();
        }
    }
}