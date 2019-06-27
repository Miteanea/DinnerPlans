using DinnerPlans.Models;
using System;

namespace DinnerPlans.Services
{
    internal class RepositoryFactory
    {
        public RecipeRpository GetRecipeRepository()
        {
            var repo = new RecipeRpository();
            repo.MetaData.DefaultRepoFolder = AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + @"JsonRepos\";
            repo.MetaData.RepoName = "RecipeRepo.json";
            repo.MetaData.Type = RepositoryType.Recipes;
            return repo;
        }

        internal IngredientRepository GetIngredientRepository()
        {
            var repo = new IngredientRepository();
            repo.MetaData.DefaultRepoFolder = AppDomain.CurrentDomain.BaseDirectory.Remove(startIndex) + @"JsonRepos\";
            repo.MetaData.RepoName = "IngredientsRepo.json";
            repo.MetaData.Type = RepositoryType.Ingredients;
            return repo;
        }

        private int startIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin");
    }
}