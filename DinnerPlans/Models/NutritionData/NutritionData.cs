using System.ComponentModel;

namespace DinnerPlans.Models
{
    public class NutritionData : INotifyPropertyChanged
    {
        public int Calories { get { return _calories; } set { _calories = value; OnPropertyChanged( "Calories" ); } }

        private int _calories;

        public int CarbsGr { get; set; }

        public int ProteinsGr { get; set; }

        public int SugarsGr { get; set; }

        public int FatsGr { get; set; }

        public int SaltsGr { get; set; }

        public int SatFatsGr { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged( string name )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler( this , new PropertyChangedEventArgs( name ) );
            }
        }
    }
}