using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DinnerPlans.Views.RecipesViews
{
    /// <summary>
    /// Interaction logic for EditRecipeView.xaml
    /// </summary>
    public partial class EditRecipeView : UserControl
    {
        public EditRecipeView( RecipeViewModel recipe = null )
        {
            InitializeComponent();

            if(recipe == null)
            {
                DataContext = new RecipeViewModel();
            }
            else
            {
                DataContext = recipe;
            }

            DataContextChanged += new DependencyPropertyChangedEventHandler( EditRecipeView_DataContextChanged );
        }

        private RecipeViewModel _recipe;

        private void EditRecipeView_DataContextChanged( object sender , DependencyPropertyChangedEventArgs e )
        {
            _recipe = ( e.NewValue as RecipeViewModel );
        }

        private void SaveRecipeBtn_Click( object sender , RoutedEventArgs e )
        {
            DataHandler.SaveRecipe( _recipe );

            MessageBox.Show( "Recipe Saved!" );

            // Go To Recipe ListView
        }

        private void Add_Ingredient_Btn_Click( object sender , RoutedEventArgs e )
        {
            var ingredient = GetIngredientFromUser();

            if(ingredient != null)
            {
                IngredientEntryViewModel newIngredientEntry = DataHandler.CreateEntry( ingredient , _recipe );
                _recipe.Ingredients.Add( newIngredientEntry );
            }
        }

        private void Remove_Ingredient_Btn_Click( object sender , RoutedEventArgs e )
        {
            var selectedIngredientEntry = RecipesDataGrid.SelectedItem as IngredientEntryViewModel;
            if(selectedIngredientEntry == null)
            {
                MessageBox.Show( "No Item is Selected" );
            }
            else
            {
                _recipe.Ingredients.Remove( selectedIngredientEntry );
            }
        }

        private IngredientViewModel GetIngredientFromUser()
        {
            IngredientWindow window = new IngredientWindow();

            var ingredient = new IngredientViewModel();

            if(window.ShowDialog() == true)
            {
                ingredient = window.Ingredient;
                DataHandler.SaveIngredient( ingredient );
            }
            else
            {
                return null;
            }

            return ingredient;
        }

        private void UserControl_Loaded( object sender , RoutedEventArgs e )
        {
        }
    }
}