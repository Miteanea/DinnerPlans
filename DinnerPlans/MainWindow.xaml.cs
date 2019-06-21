using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using DinnerPlans.Views;
using System.Windows;

namespace DinnerPlans
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataHandler.CheckRecipeLibrary();
            DataHandler.CheckIngredientsLibrary();
        }

        private void Recipes_Clicked( object sender , RoutedEventArgs e )
        {
            MainContent.Content = new RecipesView();
        }

        private void Menus_Clicked( object sender , RoutedEventArgs e )
        {
            DataContext = new MenusView();
        }
    }
}