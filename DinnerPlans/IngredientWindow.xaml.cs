using DinnerPlans.Models;
using DinnerPlans.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DinnerPlans
{
    /// <summary>
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        public IngredientWindow()
        {
            InitializeComponent();

            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
            ingredients = GetIngredientsCollection();

            ExistingIngridients.Items.Clear();
            ExistingIngridients.ItemsSource = ingredients;
        }

        public Ingredient Ingredient { get; set; }

        private ObservableCollection<Ingredient> GetIngredientsCollection()
        {
            return DataHandler.IngredientsRepository.Ingredients;
        }

        private void Add_Ingredient_Clicked( object sender , RoutedEventArgs e )
        {
            Ingredient = ExistingIngridients.SelectedItem as Ingredient;
            this.DialogResult = true;
            this.Close();
        }
    }
}