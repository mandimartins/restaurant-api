using FluentValidation.Results;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Utilities.ExtensionMethods
{
    public static class NotificationExtension
    {
        public static bool Notify(this ValidationResult validationResult, INotificationHandler notificationHandler)
        {
            AddMessage(validationResult, notificationHandler);
            return validationResult.IsValid;
        }

        private static void AddMessage(ValidationResult validationResult, INotificationHandler notificationHandler)
        {
            if (validationResult.IsValid)
                return;

            foreach (var error in validationResult.Errors)
            {
                notificationHandler.AddMessage(new Message(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}
