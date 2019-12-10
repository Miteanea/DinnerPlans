using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        public Ingredient()
        {
            _nutritionData = new NutritionData(NutritionDataType.Ingredient);
        }
        public Ingredient(NutritionData nutritionData = null)
        {
            _nutritionData = (nutritionData != null)
                ? nutritionData
                : new NutritionData(NutritionDataType.Ingredient);
        }

        public int IngredientId { get; set; }

        public string Name { get { return _name; } set { _name = value; } }

        public UnitType Unit { get { return _unit; } set { _unit = value; } }

        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set { _nutritionData = value; OnNutritionDataChange(); }
        }


        private string _name;

        private UnitType _unit;

        private NutritionData _nutritionData;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNutritionDataChange()
        {
            PropertyChanged.Invoke(this, null);
            throw new NotImplementedException();
        }
    }
}