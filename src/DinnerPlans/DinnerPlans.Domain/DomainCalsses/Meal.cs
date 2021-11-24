using DinnerPlans.API.Models.Enums;
using System;

namespace DinnerPlans.API.Models
{
    public class Meal
    {
        public Guid Id { get; set; }
        public MealTypes MealType { get; set; }
    }
}