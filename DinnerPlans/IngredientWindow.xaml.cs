using DinnerPlans.Models;
using DinnerPlans.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            _ingredients = DataHandler.IngredientsRepository.Ingredients;

            UnitSelector.ItemsSource = Enum.GetValues( typeof( UnitType ) ).Cast<UnitType>();

            // ExistingIngridients.Items.Clear();
            ExistingIngridients.ItemsSource = _ingredients;
        }

        public Ingredient Ingredient { get; set; }
        private ObservableCollection<Ingredient> _ingredients { get; set; }

        private void Add_Ingredient_Clicked( object sender , RoutedEventArgs e )
        {
            if(ExistingIngridients.SelectedItem != null)
            {
                Ingredient = ExistingIngridients.SelectedItem as Ingredient;
            }
            else
            {
                Ingredient = MapUserInputToIngredient();
            }

            this.DialogResult = true;
            this.Close();
        }

        private Ingredient MapUserInputToIngredient()
        {
            decimal calories;
            decimal carbs;
            decimal proteins;
            decimal sugars;
            decimal fats;
            decimal satfats;
            UnitType unit;

            if(decimal.TryParse( CaloriesNewIngredient.Text , out calories )
                && decimal.TryParse( CarbsNewIngredient.Text , out carbs )
                && decimal.TryParse( ProteinsNewIngredient.Text , out proteins )
                && decimal.TryParse( SugarsNewIngredient.Text , out sugars )
                && decimal.TryParse( FatsNewIngredient.Text , out fats )
                && decimal.TryParse( SatFatsNewIngredient.Text , out satfats )
                && Enum.TryParse( UnitSelector.Text , out unit ))
            {
                return new Ingredient
                {
                    Name = NameNewIngredient.Text ,
                    Unit = unit ,
                    NutritionData = new NutritionData(
                        NutritionDataType.Ingredient ,
                        calories ,
                        carbs ,
                        proteins ,
                        fats ,
                        satfats ,
                        sugars )
                };
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void SaveIngredientChanges( object sender , RoutedEventArgs e )
        {
            DataHandler.SaveIngredientChanges();
        }

        private void TextBox_TextChanged( object sender , TextChangedEventArgs e )
        {
            // throw new NotFiniteNumberException();
        }

        private void TextBox_GotKeyboardFocus( object sender , KeyboardFocusChangedEventArgs e )
        {
            if(e.KeyboardDevice.IsKeyDown( Key.Tab ))
                ( (TextBox)sender ).SelectAll();
        }
    }
}