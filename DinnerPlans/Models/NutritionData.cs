namespace DinnerPlans.Models
{
    public class NutritionData
    {
        public NutritionDataType Type
        {
            get; set;
        }

        public int Calories
        {
            get; set;
        }

        public int CarbsGr
        {
            get; set;
        }

        public int ProteinsGr
        {
            get; set;
        }

        public int SugarsGr
        {
            get; set;
        }

        public int FatsGr
        {
            get; set;
        }

        public int SaltsGr
        {
            get; set;
        }

        public int SatFatsGr { get; internal set; }
    }

    public enum NutritionDataType
    {
        None,
        Ingredient,
        Recipe
    }
}