using System.Windows;

namespace DinnerPlans.Services.DataService
{
    public class DeleteRecipeMessage
    {
        public DeleteRecipeMessage(string recipeTitle)
        {
            Message = $"Are you sure you want to delete {recipeTitle}";
            Caption = "Delete Recipe";
            Button = MessageBoxButton.YesNo;
            Image = MessageBoxImage.Warning;
            DefaultResult = MessageBoxResult.No;
        }

        public string Message { get; }
        public string Caption { get; }
        public MessageBoxButton Button { get; }
        public MessageBoxImage Image { get; }
        public MessageBoxOptions Options { get; }
        public MessageBoxResult DefaultResult { get; }
    }

    public enum MessageTypes
    {
        Delete = 0
    }
}