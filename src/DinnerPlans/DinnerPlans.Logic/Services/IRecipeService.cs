using System.Collections;
using DinnerPlans.Data.Repositories;
using DinnerPlans.Models.Domain;

namespace DinnerPlans.Logic.Services
{
    public interface IRecipeService
    {
        Recipe Recipe();
    }

    public class RecipeService : IRecipeService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }
        public Recipe Recipe()
        {
            throw new System.NotImplementedException();
        }
    }
}
