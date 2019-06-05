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

    internal class RepositoryData
    {
        public RepositoryType Type;
        public string DefaultRepoFolder;
        public string RepoName;
        public string RepoFolderPath;
    }
}