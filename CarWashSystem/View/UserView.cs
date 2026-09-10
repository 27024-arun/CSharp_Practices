using CarWashSystem.Models;
using CarWashSystem.Services;

namespace CarWashSystem.View
{
    internal class UserView
    {
        private readonly UserServices _userServices;

        public UserView(UserServices userServices)
        {
            this._userServices = userServices;
        }

        public void SignUpMenu()
        {
            while (true)
            {
                string userMenu = $@"
Car Wash Menu
1. Create User
2. View User
3. Update User
4. Delete User";
                Console.WriteLine(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        this.AddUser();
                        break;
                    case 2:
                        this.DisplayUserData();
                        break;
                    case 3:
                        this.UpdateUser();
                        break;
                    case 4:
                        this.DeleteUser();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        public void AddUser()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter user Phone Number: ");
            int.TryParse(Console.ReadLine(), out int phone);

            Console.Write("Enter user mail id: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password of the user: ");
            string password = Console.ReadLine();

            if (this._userServices.AddUserData(name, phone, email, password))
            {
                Console.WriteLine("User data is added");
            }
            else
            {
                Console.WriteLine("User data is not added");
            }
        }

        public void UpdateUser()
        {
            Console.WriteLine("Enter user id: ");
            int.TryParse(Console.ReadLine(), out int index);

            Console.Write("Enter user name:");
            string name = Console.ReadLine();

            Console.Write("Enter user Phone Number: ");
            int.TryParse(Console.ReadLine(), out int phone);

            Console.Write("Enter user mail id: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password of the user: ");
            string password = Console.ReadLine();

            List<User> user = this._userServices.GetAllUsers();
            if (this._userServices.UpdateUserData(user[index - 1].Id, name, phone, email, password))
            {
                Console.WriteLine("User data is updated");
            }
            else
            {
                Console.WriteLine("User data is not updated");
            }
        }

        public void DeleteUser()
        {
            Console.WriteLine("Enter user id: ");
            int.TryParse(Console.ReadLine(), out int index);

            List<User> user = this._userServices.GetAllUsers();
            if (this._userServices.DeleteUserData(user[index - 1].Id))
            {
                Console.WriteLine("User data is deleted");
            }
            else
            {
                Console.WriteLine("User data is not deleted");
            }
        }

        public void DisplayUserData()
        {
            if (this._userServices.IsUserRepoEmpty())
            {
                Console.WriteLine("User data is empty");
                return;
            }

            int i = 0;
            List<User> users = this._userServices.GetAllUsers();
            foreach (User user in users)
            {
                Console.WriteLine($"Id: {++i}\nName: {user.Name}\nPhone: {user.PhoneNumber}\nMail: {user.Email}");
            }
        }
    }
}
