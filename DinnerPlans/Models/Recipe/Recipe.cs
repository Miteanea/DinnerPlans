using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject]
    internal class Recipe : IRecipe, INotifyPropertyChanged
    {
        public Recipe()
        {
        }

        [JsonConstructor]
        public Recipe( ObservableCollection<Ingredient> ingredients )
        {
            Ingredients = ingredients;
        }

        [JsonProperty]
        public RecipeID ID { get; set; }

        [JsonProperty]
        public string Instruction { get; set; }

        [JsonProperty]
        public NutritionData NutritionData { get { return _nutritionData; } set { _nutritionData = value; OnPropertyChanged( "NutritionData" ); } }

        private NutritionData _nutritionData;

        [JsonProperty]
        public string Title { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public void HandleIngredientsChange( ObservableCollection<Ingredient> ingredients )
        {
            // calculate and assign a value to _nutritionData (kcalx100g)
            NutritionData nutritionData = new NutritionData();
            if(Ingredients != null)
            {
                foreach(var ingredient in ingredients)
                {
                    NutritionData data = ingredient.NutritionData;
                    if(data != null)
                    {
                        var quantityRatio = ingredient.Quantity / 100;
                        nutritionData.Calories += data.Calories * quantityRatio;
                        nutritionData.CarbsGr += data.CarbsGr * quantityRatio;
                        nutritionData.FatsGr += data.FatsGr * quantityRatio;
                        nutritionData.ProteinsGr += data.ProteinsGr * quantityRatio;
                        nutritionData.SaltsGr += data.SaltsGr * quantityRatio;
                        nutritionData.SugarsGr += data.SugarsGr * quantityRatio;
                    }
                }
            }
            NutritionData = nutritionData;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged( string name )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler( this , new PropertyChangedEventArgs( name ) );
            }
        }
    }
}