using DinnerPlans.Models;
using DinnerPlans.Services;
using DinnerPlans.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DinnerPlans
{
    public partial class IngredientWindow : Window
    {
        public IngredientWindow()
        {
            InitializeComponent();
        }

        public IngredientViewModel Ingredient { get; set; }

        private ObservableCollection<IngredientViewModel> _ingredients { get; set; }

        private void Add_Ingredient_Clicked(object sender, RoutedEventArgs e)
        {
            if (ExistingIngridients.SelectedItem != null)
            {
                Ingredient = ExistingIngridients.SelectedItem as IngredientViewModel;
            }
            else
            {
                Ingredient = MapUserInputToIngredient();
            }

            this.DialogResult = true;
            this.Close();
        }

        private IngredientViewModel MapUserInputToIngredient()
        {
            decimal calories;
            decimal carbs;
            decimal proteins;
            decimal sugars;
            decimal fats;
            decimal satfats;
            UnitType unit;

            if (decimal.TryParse(CaloriesNewIngredient.Text, out calories)
                && decimal.TryParse(CarbsNewIngredient.Text, out carbs)
                && decimal.TryParse(ProteinsNewIngredient.Text, out proteins)
                && decimal.TryParse(SugarsNewIngredient.Text, out sugars)
                && decimal.TryParse(FatsNewIngredient.Text, out fats)
                && decimal.TryParse(SatFatsNewIngredient.Text, out satfats)
                && Enum.TryParse(UnitSelector.Text, out unit))
            {
                var nutritionData = new NutritionData(
                        NutritionDataType.Ingredient,
                        calories,
                        carbs,
                        proteins,
                        fats,
                        satfats,
                        sugars);

                return new IngredientViewModel(nutritionData)
                {
                    Name = NameNewIngredient.Text,
                    Unit = unit
                };
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void SaveIngredientChanges(object sender, RoutedEventArgs e)
        {
            IngredientDataHandler.SaveIngredientChanges();
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ingredients = IngredientDataHandler.GetIngredients();

            UnitSelector.ItemsSource = Enum.GetValues(typeof(UnitType)).Cast<UnitType>();

            CollectionViewSource cvsIngredients = new CollectionViewSource()
            {
                Source = _ingredients
            };

            cvsIngredients.View.Filter += new Predicate<object>(ShowIngredientsWithFilterString);

            ExistingIngridients.ItemsSource = cvsIngredients.View;
        }

        private bool ShowIngredientsWithFilterString(object ingredient)
        {
            Ingredient ingr = ingredient as Ingredient;
            var input = TextFilter.Text.ToLower();
            return ingr.Name.ToLower().Contains(input);
        }

        private void TextFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ExistingIngridients.ItemsSource).Refresh();
        }
    }
}