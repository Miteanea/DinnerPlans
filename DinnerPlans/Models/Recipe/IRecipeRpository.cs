using DinnerPlans.Services;
using System.Collections.Generic;

namespace DinnerPlans.Models
{
    internal interface IRecipeRpository
    {
        RepositoryData MetaData { get; }
        List<Recipe> Recipes { get; set; }
    }
}