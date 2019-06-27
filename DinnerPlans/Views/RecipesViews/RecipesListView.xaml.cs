using DinnerPlans.Services;
using System.Windows;
using System.Windows.Controls;

namespace DinnerPlans.Views.RecipesViews
{
    /// <summary>
    /// Interaction logic for RecipesListView.xaml
    /// </summary>
    public partial class RecipesListView : UserControl
    {
        public RecipesListView()
        {
            InitializeComponent();
            DataContext = RecipeDataHandler.GetRecipeViewModelsForListView();
        }

        private void EditButton_Clicked(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var data = btn.DataContext;

            RaiseEvent(new RoutedEventArgs(EditExistingRecipe, btn));
        }

        public static readonly RoutedEvent EditExistingRecipe = EventManager.RegisterRoutedEvent(
                       "Edit",
                       RoutingStrategy.Bubble,
                       typeof(RoutedEventHandler),
                       typeof(RecipesListView));

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditExistingRecipe, value); }
            remove { RemoveHandler(EditExistingRecipe, value); }
        }
    }
}