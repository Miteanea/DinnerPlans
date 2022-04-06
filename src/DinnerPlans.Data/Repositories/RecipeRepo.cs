using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;
using DinnerPlans.Data.Repositories.Interfaces;

namespace DinnerPlans.Data.Repositories
{
    public class RecipeRepo : IRepository<RecipeDocument>
    {
        public RecipeDocument Get(Guid id)
        {
            return RecipeDummyRepoStorage.Recipes.FirstOrDefault(_ => _.Equals(id));
        }

        public IEnumerable<RecipeDocument> Get(List<Guid> ids)
        {
            return RecipeDummyRepoStorage.Recipes.Where(_ => ids.Contains(_.Id));
        }
    }

    public static class RecipeDummyRepoStorage
    {
        public static List<RecipeDocument> Recipes
        {
            get { return _recipes; }
        }

        private static List<RecipeDocument> _recipes = new List<RecipeDocument>()
        {
            new RecipeDocument()
            {
                Id = new Guid("")
            }
        };
    }
}