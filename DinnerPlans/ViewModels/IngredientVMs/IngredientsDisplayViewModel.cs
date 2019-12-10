using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public ICommand ReturnIngredientCommand
        {
            get
            {
                return new RelayCommand(ReturnIngredient);
            }
        }

        public ICommand DeleteIngredientCommand
        {
            get
            {
                return new RelayCommand(DeleteIngredient);
            }
        }

        private void ReturnIngredient(object obj)
        {
            var window = obj as IngredientWindow;
            window.DialogResult = true;
            window.Close();
        }

        private void DeleteIngredient(object obj)
        {
            var ingredient = obj as Ingredient;

            _data.DeleteIngredientAsync(ingredient);
        }
    }
}