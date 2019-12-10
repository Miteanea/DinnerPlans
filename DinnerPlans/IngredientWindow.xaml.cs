using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DinnerPlans
{
    public partial class IngredientWindow : Window
    {
        public IngredientWindow()
        {
            InitializeComponent();

            _buttons = new List<Button>();
            _textBoxes = new List<TextBox>();


            //AddButtonsToList();
            //AddTextBoxesToList();

            //WindowLogic(IngWindowOperationType.Default);
        }

        private List<Button> _buttons;
        private List<TextBox> _textBoxes;

        
        ///UI Logic

        #region UI Logic

        //private void WindowLogic(IngWindowOperationType operationType)
        //{
        //    foreach (var btn in _buttons)
        //    {
        //        btn.IsEnabled = false;
        //    }
        //    foreach (var txtBox in _textBoxes)
        //    {
        //        txtBox.IsEnabled = false;
        //    }

        //    ExistingIngridients.IsEnabled = true;
        //    CreateIngredientBtn.Visibility = Visibility.Visible;
        //    CancelEditingBtn.Visibility = Visibility.Collapsed;

        //    switch (operationType)
        //    {
        //        case IngWindowOperationType.Default:
        //            CreateIngredientBtn.IsEnabled = true;
        //            break;

        //        case IngWindowOperationType.Create:
        //        case IngWindowOperationType.Modify:

        //            CreateIngredientBtn.Visibility = Visibility.Collapsed;

        //            foreach (var txtBox in _textBoxes)
        //            {
        //                txtBox.IsEnabled = true;
        //            }

        //            ExistingIngridients.IsEnabled = false;

        //            SaveChangesIngredientBtn.IsEnabled = true;
        //            AddIngredientBtn.IsEnabled = true;

        //            CancelEditingBtn.Visibility = Visibility.Visible;
        //            CancelEditingBtn.IsEnabled = true;

        //            break;

        //        default:
        //            throw new Exception("Something is really wrong here");
        //    }
        //}

        //private void AddTextBoxesToList()
        //{
        //    _textBoxes.Add(NameNewIngredient);
        //    _textBoxes.Add(CaloriesNewIngredient);
        //    _textBoxes.Add(CarbsNewIngredient);
        //    _textBoxes.Add(ProteinsNewIngredient);
        //    _textBoxes.Add(SugarsNewIngredient);
        //    _textBoxes.Add(FatsNewIngredient);
        //    _textBoxes.Add(SatFatsNewIngredient);
        //    _textBoxes.Add(SaltsNewIngredient);
        //}

        //private void AddButtonsToList()
        //{
        //    _buttons.Add(CreateIngredientBtn);
        //    _buttons.Add(SaveChangesIngredientBtn);
        //    _buttons.Add(AddIngredientBtn);
        //    _buttons.Add(CancelEditingBtn);
        //}

        //private bool ShowIngredientsWithFilterString(object ingredient)
        //{
        //    Ingredient ingr = ingredient as Ingredient;
        //    var input = TextFilter.Text.ToLower();
        //    return ingr.Name.ToLower().Contains(input);
        //}

        //private void CancelEditingBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    WindowLogic(IngWindowOperationType.Default);

        //    foreach (TextBox textBox in _textBoxes)
        //    {
        //        textBox.Text = null;
        //    }

        //    CancelEditingBtn.Visibility = Visibility.Collapsed;
        //}

        //private void Add_Ingredient_Clicked(object sender, RoutedEventArgs e)
        //{
        //    Ingredient = ExistingIngridients.SelectedItem as Ingredient;

        //    this.DialogResult = true;
        //    this.Close();
        //}

        //private void EditButton_Clicked(object sender, RoutedEventArgs e)
        //{
        //    WindowLogic(IngWindowOperationType.Modify);

        //    var ingredient = ExistingIngridients.SelectedItem as Ingredient;

        //    Ingredient.ID = ingredient.ID;
        //    NameNewIngredient.Text = ingredient.Name;
        //    UnitSelector.Text = ingredient.Unit.ToString();

        //    CaloriesNewIngredient.Text = ingredient.NutritionData.Calories.ToString();
        //    CarbsNewIngredient.Text = ingredient.NutritionData.CarbsGr.ToString();
        //    ProteinsNewIngredient.Text = ingredient.NutritionData.ProteinsGr.ToString();
        //    SugarsNewIngredient.Text = ingredient.NutritionData.SugarsGr.ToString();
        //    FatsNewIngredient.Text = ingredient.NutritionData.FatsGr.ToString();
        //    SatFatsNewIngredient.Text = ingredient.NutritionData.SatFatsGr.ToString();
        //}

        //private void Save_and_Add_Clicked(object sender, RoutedEventArgs e)
        //{
        //    Ingredient = MapUserInputToIngredient();

        //    _data.SaveIngredient(Ingredient);

        //    WindowLogic(IngWindowOperationType.Default);

        //    this.DialogResult = true;
        //    this.Close();
        //}

        //private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        //{
        //    MapUserInputToIngredient();

        //    _data.SaveIngredient(Ingredient);

        //    WindowLogic(IngWindowOperationType.Default);
        //}

        //private Ingredient MapUserInputToIngredient()
        //{
        //    decimal calories;
        //    decimal carbs;
        //    decimal proteins;
        //    decimal sugars;
        //    decimal fats;
        //    decimal salts;
        //    decimal satfats;
        //    UnitType unit;

        //    if (decimal.TryParse(CaloriesNewIngredient.Text, out calories)
        //        && decimal.TryParse(CarbsNewIngredient.Text, out carbs)
        //        && decimal.TryParse(ProteinsNewIngredient.Text, out proteins)
        //        && decimal.TryParse(SugarsNewIngredient.Text, out sugars)
        //        && decimal.TryParse(FatsNewIngredient.Text, out fats)
        //        && decimal.TryParse(SatFatsNewIngredient.Text, out satfats)
        //        && decimal.TryParse(SaltsNewIngredient.Text, out salts)
        //        && Enum.TryParse(UnitSelector.Text, out unit))
        //    {
        //        var nutritionData = new NutritionData(
        //                NutritionDataType.Ingredient,
        //                calories,
        //                carbs,
        //                proteins,
        //                fats,
        //                satfats,
        //                sugars,
        //                salts);

        //        return new Ingredient(nutritionData)
        //        {
        //            Name = NameNewIngredient.Text,
        //            Unit = unit
        //        };
        //    }
        //    else
        //    {
        //        throw new InvalidCastException();
        //    }
        //}

        //private void CreateIngredientBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    WindowLogic(IngWindowOperationType.Create);
        //}

        private void SaveIngredientChanges(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _ingredients = _data.Ingredients;

        //    UnitSelector.ItemsSource = Enum.GetValues(typeof(UnitType)).Cast<UnitType>();

        //    CollectionViewSource cvsIngredients = new CollectionViewSource()
        //    {
        //        Source = _ingredients
        //    };

        //    cvsIngredients.View.Filter += new Predicate<object>(ShowIngredientsWithFilterString);

        //    ExistingIngridients.ItemsSource = cvsIngredients.View;
        //}

        //private void TextFilter_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(ExistingIngridients.ItemsSource).Refresh();
        //}

        #endregion UI Logic
    }
}