using DinnerPlans.API.Models;
using DinnerPlans.API.Models.Enums;
using DinnerPlans.API.Services.Data.Recipes;
using DinnerPlans.Domain.DomainCalsses;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services
{
    public class RecipeRepository : IRepository<Recipe>
    {
        public RecipeRepository()
        {
        }

        public IEnumerable<Recipe> GetAll()
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Ingredients = new List<IngredientEntry>
                    {
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 100,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 1,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 0.100m,
                       }
                    },
                    Instructions = "1. Break eggs into bowl. \\n 2. Add milk \\n 3. mix \\ 4. Fry \\n",
                    RecipeType = MealTypes.Breakfast
                },
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Ingredients = new List<IngredientEntry>
                    {
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 100,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 2,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 0.100m,
                       }
                    },
                    Instructions = "1. Fry beef. \\n 2. Fry Egg \\n 3.Eat \\n",
                    RecipeType = MealTypes.Lunch
                },
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Ingredients = new List<IngredientEntry>
                    {
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 100,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 2,
                       },
                       new IngredientEntry
                       {
                           IgredientId = Guid.NewGuid(),
                           Quantity = 0.100m,
                       }
                    },
                    Name = "Beef with eggs",
                    Instructions = "1. Take Roast. \\n 2. Take Ruccola \\n 3.Eat \\n",
                    RecipeType = MealTypes.Dinner
                }
            };
        }

        public Recipe Get(Guid recipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe Get(Guid recipeId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> Get(Filters filters, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Save(Recipe input, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Recipe input, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> Get(Filters filters)
        {
            throw new NotImplementedException();
        }
    }
}