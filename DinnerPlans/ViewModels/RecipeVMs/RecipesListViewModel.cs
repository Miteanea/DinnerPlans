using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace DinnerPlans
{
    internal class RecipesListViewModel : ViewModelBase
    {
        private IDataService _data;

        public RecipesListViewModel(IDataService data)
        {
            _data = data;
            Recipes = _data.Recipes;
        }

        public ObservableCollection<Recipe> Recipes { get; set; }

        public event OnStartEditingEventHandler StartedEditing;

        public delegate void OnStartEditingEventHandler(Recipe recipe);

        public ICommand EditRecipeCommand
        {
            get
            {
                return new RelayCommand(EditRecipe);
            }
        }

        public ICommand DeleteRecipeCommand
        {
            get
            {
                return new RelayCommand(DeleteRecipe);
            }
        }

        private void EditRecipe(object obj)
        {
            Recipe recipe = obj as Recipe;
            if (recipe != null)
            {
                StartedEditing.Invoke(recipe);
            }
            else
            {
            }
        }

        private void DeleteRecipe(object obj)
        {
            var recipe = obj as Recipe;
            DeleteRecipeMessage deleteRecipeMessage = new DeleteRecipeMessage(recipe.Title);

            if (MessageBox.Show(
              deleteRecipeMessage.Message,
              deleteRecipeMessage.Caption,
              deleteRecipeMessage.Button,
              deleteRecipeMessage.Image,
              deleteRecipeMessage.DefaultResult,
              deleteRecipeMessage.Options) == MessageBoxResult.Yes)
            {
                _data.DeleteRecipeAsync(recipe);
            }
        }
    }
}