using System;
using DinnerPlans.Models.Domain;

namespace DinnerPlans.Logic.Services
{
    public interface IMenuService
    {
        Menu RandomDailyMenu(Guid userId);
    }

    class MenuService : IMenuService
    {
        private IRecipeService _recipeService;

        public MenuService(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public Menu RandomDailyMenu(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}


