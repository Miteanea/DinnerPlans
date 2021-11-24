using DinnerPlans.API.Models;
using DinnerPlans.API.Services.Data.Recipes;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.RepositoryService
{
    public class IngredientRepository : IRepository<Ingredient>
    {

        public Ingredient Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Ingredient Get(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> Get(Filters filters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> Get(Filters filters, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return new List<Ingredient>
            {
                new Ingredient
                       {
                           Id = Guid.NewGuid(),
                           Name = "Tomato",
                           Unit = MeasurementUnit.gr
                       },
                       new Ingredient
                       {
                           Id = Guid.NewGuid(),
                           Name = "Egg",

                           Unit = MeasurementUnit.pcs
                       },
                       new Ingredient
                       {
                           Id = Guid.NewGuid(),
                           Name = "Milk",
                           Unit = MeasurementUnit.lt
                       }
            };
        }

        public IEnumerable<Ingredient> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Save(Ingredient input)
        {
            throw new NotImplementedException();
        }

        public void Save(Ingredient input, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ingredient input, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}