using DinnerPlans.ViewModels;
using DinnerPlans.Views.RecipesViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            RecipesViewContent.AddHandler(RecipesListView.EditEvent, new RoutedEventHandler(ChangeContentToEditView));
            DataContext = null;
        }

        private void AllRecipes_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RecipesListViewModel();
        }

        private void AddModify_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EditRecipeViewModel();
        }

        private void ChangeContentToEditView(object sender, RoutedEventArgs e)
        {
            DataContext = new EditRecipeViewModel();
        }
    }
}