using DinnerPlans.Models;   
using DinnerPlans.Services;
using System;
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
            var args = new EditEventArgs(GetRecipeIdFromArgs(e));

            Edit.Invoke(sender, args);
        }

        private IId GetRecipeIdFromArgs(RoutedEventArgs args)
        {
            var sourceObject = (Button)args.OriginalSource;
            var sourceObjectDataContext = sourceObject.DataContext;
            return (sourceObjectDataContext as RecipeViewModel).ID;
        }

        internal event EventHandler<EditEventArgs> Edit;
    }
}