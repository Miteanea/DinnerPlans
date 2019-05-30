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
            ListOfIngredientsChanged += HandleIngredientsChange;
        }

        private RecipeID GetID()
        {
            return new RecipeID();
        }

        public RecipeID ID { get; set; }

        public string Title { get; set; }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; ListOfIngredientsChanged?.Invoke( _ingredients ); }
        }

        private ObservableCollection<Ingredient> _ingredients;

        public string Instruction { get; set; }

        public NutritionData NutritionData { get { return _nutritionData; } set { _nutritionData = value; } }
        private NutritionData _nutritionData;

        public event IngredientChangeHandler ListOfIngredientsChanged;

        public delegate void IngredientChangeHandler( ObservableCollection<Ingredient> ingredients );

        private void HandleIngredientsChange( ObservableCollection<Ingredient> ingredients )
        {
            // calculate and assign a value to _nutritionData (kcalx100g)
            var calculatedNutritionData = new NutritionData();
            if(_ingredients != null)
            {
                foreach(var ingredient in ingredients)
                {
                    var data = ingredient.NutritionData;
                    var quantityRatio = ingredient.Quantity / 100;
                    if(data != null)
                    {
                        calculatedNutritionData.Calories += data.Calories * quantityRatio;
                        calculatedNutritionData.CarbsGr += data.CarbsGr * quantityRatio;
                        calculatedNutritionData.FatsGr += data.FatsGr * quantityRatio;
                        calculatedNutritionData.ProteinsGr += data.ProteinsGr * quantityRatio;
                        calculatedNutritionData.SaltsGr += data.SaltsGr * quantityRatio;
                        calculatedNutritionData.SugarsGr += data.SugarsGr * quantityRatio;
                    }
                }
            }
            _nutritionData = calculatedNutritionData;
        }
    }
}