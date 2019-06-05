using Newtonsoft.Json;
using System;

namespace DinnerPlans.Models
{
    [JsonObject( MemberSerialization.OptIn )]
    public class RecipeID
    {
        public RecipeID()
        {
            Random rnd = new Random();
            _id = rnd.Next(int.MinValue, int.MaxValue );
        }

        [JsonProperty( PropertyName = "ID" )]
        public int Value { get { return _id; } set { _id = value; } }

        private int _id;
    }
}