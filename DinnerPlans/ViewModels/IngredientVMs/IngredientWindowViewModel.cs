using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.IngredientVMs;
using DinnerPlans.Views.IngredientViews;
using System;

namespace DinnerPlans
{
    internal class IngredientWindowViewModel : ViewModelBase
    {
        private IDataService _data;
        private object _displayContents;
        private object _createNewContents;

        public IngredientWindowViewModel(IDataService data)
        {
            _data = data;

            AllRecipesContents = new IngredientsDisplayView()
            {
                DataContext = new IngredientsDisplayViewModel(_data)
            };

            CreateNewContents = new IngredientCreateView()
            {
                DataContext = new IngredientCreateViewModel(_data)
            };
        }

        public object AllRecipesContents
        {
            get { return _displayContents; }
            set
            {
                if (value != this._displayContents)
                {
                    _displayContents = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public object CreateNewContents
        {
            get { return _createNewContents; }
            set
            {
                if (value != this._createNewContents)
                {
                    _createNewContents = value;
                    NotifyPropertyChanged();
                };
            }
        }

    }
}