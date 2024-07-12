namespace Restaurant.Utilities.NotificationPattern
{
    public interface INotificationHandler
    {
        void AddMessage(Message message);
        IList<Message> Messages();
    }
}
