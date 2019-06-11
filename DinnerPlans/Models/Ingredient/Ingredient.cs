using DinnerPlans.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject]
    public class Ingredient : IIngredient, INotifyPropertyChanged
    {
        public Ingredient()
        {
            ID = GetID();
            NutritionData = new NutritionData( NutritionDataType.Ingredient );
        }

        [JsonConstructor]
        public Ingredient( IngredientID iD , NutritionData nutritionData )
        {
            ID = iD;
            NutritionData = nutritionData;

            NutritionData.PropertyChanged += OnNutritionDataChange;
        }

        // Public
        public IngredientID ID { get; set; }

        public string Name { get; set; }

        public UnitType Unit { get; set; }

        public NutritionData NutritionData { get; set; }

        // Private
        private IngredientID GetID()
        {
            return new IngredientID( DataHandler.GenerateUniqueRandomID() );
        }

        // Events and Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNutritionDataChange( object sender , PropertyChangedEventArgs e )
        {
            PropertyChanged.Invoke( this , null );
            DataHandler.SaveIngredient( this );
        }
    }
}