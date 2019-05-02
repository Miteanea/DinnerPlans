using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            OriginSelector.ItemsSource = Enum.GetValues(typeof(Origin)).Cast<Origin>();
        }

        private void SaveRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (sender as Button).DataContext as EditRecipeViewModel;

            DataHandler.SaveRecipe(viewModel.Recipe.ID);
        }
    }
}