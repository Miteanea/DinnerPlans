namespace DinnerPlans.Models
{
    public class Ingredient : IIngredient
    {
        public Ingredient()
        {
            ID = GetID();
        }

        // Public
        public IngredientID ID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public UnitType Unit { get; set; }

        public NutritionData NutritionData { get; set; }

        // Private
        private IngredientID GetID()
        {
            return new IngredientID();
        }
    }
}