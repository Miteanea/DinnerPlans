using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DinnerPlans.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Ingredient : INotifyPropertyChanged
    {
        [JsonConstructor]
        public Ingredient()
        {
        }

        public Ingredient(NutritionData nutritionData = null)
        {
            ID = (_id == 0) ? CreateNewId() : _id;

            _nutritionData = (nutritionData != null)
                ? nutritionData
                : new NutritionData(NutritionDataType.Ingredient);
        }

        public int ID { get { return _id; } set { _id = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public UnitType Unit { get { return _unit; } set { _unit = value; } }

        public NutritionData NutritionData
        {
            get { return _nutritionData; }
            set { _nutritionData = value; OnNutritionDataChange(); }
        }

        [JsonProperty(nameof(ID))]
        private int _id;

        [JsonProperty(nameof(Name))]
        private string _name;

        [JsonProperty(nameof(Unit))]
        private UnitType _unit;

        [JsonProperty(nameof(NutritionData))]
        private NutritionData _nutritionData;

        private int CreateNewId()
        {
            // create random ID for a new instance of recipe
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNutritionDataChange()
        {
            PropertyChanged.Invoke(this, null);
            throw new NotImplementedException();
        }
    }
}