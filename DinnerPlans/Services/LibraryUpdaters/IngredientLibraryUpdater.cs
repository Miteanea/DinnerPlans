using DinnerPlans.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.Services.LibraryUpdaters
{
    internal class IngredientLibraryUpdater : ILibraryUpdater<Ingredient>
    {
        private string _repositoryPath;

        public IngredientLibraryUpdater(string recipeRepoPath)
        {
            _repositoryPath = recipeRepoPath;
        }

        public List<Ingredient> Repo { get; set; }

        public void UpdateLibrary(object repo)
        {
            UpdateIngredients();
        }

        private void UpdateIngredients()
        { throw new NotImplementedException(); }
    }
}