using System.Collections.ObjectModel;
using DinnerPlans.Models;

namespace DinnerPlans.Services
{
    internal interface IIngredientRepository
    {
        ObservableCollection<Ingredient> Ingredients { get; set; }
        RepositoryData MetaData { get; }
    }
}