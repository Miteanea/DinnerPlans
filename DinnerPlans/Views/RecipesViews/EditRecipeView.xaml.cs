using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using System;
using System.Linq;
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

            OriginSelector.ItemsSource = Enum.GetValues( typeof( Origin ) ).Cast<Origin>();
        }

        private void SaveRecipeBtn_Click( object sender , RoutedEventArgs e )
        {
            var viewModel = ( sender as Button ).DataContext as EditRecipeViewModel;

            DataHandler.SaveRecipe( viewModel.Recipe.ID );
        }
    }
}