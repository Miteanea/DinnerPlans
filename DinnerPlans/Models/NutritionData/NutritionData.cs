using Newtonsoft.Json;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    public class NutritionData : INotifyPropertyChanged
    {
        public NutritionData()
        {

        }
        public NutritionData(NutritionDataType nutrtitionDataType,
            decimal calories = 0,
            decimal carbs = 0,
            decimal proteins = 0,
            decimal fats = 0,
            decimal sugars = 0,
            decimal satfats = 0,
            decimal salts = 0)
        {
            Type = nutrtitionDataType;
            _calories = calories;
            _carbsGr = carbs;
            _proteinsGr = proteins;
            _fatsGr = fats;
            _satFatsGr = satfats;
            _sugarsGr = sugars;
            _saltsGr = salts;
        }

        // Public
        public int NutritionDataId { get; set; }

        public decimal Calories { get { return _calories; } set { _calories = value; OnPropertyChanged("Calories"); } }

        public decimal CarbsGr { get { return _carbsGr; } set { _carbsGr = value; OnPropertyChanged("CarbsGr"); } }

        public decimal ProteinsGr { get { return _proteinsGr; } set { _proteinsGr = value; OnPropertyChanged("ProteinsGr"); } }

        public decimal SugarsGr { get { return _sugarsGr; } set { _sugarsGr = value; OnPropertyChanged("SugarsGr"); } }

        public decimal FatsGr { get { return _fatsGr; } set { _fatsGr = value; OnPropertyChanged("FatsGr"); } }

        public decimal SaltsGr { get { return _saltsGr; } set { _saltsGr = value; OnPropertyChanged("SaltsGr"); } }

        public decimal SatFatsGr { get { return _satFatsGr; } set { _satFatsGr = value; OnPropertyChanged("SatFatsGr"); } }

        public NutritionDataType Type { get; set; }

        // Private
        private decimal _calories;

        private decimal _carbsGr;

        private decimal _proteinsGr;

        private decimal _sugarsGr;

        private decimal _fatsGr;

        private decimal _saltsGr;

        private decimal _satFatsGr;

        // Events and Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (Type == NutritionDataType.Ingredient)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}