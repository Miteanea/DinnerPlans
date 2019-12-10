using DinnerPlans.Models;
using System;
using System.Linq;
using System.Windows.Controls;

namespace DinnerPlans.Views.IngredientViews
{
    /// <summary>
    /// Interaction logic for IngredientCreate.xaml
    /// </summary>
    public partial class IngredientCreateView : UserControl
    {
        public IngredientCreateView()
        {
            InitializeComponent();
            UnitSelector.ItemsSource = Enum.GetValues(typeof(UnitType)).Cast<UnitType>();
        }
    }
}