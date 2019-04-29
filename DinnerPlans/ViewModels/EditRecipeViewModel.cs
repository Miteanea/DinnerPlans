using DinnerPlans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DinnerPlans.ViewModels
{
    internal class EditRecipeViewModel
    {
        public EditRecipeViewModel(Recipe recipe)
        {
            if (recipe != null)
            {
                Recipe = recipe;
            }
            else
            {
                Recipe = new Recipe();
            }
        }

        public Recipe Recipe { get; set; }
    }
}