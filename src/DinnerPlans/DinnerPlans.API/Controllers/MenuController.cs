using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DinnerPlans.Logic.Services;
using DinnerPlans.Models.Domain;

namespace DinnerPlans.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;
        public MenuController(ILogger<MenuController> logger,
            IMenuService _menuService)
        {
            _logger = logger;
        }

        [HttpGet]
        public Menu GetDailyMenu(Guid userId)
        {
            return _menuService.RandomDailyMenu(userId);
        }
    }
}
