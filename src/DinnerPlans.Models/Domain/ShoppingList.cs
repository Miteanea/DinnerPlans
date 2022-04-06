using System.Collections.Generic;

namespace DinnerPlans.Models.Domain
{
    public class ShoppingList : List<ShoppingListEntry>
    {
    }

    public class ShoppingListEntry
    {
        public Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }
    }
}