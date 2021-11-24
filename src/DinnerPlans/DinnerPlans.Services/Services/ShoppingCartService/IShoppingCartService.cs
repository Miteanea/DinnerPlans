using DinnerPlans.API.Models;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.MenuService
{
    public interface IShoppingCartService
    {
        ShoppingCart GenerateShoppingCart(List<DailyMenu> meals);
    }
}