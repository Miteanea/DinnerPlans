using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;
using DinnerPlans.Data.Repositories.Interfaces;

namespace DinnerPlans.Data.Repositories
{
    public class IngredientRepo : IRepository<IngredientDocument>
    {
        public IngredientDocument Get(Guid ingredient)
        {
            return IngredientDummyRepoStorage.IngredientDocuments.FirstOrDefault(_ => _.Id.Equals(ingredient));
        }
        public IEnumerable<IngredientDocument> Get(List<Guid> ingredients)
        {
            return IngredientDummyRepoStorage.IngredientDocuments.Where(_ => ingredients.Contains(_.Id));
        }
    }

    public static class IngredientDummyRepoStorage
    {

        public static List<IngredientDocument> IngredientDocuments
        {
            get
            {
                return _ingrendients;
            }
        }

        private static List<IngredientDocument> _ingrendients = new List<IngredientDocument>
        {
            new IngredientDocument()
            {
                Id = new Guid("")
            },
            new IngredientDocument()
            {
                Id = new Guid("")
            }
        };
    }
}
