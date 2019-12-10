using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.IngredientVMs;
using DinnerPlans.Views.IngredientViews;

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

            var createVM = new IngredientCreateViewModel(_data);
            createVM.DoneEditing += GoToFirstTab;
            CreateNewContents = new IngredientCreateView()
            {
                DataContext = createVM
            };
        }

        private void GoToFirstTab()
        {
            SelectedIndex = 0;
        }

        private int _selectedIndex = 0; // Set the field to whichever tab you want to start on

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value != this._selectedIndex)
                {
                    _selectedIndex = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public Ingredient Ingredient { get; set; }

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