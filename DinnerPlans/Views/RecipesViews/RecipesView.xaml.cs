using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.Views.RecipesViews;
using System;
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
        }

        private void AllRecipes_Clicked(object sender, RoutedEventArgs e)
        {
            RecipesListView recipesList = new RecipesListView();
            recipesList.Edit += EditExistingRecipe;

            RecipesViewContent.Content = recipesList;
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipesViewContent.Content = new EditRecipeView();
        }

        private void EditExistingRecipe(object sender, EditEventArgs e)
        {
            RecipesViewContent.Content = new EditRecipeView(e.RecipeId);
        }
    }
}