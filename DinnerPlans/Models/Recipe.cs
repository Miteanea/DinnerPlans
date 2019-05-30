using System.Collections.ObjectModel;

namespace DinnerPlans.Models
{
    internal class Recipe
    {
        private ObservableCollection<Ingredient> _ingredients;

        private NutritionData _nutritionData;

        public Recipe()
        {
            ID = GetID();
            _ingredients = new ObservableCollection<Ingredient>();
            ListOfIngredientsChanged += HandleIngredientsChange;
        }

        public delegate void IngredientChangeHandler( ObservableCollection<Ingredient> ingredients );

        public event IngredientChangeHandler ListOfIngredientsChanged;

        public RecipeID ID { get; set; }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; ListOfIngredientsChanged?.Invoke( _ingredients ); }
        }

        public string Instruction { get; set; }

        public NutritionData NutritionData { get { return _nutritionData; } set { _nutritionData = value; } }

        public string Title { get; set; }

        private RecipeID GetID()
        {
            return new RecipeID();
        }

        private void HandleIngredientsChange( ObservableCollection<Ingredient> ingredients )
        {
            // calculate and assign a value to _nutritionData (kcalx100g)
            NutritionData nutritionData = new NutritionData();
            if(_ingredients != null)
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
            _nutritionData = nutritionData;
        }
    }
}