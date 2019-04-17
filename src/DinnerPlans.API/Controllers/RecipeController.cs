using DinnerPlans.API.Models;
using DinnerPlans.API.Services.Data.Recipes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public RecipeController(IRepository<Recipe> Recipes)
        {
            _recipes = Recipes;
        }

        private IRepository<Recipe> _recipes;

        [HttpGet]
        public Recipe Get(Guid guid)
        {
            return _recipes.Get(guid);
        }

        [HttpGet]
        public IEnumerable<Recipe> Get(Filters filters)
        {
            return _recipes.Get(filters);
        }

        [HttpGet]
        [Route("GetRecipes")]
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipes.GetAll();
        }

        [HttpGet]
        public Recipe Get(Guid guid, Guid userId)
        {
            return _recipes.Get(guid, userId);
        }

        [HttpGet]
        public IEnumerable<Recipe> Get(Filters filters, Guid userId)
        {
            return _recipes.Get(filters, userId);
        }

        [HttpGet]
        public IEnumerable<Recipe> GetRecipes(Guid userId)
        {
            return _recipes.GetAll();
        }
    }
}