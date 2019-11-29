using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels;
using DinnerPlans.ViewModels.Commands;
using DinnerPlans.Views;
using System;
using System.Windows.Input;

namespace DinnerPlans
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel(IDataService data)
        {
            this.data = data;
        }

        public object Contents
        {
            get { return _content; }
            set
            {
                if (value != this._content)
                {
                    _content = value;
                    NotifyPropertyChanged();
                };
            }
        }

        private object _content;

        public IDataService data;

        public ICommand SwitchFeatureCommand
        {
            get
            {
                return new RelayCommand(SwitchContent);
            }
        }

        private void SwitchContent(object contentName)
        {
            switch ((string)contentName)
            {
                case "Recipes":
                    Contents = new RecipesView
                    {
                        DataContext = new RecipesViewModel(data)
                    };
                    break;

                case "Menus":
                    Contents = new MenusView(data);
                    break;

                default:
                    throw new ArgumentException("Command Parameter not Recognized");
            }
        }
    }
}