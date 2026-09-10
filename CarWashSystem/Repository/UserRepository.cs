using CarWashSystem.Models;
using CarWashSystem.Repository;

namespace CarWashSystem.Repository
{
    internal class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        internal void AddUser(User user)
        {
            this._users.Add(user);
        }

        internal bool RemoveUser(User user)
        {
            if (this.IsUsersEmpty())
            {
                return false;
            }

            this._users.Remove(user);
            return true;
        }

        internal bool UpdateUser(User user)
        {
            if (this.IsUsersEmpty())
            {
                return false;
            }

            var existing = this.GetUserById(user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
                existing.PhoneNumber = user.PhoneNumber;
                existing.Password = user.Password;
            }

            return true;
        }

        internal User? GetUserById(Guid id)
        {
            return this._users.FirstOrDefault(u => u.Id == id);
        }

        internal bool IsUsersEmpty()
        {
            return this._users.Count == 0;
        }

        internal List<User> GetAllUserData()
        {
            return this._users;
        }

        internal bool CheckUserData(int phone, string password)
        {
            return this._users.Any(u => u.PhoneNumber == phone && u.Password == password);
        }

        internal User? GetUserByData(int phone, string? password)
        {
            return this._users.FirstOrDefault(u => u.PhoneNumber == phone && u.Password == password);
        }
    }
}