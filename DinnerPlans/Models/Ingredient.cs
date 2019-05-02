namespace DinnerPlans.Models
{
    public class Ingredient
    {
        // ID

        public string Name { get; set; }

        public int Quantity { get; set; }

        public NutritionData NutritionData { get; }
    }
}