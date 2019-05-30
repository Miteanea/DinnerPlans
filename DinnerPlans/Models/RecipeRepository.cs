using DinnerPlans.Services;
using System.Collections.ObjectModel;

namespace DinnerPlans.Models
{
    internal class RecipeRpository
    {
        public RecipeRpository()
        {
            Recipes = new ObservableCollection<Recipe>();
            MetaData = new RepositoryData();
        }

        public RepositoryData MetaData { get; private set; }
        public ObservableCollection<Recipe> Recipes { get; set; }
    }
}