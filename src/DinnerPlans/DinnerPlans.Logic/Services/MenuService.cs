using System;
using DinnerPlans.Models.Domain;

namespace DinnerPlans.Logic.Services
{
    public interface IMenuService
    {
        Menu RandomDailyMenu();
    }

    class MenuService : IMenuService
    {
        private IRecipeService _recipeService;

        public MenuService(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public Menu RandomDailyMenu()
        {
            throw new NotImplementedException();
        }
    }
}


