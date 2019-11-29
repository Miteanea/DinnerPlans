using System.Windows.Controls;

namespace DinnerPlans.Views
{
    /// <summary>
    /// Interaction logic for MenusView.xaml
    /// </summary>
    public partial class MenusView : UserControl
    {
        public MenusView(Services.DataService.IDataService data)
        {
            InitializeComponent();
        }
    }
}