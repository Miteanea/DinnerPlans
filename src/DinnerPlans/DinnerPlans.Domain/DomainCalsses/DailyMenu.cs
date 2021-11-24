using System.Collections.Generic;

namespace DinnerPlans.API.Models
{
    public class DailyMenu
    {
        public List<Meal> Meals { get; set; }

        public int CaloricIntake { get; set; }
    }
}