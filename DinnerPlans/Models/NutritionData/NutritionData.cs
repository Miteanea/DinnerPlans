using Newtonsoft.Json;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject( MemberSerialization.OptIn )]
    public class NutritionData : INotifyPropertyChanged
    {
        public NutritionData( NutritionDataType nutrtitionDataType )
        {
            Type = nutrtitionDataType;
        }

        // Public
        public int Calories { get { return _calories; } set { _calories = value; OnPropertyChanged( "Calories" ); } }

        public int CarbsGr { get { return _carbsGr; } set { _carbsGr = value; OnPropertyChanged( "CarbsGr" ); } }

        public int ProteinsGr { get { return _proteinsGr; } set { _proteinsGr = value; OnPropertyChanged( "ProteinsGr" ); } }

        public int SugarsGr { get { return _sugarsGr; } set { _sugarsGr = value; OnPropertyChanged( "SugarsGr" ); } }

        public int FatsGr { get { return _fatsGr; } set { _fatsGr = value; OnPropertyChanged( "FatsGr" ); } }

        public int SaltsGr { get { return _saltsGr; } set { _saltsGr = value; OnPropertyChanged( "SaltsGr" ); } }

        public int SatFatsGr { get { return _satFatsGr; } set { _satFatsGr = value; OnPropertyChanged( "SatFatsGr" ); } }

        public NutritionDataType Type { get; set; }

        // Private
        [JsonProperty( nameof( Calories ) )]
        private int _calories;

        [JsonProperty( nameof( CarbsGr ) )]
        private int _carbsGr;

        [JsonProperty( nameof( ProteinsGr ) )]
        private int _proteinsGr;

        [JsonProperty( nameof( SugarsGr ) )]
        private int _sugarsGr;

        [JsonProperty( nameof( FatsGr ) )]
        private int _fatsGr;

        [JsonProperty( nameof( SaltsGr ) )]
        private int _saltsGr;

        [JsonProperty( nameof( SatFatsGr ) )]
        private int _satFatsGr;

        // Events and Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string name )
        {
            if(Type == NutritionDataType.Ingredient)
            {
                PropertyChanged.Invoke( this , new PropertyChangedEventArgs( name ) );
            }
        }
    }
}