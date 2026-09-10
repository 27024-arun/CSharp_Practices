using CarWashSystem.Services;

namespace CarWashSystem.View
{
    internal class SignUpView
    {
        private readonly UserServices _userServices;

        public SignUpView(UserServices userServices)
        {
            this._userServices = userServices;
        }

        internal void SignUpMenu()
        {
            Console.Clear();
            Console.WriteLine("----------SignUp Menu----------");
            string? name = ViewHelper.GetStringData("Name");
            if (string.IsNullOrEmpty(name))
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            int phone = ViewHelper.GetIntData("Phone");
            if (phone == 0)
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            string? email = ViewHelper.GetStringData("Email");
            if (string.IsNullOrEmpty(email))
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            string? password = ViewHelper.GetStringData("Password");
            if (string.IsNullOrEmpty(password))
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            if (this._userServices.AddUserData(name, phone, email, password))
            {
                Console.WriteLine("User data is added");
            }
            else
            {
                Console.WriteLine("User data is not added");
            }

            Console.WriteLine("\nEnter any key to return to main menu");
            Console.ReadKey();
        }
    }
}
