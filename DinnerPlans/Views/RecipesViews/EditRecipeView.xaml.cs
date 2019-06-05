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
            IngredientEntry newIngredientEntry = DataHandler.CreateEntry( GetIngredientFromUser() , _recipe );

            if(newIngredientEntry != null)
            {
                _recipe.IngredientEntries.Add( newIngredientEntry );
            }
        }

        private void Remove_Ingredient_Btn_Click( object sender , RoutedEventArgs e )
        {
            var selectedIngredientEntry = RecipesDataGrid.SelectedItem as IngredientEntry;
            if(selectedIngredientEntry == null)
            {
                MessageBox.Show( "No Item is Selected" );
            }
            else
            {
                _recipe.IngredientEntries.Remove( selectedIngredientEntry );
            }
        }

        private Ingredient GetIngredientFromUser()
        {
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
    }
}