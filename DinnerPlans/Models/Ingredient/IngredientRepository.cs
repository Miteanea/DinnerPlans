using System.Collections.ObjectModel;
using DinnerPlans.Models;

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