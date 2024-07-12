namespace Restaurant.Utilities.NotificationPattern
{
    public class NotificationHandler:INotificationHandler
    {
        private IList<Message> _messages;
        public IList<Message> Messages()
        {
           return _messages;
        }

        public NotificationHandler()
        {
           _messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }
    }

    public class Message
    {
        public Message(string title = "", string content= "", dynamic additionalInfo = null)
        {
            Title = title;
            Content = content;
            AdditionalInfo = additionalInfo;  
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public dynamic AdditionalInfo { get; set; }
    }
}
