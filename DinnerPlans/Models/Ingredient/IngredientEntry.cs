using System.ComponentModel;

namespace DinnerPlans.Models
{
    public class IngredientEntry : INotifyPropertyChanged
    {
        public IngredientEntry()
        {
            _ingredient = new Ingredient();
            Ingredient.PropertyChanged += OnIngredientEntryChanged;
        }

        public IngredientEntry(decimal quantity = 0)
        {
            _ingredient = new Ingredient();
            Ingredient.PropertyChanged += OnIngredientEntryChanged;

            _quantity = quantity;
        }

        // Public

        public int IngredientEntryId { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get { return _ingredient; } set { _ingredient = value; } }

        public decimal Quantity { get { return _quantity; } set { _quantity = value; QuantityChanged(); } }

        // Private
        private decimal _quantity;

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