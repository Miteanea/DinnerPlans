namespace DinnerPlans.Models
{
    public interface IIngredient
    {
        IngredientID ID { get; set; }
        string Name { get; set; }
        NutritionData NutritionData { get; set; }
        int Quantity { get; set; }
        UnitType Unit { get; set; }
    }
}