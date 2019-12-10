using DinnerPlans.Services.Database;
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

            container.RegisterType<DinnerPlansContext>();
            container.RegisterType<IDataService, DataService>();
//            container.RegisterType<MainViewModel>();

            var vm = container.Resolve<MainViewModel>();

            var window = new MainWindow()
            {
                DataContext = vm
            };

            window.Show();
        }
    }
}