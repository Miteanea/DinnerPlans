using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject( MemberSerialization.OptIn )]
    public class IngredientEntry : INotifyPropertyChanged
    {
        public IngredientEntry()
        {
            Ingredient = new Ingredient();
            Ingredient.PropertyChanged += OnIngredientEntryChanged;
        }

        [JsonConstructor]
        public IngredientEntry( Ingredient ingredient )
        {
            Ingredient = ingredient;
            Ingredient.PropertyChanged += OnIngredientEntryChanged;
        }

        // Public

        public Ingredient Ingredient { get { return _ingredient; } set { _ingredient = value; } }
        public decimal Quantity { get { return _quantity; } set { _quantity = value; QuantityChanged( nameof( Quantity ) ); } }

        // Private
        [JsonProperty( nameof( Quantity ) )]
        private decimal _quantity;

        [JsonProperty( nameof( Ingredient ) )]
        private Ingredient _ingredient;

        // Events and handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void QuantityChanged( string name )
        {
            PropertyChanged.Invoke( this , new PropertyChangedEventArgs( nameof( Quantity ) ) );
        }

        private void OnIngredientEntryChanged( object sender , PropertyChangedEventArgs e )
        {
            PropertyChanged.Invoke( this , null );
        }
    }
}