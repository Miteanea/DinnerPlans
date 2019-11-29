using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using System;
using System.Collections.ObjectModel;

namespace DinnerPlans.ViewModels.IngredientVMs
{
    internal class IngredientsDisplayViewModel : ViewModelBase
    {
        public IngredientsDisplayViewModel(IDataService data)
        {
            _data = data;
            Ingredients = _data.Ingredients;
        }

        private IDataService _data;

        public Ingredient Ingredient { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
    }
}