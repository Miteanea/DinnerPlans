using DinnerPlans.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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