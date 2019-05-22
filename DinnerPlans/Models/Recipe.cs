using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    internal class Recipe
    {
        public Recipe()
        {
            ID = GetID();
            _ingredients = new ObservableCollection<Ingredient>();
            ListOfIngredientsChange += HandleIngredientsChange;
        }

        private RecipeID GetID()
        {
            return new RecipeID();
        }

        public RecipeID ID { get; set; }

        public string Title { get; set; }

        public Origin Origin { get; set; }

        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                _ingredients = value;
                ListOfIngredientsChange?.Invoke( _ingredients );
            }
        }

        private ObservableCollection<Ingredient> _ingredients;

        public string Instruction { get; set; }

        public NutritionData NutritionData { get { return _nutritionData; } }
        private NutritionData _nutritionData;

        public event IngredientChangeHandler ListOfIngredientsChange;

        public delegate void IngredientChangeHandler( ObservableCollection<Ingredient> ingredients );

        private void HandleIngredientsChange( ObservableCollection<Ingredient> ingredients )
        {
            // calculate and assign a value to _nutritionData (kcalx100g)

            //throw new NotImplementedException();
        }
    }

    internal enum Origin
    {
        None = 0,
        Italian,
        Thai,
        Russian
    }
}