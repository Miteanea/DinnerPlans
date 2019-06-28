﻿using DinnerPlans.Services;
using Newtonsoft.Json;

namespace DinnerPlans.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IngredientID : IId
    {
        public IngredientID(int id)
        {
            _id = id;
        }

        [JsonProperty(PropertyName = "ID")]
        public int Value { get { return _id; } set { _id = value; } }

        private int _id;
    }
}