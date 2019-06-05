using System.Collections.ObjectModel;
using DinnerPlans.Models;
using Newtonsoft.Json;

namespace DinnerPlans.Services
{
    internal class IngredientRepository : IIngredientRepository
    {
        public IngredientRepository()
        {
            MetaData = new RepositoryData();
        }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public RepositoryData MetaData { get; private set; }
    }
}