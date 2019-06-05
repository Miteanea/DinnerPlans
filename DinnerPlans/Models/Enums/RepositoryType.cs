using DinnerPlans.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace DinnerPlans.Services
{

    public enum RepositoryType
    {
        None = 0,
        Recipes,
        Ingredients
    }
}