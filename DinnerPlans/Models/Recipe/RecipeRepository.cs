using DinnerPlans.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DinnerPlans.Models
{
    internal class RecipeRpository : IRecipeRpository
    {
        public RecipeRpository()
        {
            MetaData = new RepositoryData();
        }

        public RepositoryData MetaData { get; private set; }

        public ObservableCollection<Recipe> Recipes { get; set; }
    }
}