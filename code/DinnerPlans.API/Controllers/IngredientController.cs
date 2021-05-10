using DinnerPlans.API.Models;
using DinnerPlans.API.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public IngredientController(IIngredients ingredients)
        {
            _ingredients = ingredients;
        }

        IIngredients _ingredients;

        [HttpGet]
        public Ingredient Get(Guid guid)
        {
            return _ingredients.Get(guid);
        }

        [HttpGet]
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _ingredients.GetIngredients();
        }
    }
}
