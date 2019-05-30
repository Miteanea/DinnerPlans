using System.Collections.ObjectModel;
using DinnerPlans.Models;

namespace DinnerPlans.Services
{
    internal class IngredientRepository
    {
        public IngredientRepository()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            MetaData = new RepositoryData();
        }

        public ObservableCollection<Ingredient> Ingredients { get; internal set; }

        public RepositoryData MetaData { get; private set; }
    }
}