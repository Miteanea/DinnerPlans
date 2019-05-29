using DinnerPlans.Models;
using DinnerPlans.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            _ingredients = GetIngredientsCollection();

            ExistingIngridients.Items.Clear();
            ExistingIngridients.ItemsSource = _ingredients;
        }

        public Ingredient Ingredient { get; set; }
        private ObservableCollection<Ingredient> _ingredients { get; set; }

        private ObservableCollection<Ingredient> GetIngredientsCollection()
        {
            return DataHandler.IngredientsRepository.Ingredients;
        }

        private void Add_Ingredient_Clicked( object sender , RoutedEventArgs e )
        {
            if(ExistingIngridients.SelectedItem != null)
            {
                Ingredient = ExistingIngridients.SelectedItem as Ingredient;
            }
            else
            {
                Ingredient = MapUserInputToIngredient();
                DataHandler.SaveIngredient( Ingredient );
            }

            this.DialogResult = true;
            this.Close();
        }

        private Ingredient MapUserInputToIngredient()
        {
            int calories;
            int carbs;
            int proteins;
            int sugars;
            int fats;
            int satfats;

            if(int.TryParse( CaloriesNewIngredient.Text , out calories ) &&
                int.TryParse( CarbsNewIngredient.Text , out carbs ) &&
                int.TryParse( ProteinsNewIngredient.Text , out proteins ) &&
                int.TryParse( SugarsNewIngredient.Text , out sugars ) &&
                int.TryParse( FatsNewIngredient.Text , out fats ) &&
                int.TryParse( SatFatsNewIngredient.Text , out satfats ))
            {
                return new Ingredient
                {
                    Name = NameNewIngredient.Text ,
                    NutritionData = new NutritionData
                    {
                        Calories = calories ,
                        CarbsGr = carbs ,
                        ProteinsGr = proteins ,
                        FatsGr = fats ,
                        SatFatsGr = satfats ,
                        SugarsGr = sugars ,
                    }
                };
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void SaveIngredientChanges( object sender , RoutedEventArgs e )
        {
            throw new NotImplementedException();
        }

        private void TextBox_TextChanged( object sender , TextChangedEventArgs e )
        {
            throw new NotFiniteNumberException();
        }
    }
}