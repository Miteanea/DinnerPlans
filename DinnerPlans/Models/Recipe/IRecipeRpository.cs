using System.Collections.ObjectModel;
using DinnerPlans.Services;

namespace DinnerPlans.Models
{
    internal interface IRecipeRpository
    {
        RepositoryData MetaData { get; }
        ObservableCollection<Recipe> Recipes { get; set; }
    }
}