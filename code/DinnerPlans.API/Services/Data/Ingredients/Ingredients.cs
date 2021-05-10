using DinnerPlans.API.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.Data
{
    public class Ingredients : IIngredients
    {
        public Ingredients()
        {

        }
        public Ingredient Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            throw new NotImplementedException();
        }


    }
}
