using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.Commands;
using System.Threading.Tasks;
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

        /// <summary>
        /// Wrapper method for async saving
        /// </summary>
        /// <param name="obj"></param>
        private void SaveRecipe(object obj)
        {
            SaveRecipeAsync();
        }

        private async Task SaveRecipeAsync()
        {
            await _data.SaveRecipeAsync(Recipe);
            DoneEditing.Invoke();
        }

        private void AddIngredient(object obj)
        {
            IngredientEntry ingredient = GetIngredientFromUser();

            if (ingredient != null)
            {
                Recipe.Ingredients.Add(ingredient);
            }
        }

        private void RemoveIngredient(object obj)
        {
            Recipe.Ingredients.Remove(obj as IngredientEntry);
        }

        private IngredientEntry GetIngredientFromUser()
        {
            IngredientWindow window = new IngredientWindow()
            {
                DataContext = new IngredientWindowViewModel(_data)
            };

            var ingredient = new IngredientEntry();

            if (window.ShowDialog() == true)
            {
                var vm = (IngredientWindowViewModel)window.DataContext;
                ingredient.Ingredient = vm.Ingredient;
                // _data.SaveIngredientAsync(ingredient.Ingredient);
            }
            else
            {
                return null;
            }
            return ingredient;

            //throw new NotImplementedException();
        }
    }
}