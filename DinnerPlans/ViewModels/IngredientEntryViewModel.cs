using System.ComponentModel;

namespace DinnerPlans.ViewModels
{
    public class IngredientEntryViewModel : INotifyPropertyChanged
    {
        public IngredientEntryViewModel()
        {
            _ingredient = new IngredientViewModel();
            Ingredient.PropertyChanged += OnIngredientEntryChanged;
        }

        // Public

        public IngredientViewModel Ingredient { get { return _ingredient; } set { _ingredient = value; } }
        public decimal Quantity { get { return _quantity; } set { _quantity = value; QuantityChanged(); } }

        // Private
        private decimal _quantity;

        private IngredientViewModel _ingredient;

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