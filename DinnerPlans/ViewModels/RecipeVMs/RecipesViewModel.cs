using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.Commands;
using DinnerPlans.Views.RecipesViews;
using System;
using System.Windows.Input;

namespace DinnerPlans
{
    internal class RecipesViewModel : ViewModelBase
    {
        public RecipesViewModel(IDataService data)
        {
            _data = data;
        }

        public object Contents
        {
            get { return _content; }
            set
            {
                if (value != this._content)
                {
                    _content = value;
                    NotifyPropertyChanged();
                };
            }
        }

        private object _content;
        private IDataService _data;

        public ICommand SwitchFeatureCommand
        {
            get
            {
                return new RelayCommand(SwitchContent);
            }
        }

        private void SwitchContent(object contentName)
        {
            switch ((string)contentName)
            {
                case "AllRecipes":
                    HandleViewModelChangeBackFromEditing();
                    break;

                case "NewRecipe":
                    HandleViewModelChangeToEditing();
                    break;

                default:
                    throw new ArgumentException("Command Parameter not Recognized");
            }
        }

        private void HandleViewModelChangeBackFromEditing()
        {
            var vm = new RecipesListViewModel(_data);
            vm.StartedEditing += HandleViewModelChangeToEditing;
            Contents = new RecipesListView
            {
                DataContext = vm
            };
        }

        private void HandleViewModelChangeToEditing(Recipe recipe = null)
        {
            var vm = new EditRecipeViewModel(_data, recipe);
            vm.DoneEditing += HandleViewModelChangeBackFromEditing;
            Contents = new EditRecipeView
            {
                DataContext = vm
            };
        }
    }
}