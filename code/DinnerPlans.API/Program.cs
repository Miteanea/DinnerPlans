using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinnerPlans.API.Controllers;
using DinnerPlans.API.Models;
using DinnerPlans.API.Services.Data;
using DinnerPlans.API.Services.Data.Recipes;
using DinnerPlans.API.Services.Menu;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DinnerPlans.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddScoped<IIngredients, Ingredients>();
                    services.AddScoped<IRecipes, Recipes>();
                    services.AddScoped<IMenuService, Menus>();
                });
    }
}
