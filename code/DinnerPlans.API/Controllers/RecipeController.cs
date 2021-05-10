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
        public RecipeController(IRecipes recipes)
        {
            _recipes = recipes;
        }

        IRecipes _recipes;

        [HttpGet]
        public Recipe Get(Guid guid)
        {
            return _recipes.Get(guid);
        }

        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipes.GetRecipes();
        }
    }
}
