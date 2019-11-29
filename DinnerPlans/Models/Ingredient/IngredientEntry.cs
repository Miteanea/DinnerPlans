using Newtonsoft.Json;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IngredientEntry : INotifyPropertyChanged
    {
        [JsonConstructor]
        public IngredientEntry()
        {
        }

        public IngredientEntry(decimal quantity = 0)
        {
            _ingredient = new Ingredient();
            _quantity = quantity;

            Ingredient.PropertyChanged += OnIngredientEntryChanged;
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