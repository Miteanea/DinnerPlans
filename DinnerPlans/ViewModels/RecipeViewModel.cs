using DinnerPlans.Models;
using DinnerPlans.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace DinnerPlans.Models
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        private decimal TotalWeight;

        public RecipeViewModel( Recipe recipe = null )
        {
            if(recipe != null)
            {
                ID = recipe.ID;
                Instruction = recipe.Instruction;
                NutritionData = recipe.NutritionData;
                Title = recipe.Title;
                var ingredientsColl = recipe.IngredientEntries.Select( entry => new IngredientEntryViewModel
                {
                    Ingredient = new IngredientViewModel
                    {
                        ID = entry.Ingredient.ID ,
                        Name = entry.Ingredient.Name ,
                        NutritionData = entry.Ingredient.NutritionData ,
                        Unit = entry.Ingredient.Unit
                    } ,
                    Quantity = entry.Quantity
                } ).ToList();

                foreach(var item in ingredientsColl)
                {
                    Ingredients.Add( item );
                }

                foreach(IngredientEntryViewModel entry in Ingredients)
                {
                    entry.PropertyChanged += IngredientEntryChanges;
                }
            }

            Ingredients.CollectionChanged += this.OnCollectionChanged;
        }

        public RecipeID ID { get; set; }

        public string Instruction { get; set; }

        private NutritionData _nutritionData;

        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set
            {
                _nutritionData = value;
                PropertyChanged?.Invoke( this , new PropertyChangedEventArgs( nameof( NutritionData ) ) );
            }
        }

        public string Title { get; set; }

        public ObservableCollection<IngredientEntryViewModel> Ingredients { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void IngredientEntryChanges( object sender , PropertyChangedEventArgs e )
        {
            UpdateRecipe();
        }

        public void OnCollectionChanged( object sender , NotifyCollectionChangedEventArgs e )
        {
            UpdateRecipe();
        }

        private void UpdateRecipe()
        {
            UpdateNutritionData();
            UpdateRecipeWeight();
        }

        private void UpdateNutritionData()
        {
            // calculate and assign a value to _nutritionData (kcalx100g)
            NutritionData nutritionData = new NutritionData( NutritionDataType.Recipe );
            if(Ingredients != null)
            {
                foreach(var entry in Ingredients)
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
            if(Ingredients != null)
            {
                foreach(var entry in Ingredients)
                {
                    // For each type of ingredient
                    switch(entry.Ingredient.Unit)
                    {
                        case UnitType.None:
                            break;

                        case UnitType.Grams:
                            TotalWeight += entry.Quantity;
                            break;

                        case UnitType.Milliliters:
                            break;

                        case UnitType.Pieces:
                            break;

                        default:
                            break;
                    }
                    // calculate the weight
                    //add to recipe weight
                }
            }
        }
    }
}