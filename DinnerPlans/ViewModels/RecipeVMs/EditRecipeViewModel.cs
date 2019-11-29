using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.Commands;
using System;
using System.Windows.Input;

namespace DinnerPlans
{
    internal class EditRecipeViewModel : ViewModelBase
    {
        public EditRecipeViewModel(IDataService data, Recipe recipe = null)
        {
            this._data = data;
            Recipe = recipe != null ? recipe : new Recipe();
        }

        private IDataService _data;

        public Recipe Recipe { get; set; }

        public event OnDoneEditingEventHandler DoneEditing;

        public delegate void OnDoneEditingEventHandler();

        public ICommand SaveRecipeCommand
        {
            get
            {
                return new RelayCommand(SaveRecipe);
            }
        }

        public ICommand AddIngredientCommand
        {
            get { return new RelayCommand(AddIngredient); }
        }

        public ICommand RemoveIngredientCommand
        {
            get { return new RelayCommand(RemoveIngredient); }
        }

        private void SaveRecipe(object obj)
        {
            _data.SaveRecipe(Recipe);
            DoneEditing.Invoke();
        }

        private void AddIngredient(object obj)
        {
            Ingredient ingredient = GetIngredientFromUser();

            //    if (ingredient != null)
            //    {
            //        // _recipe.Ingredients.Add(ingredient);
            //        throw new NotImplementedException();
            //    }
        }

        private void RemoveIngredient(object sender)
        {
            //    var selectedIngredientEntry = RecipesDataGrid.SelectedItem as IngredientEntry;
            //    if (selectedIngredientEntry == null)
            //    {
            //        MessageBox.Show("No Item is Selected");
            //    }
            //    else
            //    {
            //        _recipe.Ingredients.Remove(selectedIngredientEntry);
            //    }
            throw new NotImplementedException();
        }

        private Ingredient GetIngredientFromUser()
        {
            IngredientWindow window = new IngredientWindow()
            {
                DataContext = new IngredientWindowViewModel(_data)
            };

            var ingredient = new Ingredient();
            if (window.ShowDialog() == true)
            {
                throw new NotImplementedException();
                //var vm = (IngredientWindowViewModel)window.DataContext;
                //ingredient = vm.Contents as ;
                //_data.SaveIngredient(ingredient);
            }
            else
            {
                return null;
            }
            //return null;

            //throw new NotImplementedException();
        }
    }
}