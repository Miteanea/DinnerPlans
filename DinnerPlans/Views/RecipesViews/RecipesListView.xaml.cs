using DinnerPlans.Models;
using DinnerPlans.ViewModels;
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
            DataContext = new RecipesListViewModel();
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