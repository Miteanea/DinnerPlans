using System.ComponentModel;

namespace DinnerPlans.ViewModels
{
    internal class RecipesViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}