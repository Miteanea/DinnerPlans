using DinnerPlans.Models;
using DinnerPlans.Services;
using System.ComponentModel;

namespace DinnerPlans.ViewModels
{
    public class IngredientViewModel : INotifyPropertyChanged
    {
        public IngredientViewModel(NutritionData nutritionData = null)
        {
            ID = GetID();

            if (nutritionData != null)
            {
                _nutritionData = nutritionData;
            }
            _nutritionData = new NutritionData(NutritionDataType.Ingredient);
        }

        // Public
        public IId ID { get; set; }

        public string Name { get; set; }

        public UnitType Unit { get; set; }

        private NutritionData _nutritionData;

        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set { _nutritionData = value; OnNutritionDataChange(); }
        }

        // Private
        private IId GetID()
        {
            return new IngredientID(IngredientDataHandler.GenerateUniqueRandomID());
        }

        // Events and Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNutritionDataChange()
        {
            PropertyChanged.Invoke(this, null);
            IngredientDataHandler.SaveIngredient(this);
        }
    }
}