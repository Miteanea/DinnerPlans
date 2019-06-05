using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public Recipe( ObservableCollection<IngredientEntry> ingredientEntries )
        {
            IngredientEntries = ingredientEntries;

            UpdateRecipe();

            foreach(IngredientEntry entry in IngredientEntries)
            {
                entry.PropertyChanged += IngredientEntryChanges;
            }
            IngredientEntries.CollectionChanged += this.OnCollectionChanged;
        }

        // Public
        [JsonProperty]
        public RecipeID ID { get; set; }

        [JsonProperty]
        public string Instruction { get; set; }

        [JsonProperty]
        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set
            {
                _nutritionData = value;
                PropertyChanged?.Invoke( this , new PropertyChangedEventArgs( nameof( NutritionData ) ) );
            }
        }

        public int TotalWeight { get; private set; }

        [JsonProperty]
        public string Title { get; set; }

        public ObservableCollection<IngredientEntry> IngredientEntries { get; set; }

        //Private
        private NutritionData _nutritionData;

        private void UpdateNutritionData()
        {
            // calculate and assign a value to _nutritionData (kcalx100g)
            NutritionData nutritionData = new NutritionData( NutritionDataType.Recipe );
            if(IngredientEntries != null)
            {
                foreach(var entry in IngredientEntries)
                {
                    NutritionData ingredientData = entry.Ingredient.NutritionData;
                    if(ingredientData != null)
                    {
                        decimal quantityMultiplier = 0;

                        switch(entry.Ingredient.Unit)
                        {
                            case UnitType.None:
                                throw new Exception( "Unit Type missing from Ingredient" );
                            case UnitType.Grams:
                            case UnitType.Milliliters:
                                quantityMultiplier = entry.Quantity / 100;
                                break;

                            case UnitType.Pieces:
                                quantityMultiplier = entry.Quantity;
                                break;
                        }

                        nutritionData.Calories += (int)Math.Round( ingredientData.Calories * quantityMultiplier );
                        nutritionData.CarbsGr += (int)Math.Round( ingredientData.CarbsGr * quantityMultiplier );
                        nutritionData.FatsGr += (int)Math.Round( ingredientData.FatsGr * quantityMultiplier );
                        nutritionData.ProteinsGr += (int)Math.Round( ingredientData.ProteinsGr * quantityMultiplier );
                        nutritionData.SaltsGr += (int)Math.Round( ingredientData.SaltsGr * quantityMultiplier );
                        nutritionData.SugarsGr += (int)Math.Round( ingredientData.SugarsGr * quantityMultiplier );
                    }
                }
            }
            NutritionData = nutritionData;
        }

        private void UpdateRecipeWeight()
        {
            TotalWeight = 0;

            foreach(var entry in IngredientEntries)
            {
                // For each type of ingredient
                // calculate the weight
                //add to recipe weight
            }
            throw new NotImplementedException();
        }

        // Events And Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnCollectionChanged( object sender , NotifyCollectionChangedEventArgs e )
        {
            UpdateRecipe();
        }

        private void UpdateRecipe()
        {
            UpdateNutritionData();
            UpdateRecipeWeight();
        }

        public void IngredientEntryChanges( object sender , PropertyChangedEventArgs e )
        {
            UpdateRecipe();
        }
    }
}