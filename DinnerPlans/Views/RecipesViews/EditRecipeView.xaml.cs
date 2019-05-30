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
        public EditRecipeView()
        {
            InitializeComponent();

            DataContextChanged += new DependencyPropertyChangedEventHandler( EditRecipeView_DataContextChanged );
        }

        private Recipe _recipe;

        private void EditRecipeView_DataContextChanged( object sender , DependencyPropertyChangedEventArgs e )
        {
            _recipe = ( e.NewValue as EditRecipeViewModel ).Recipe;
        }

        private void SaveRecipeBtn_Click( object sender , RoutedEventArgs e )
        {
            DataHandler.SaveRecipe( _recipe );

            MessageBox.Show( "Recipe Saved!" );

            // Go To Recipe ListView
        }

        private void Add_Ingredient_Btn_Click( object sender , RoutedEventArgs e )
        {
            Ingredient newIngredient = GetIngredientFromUser();

            if(newIngredient != null)
            {
                _recipe.Ingredients.Add( newIngredient );
            }
        }

        private Ingredient GetIngredientFromUser()
        {
            //Open Ingredient Input Window.
            IngredientWindow window = new IngredientWindow();

            var ingredient = new Ingredient();

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

        private void Remove_Ingredient_Btn_Click( object sender , RoutedEventArgs e )
        {
            var selectedIngredient = RecipesDataGrid.SelectedItem as Ingredient;
            if(selectedIngredient == null)
            {
                MessageBox.Show( "No Item is Selected" );
            }
            else
            {
                _recipe.Ingredients.Remove( selectedIngredient );
            }
        }
    }
}