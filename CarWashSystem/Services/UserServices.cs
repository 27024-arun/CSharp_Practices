using CarWashSystem.Models;
using CarWashSystem.Repository;

namespace CarWashSystem.Services
{
    internal class UserServices
    {
        private readonly JSONUserRepository _userRepository;

        public UserServices(JSONUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        internal bool AddUserData(string name, int phone, string email, string password)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                PhoneNumber = phone,
                Email = email,
                Password = password,
            };
            this._userRepository.AddUser(user);
            return true;
        }

        internal bool DeleteUserData(Guid id)
        {
            var user = this._userRepository.GetUserById(id);
            if (user == null)
            {
                return false;
            }

            this._userRepository.RemoveUser(user);
            return true;
        }

        internal bool UpdateUserData(Guid id, string name, int phone, string email, string password)
        {
            var user = this._userRepository.GetUserById(id);
            if (user == null)
            {
                return false;
            }

            User newUser = new User()
            {
                Id = id,
                Name = name,
                PhoneNumber = phone,
                Email = email,
                Password = password,
            };
            return this._userRepository.UpdateUser(newUser);
        }

        internal List<User> GetAllUsers()
        {
            return this._userRepository.GetAllUserData();
        }

        internal bool IsUserRepoEmpty()
        {
            return this._userRepository.IsUsersEmpty();
        }

        internal bool CheckUserExists(int phone, string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return this._userRepository.CheckUserData(phone, password);
        }

        internal User? GetUserById(Guid id)
        {
            return this._userRepository.GetUserById(id);
        }

        internal User? GetUserId(int phone, string? password)
        {
            return this._userRepository.GetUserByData(phone, password);
        }
    }
}