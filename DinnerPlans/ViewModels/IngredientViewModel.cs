using DinnerPlans.Models;
using DinnerPlans.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DinnerPlans.ViewModels
{
    public class IngredientViewModel : INotifyPropertyChanged
    {
        public IngredientViewModel()
        {
            ID = GetID();
            NutritionData = new NutritionData( NutritionDataType.Ingredient );
        }

        // Public
        public IngredientID ID { get; set; }

        public string Name { get; set; }

        public UnitType Unit { get; set; }

        private NutritionData _nutritionData;

        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set { _nutritionData = value; OnNutritionDataChange(); }
        }

        // Private
        private IngredientID GetID()
        {
            return new IngredientID( DataHandler.GenerateUniqueRandomID() );
        }

        // Events and Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNutritionDataChange()
        {
            PropertyChanged.Invoke( this , null );
            DataHandler.SaveIngredient( this );
        }
    }
}