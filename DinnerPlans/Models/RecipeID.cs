using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Models
{
    internal class RecipeID
    {
        public RecipeID()
        {
            Random rnd = new Random();
            ID = rnd.Next(1000);
        }

        private int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}