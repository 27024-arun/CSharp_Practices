namespace CoffeeShopApp.Services
{
    internal class NotificationService
    {
        public delegate void Notifier(string message);

        public event Notifier? NotifierEvent;

        public void NotifyUser(string message)
        {
            NotifierEvent?.Invoke(message);
        }
    }
}
