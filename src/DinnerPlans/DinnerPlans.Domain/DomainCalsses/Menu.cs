using DinnerPlans.API.Models.Enums;
using System.Collections.Generic;

namespace DinnerPlans.API.Models
{
    public class Menu
    {
        public List<DailyMenu> Meals { get; set; }
        private MenuTimespan Timespan { get; set; }

        public ShoppingCart shoppingCart { get; set; }
    }
}