using CoffeeShopApp.Services;

namespace CoffeeShopApp.View
{
    internal class NotificationView
    {
        private NotificationService notificationService;

        public NotificationView(NotificationService notificationService)
        {
            this.notificationService = notificationService;
            notificationService.NotifierEvent += MessageNotifier;
        }

        private void MessageNotifier(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
