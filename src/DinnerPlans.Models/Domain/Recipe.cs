using System;
using System.Collections.Generic;
using DinnerPlans.Models.Enums;

namespace DinnerPlans.Models.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public RecipeTypes Type { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Instructions Instructions { get; set; }
    }

    public class Instructions
    {
    }
}