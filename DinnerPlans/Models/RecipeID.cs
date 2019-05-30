using System;

namespace DinnerPlans.Models
{
    internal class RecipeID
    {
        public RecipeID()
        {
            Random rnd = new Random();
            ID = rnd.Next( 1000 );
        }

        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        internal void SetStringValue( string value )
        {
            // Convert The string to whatever type ID Property is.
            throw new NotImplementedException();
        }
    }

    public class IngredientID
    {
        public IngredientID()
        {
            Random rnd = new Random();
            ID = rnd.Next( 1000 );
        }

        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        internal void SetStringValue( string value )
        {
            // Convert The string to whatever type ID Property is.
            throw new NotImplementedException();
        }
    }
}