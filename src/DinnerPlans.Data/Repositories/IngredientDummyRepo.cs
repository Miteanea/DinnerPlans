using System;
using System.Collections.Generic;
using System.Linq;
using DinnerPlans.Data.DataObjects;

namespace DinnerPlans.Data.Repositories
{
    public class IngredientDummyRepo : IIngredientRepository
    {
        public IEnumerable<IngredientDocument> GetIngredients(List<Guid> ingredients)
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
