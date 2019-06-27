using DinnerPlans.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IngredientEntry
    {
        public IngredientEntry(IngredientEntryViewModel ingredientViewModel = null)
        {
            if (ingredientViewModel != null)
            {
                Ingredient = new Ingredient
                {
                    ID = ingredientViewModel.Ingredient.ID,
                    Name = ingredientViewModel.Ingredient.Name,
                    NutritionData = ingredientViewModel.Ingredient.NutritionData,
                    Unit = ingredientViewModel.Ingredient.Unit
                };
                Quantity = ingredientViewModel.Quantity;
            }
            Ingredient = new Ingredient();
        }

        [JsonConstructor]
        public IngredientEntry(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }

        // Public

        public Ingredient Ingredient { get { return _ingredient; } set { _ingredient = value; } }
        public decimal Quantity { get { return _quantity; } set { _quantity = value; QuantityChanged(); } }

        // Private
        [JsonProperty(nameof(Quantity))]
        private decimal _quantity;

        [JsonProperty(nameof(Ingredient))]
        private Ingredient _ingredient;

        // Events and handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void QuantityChanged()
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
        }

        private void OnIngredientEntryChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged.Invoke(this, null);
        }
    }
}