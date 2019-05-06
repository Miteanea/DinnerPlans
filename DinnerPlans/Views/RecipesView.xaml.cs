using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using DinnerPlans.Views.RecipesViews;
using System.Windows;
using System.Windows.Controls;

namespace DinnerPlans.Views
{
    /// <summary>
    /// Interaction logic for Recipes.xaml
    /// </summary>
    public partial class RecipesView : UserControl
    {
        public RecipesView()
        {
            InitializeComponent();
            RecipesViewContent.AddHandler( RecipesListView.EditExistingRecipe , new RoutedEventHandler( EditExistingRecipe ) );
            DataContext = null;
        }

        private void AllRecipes_Clicked( object sender , RoutedEventArgs e )
        {
            DataContext = new RecipesListViewModel();
        }

        private void AddModify_Click( object sender , RoutedEventArgs e )
        {
            DataContext = new EditRecipeViewModel( null );
        }

        private void EditExistingRecipe( object sender , RoutedEventArgs e )
        {
            var recipe = GetRecipeFromEventArgs( e );

            DataContext = new EditRecipeViewModel( recipe );
        }

        private Recipe GetRecipeFromEventArgs( RoutedEventArgs e )
        {
            var sourceObject = e.OriginalSource as Button;

            var sourceObjectDataContext = sourceObject.DataContext;

            var recipeShort = sourceObjectDataContext as RecipeShort;

            var recipeID = recipeShort.ID;
            return DataHandler.GetRecipe( recipeID );
        }
    }
}