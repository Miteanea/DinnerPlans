using DinnerPlans.Models;
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
            RecipesViewContent.AddHandler(RecipesListView.EditExistingRecipe, new RoutedEventHandler(EditExistingRecipe));
            DataContext = null;
        }

        private void AllRecipes_Clicked(object sender, RoutedEventArgs e)
        {
            RecipesViewContent.Content = new RecipesListView();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EditRecipeView();
        }

        private void EditExistingRecipe(object sender, RoutedEventArgs e)
        {
            var recipeID = GetRecipeFromEventArgs(e);

            RecipesViewContent.Content = new EditRecipeView(recipeID);
        }

        private RecipeID GetRecipeFromEventArgs(RoutedEventArgs e)
        {
            var sourceObject = e.OriginalSource as Button;
            var sourceObjectDataContext = sourceObject.DataContext;
            var recipeShort = sourceObjectDataContext as RecipeViewModel;

            return recipeShort.ID;
        }
    }
}