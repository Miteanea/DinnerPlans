using DinnerPlans.Services.DataService;
using System.Windows;
using Unity;

namespace DinnerPlans
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();

            container.RegisterType<IDataService, DataService>();
            container.RegisterType<MainViewModel>();
            // container.RegisterType<RecipesViewModel>();

            var vm = container.Resolve<MainViewModel>();

            var window = new MainWindow()
            {
                DataContext = vm
            };

            window.Show();
        }
    }
}