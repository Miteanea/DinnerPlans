namespace DinnerPlans.API.Models
{
    public class NutritionFacts
    {
        public double Carbs { get; set; }
        public double Proteins { get; set; }
        public double Sugars { get; set; }
        public double Fats { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
    }
}