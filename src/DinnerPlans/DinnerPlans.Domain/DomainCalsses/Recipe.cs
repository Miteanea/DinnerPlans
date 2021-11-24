using DinnerPlans.API.Models.Enums;
using DinnerPlans.Domain.DomainCalsses;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public IEnumerable<IngredientEntry> Ingredients { get; set; }
        public MealTypes RecipeType { get; set; }
    }
}