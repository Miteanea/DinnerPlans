using DinnerPlans.Services;
using DinnerPlans.ViewModels;
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
            DataContext = new RecipesViewModel();
        }

        private void Menus_Clicked( object sender , RoutedEventArgs e )
        {
            DataContext = new MenusViewModel();
        }
    }
}