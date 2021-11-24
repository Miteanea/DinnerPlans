using DinnerPlans.API.Models;
using DinnerPlans.API.Models.Enums;

namespace DinnerPlans.API.Controllers
{
    public interface IMenuService
    {
        Menu GetMenu(MenuTimespan menuPeriod);
    }
}