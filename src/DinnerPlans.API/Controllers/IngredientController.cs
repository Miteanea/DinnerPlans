using DinnerPlans.API.Models;
using DinnerPlans.API.Services.Data.Recipes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public IngredientController(IRepository<Ingredient> ingredients)
        {
            _ingredients = ingredients;
        }

        private IRepository<Ingredient> _ingredients;

        [HttpGet]
        public Ingredient Get(Guid guid)
        {
            return _ingredients.Get(guid);
        }

        [HttpGet]
        public IEnumerable<Ingredient> Get(Filters filters)
        {
            return _ingredients.Get(filters);
        }

        [HttpGet]
        [Route("GetIngredients")]
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _ingredients.GetAll();
        }

        [HttpGet]
        public Ingredient Get(Guid guid, Guid userId)
        {
            return _ingredients.Get(guid, userId);
        }

        [HttpGet]
        public IEnumerable<Ingredient> Get(Filters filters, Guid userId)
        {
            return _ingredients.Get(filters, userId);
        }

        [HttpGet]
        public IEnumerable<Ingredient> GetIngredients(Guid userId)
        {
            return _ingredients.GetAll();
        }
    }
}