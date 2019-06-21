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
            RecipesViewContent.Content = new RecipesListView();
        }

        private void AddRecipe_Click( object sender , RoutedEventArgs e )
        {
            DataContext = new EditRecipeView();
        }

        private void EditExistingRecipe( object sender , RoutedEventArgs e )
        {
            var recipe = GetRecipeFromEventArgs( e );

            RecipesViewContent.Content = new EditRecipeView( recipe );
        }

        private RecipeViewModel GetRecipeFromEventArgs( RoutedEventArgs e )
        {
            var sourceObject = e.OriginalSource as Button;

            var sourceObjectDataContext = sourceObject.DataContext;

            var recipeShort = sourceObjectDataContext as Models.Recipe;

            var recipeID = recipeShort.ID;
            return DataHandler.GetRecipe( recipeID );
        }
    }
}