using DinnerPlans.API.Controllers;
using DinnerPlans.API.Models;
using DinnerPlans.API.Models.Enums;
using System;
using System.Collections.Generic;

namespace DinnerPlans.API.Services.MenuService
{
    public class MenuService : IMenuService
    {
        public MenuService(IShoppingCartService shoppingCartService)
        {
        }

        private IShoppingCartService _shoppingCart;

        public Menu GetMenu(MenuTimespan menuPeriod)
        {
            return GenerateMenu(menuPeriod);
        }

        private Menu GenerateMenu(MenuTimespan menuPeriod)
        {
            var menu = new Menu();

            menu.Meals = GetMeals(menuPeriod);

            menu.shoppingCart = _shoppingCart.GenerateShoppingCart(menu.Meals);

            return menu;
        }

        private List<DailyMenu> GetMeals(MenuTimespan menuPeriod)
        {
            throw new NotImplementedException();
        }
    }
}