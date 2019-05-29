namespace DinnerPlans.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            // get ingredient ID

            // Set Nutrition Data
            // Break Nutrition Data into properties

            // Calculate Nutrition Data
        }

        // ID

        public string Name
        {
            get; set;
        }

        public int QuantityGr { get; set; }

        public NutritionData NutritionData { get; set; }
    }
}