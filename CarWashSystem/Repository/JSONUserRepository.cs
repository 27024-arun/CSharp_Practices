using System.Text.Json;
using System.Text.Json.Serialization;
using CarWashSystem.Models;
using CarWashSystem.Repository;

namespace CarWashSystem.Repository
{
    internal class JSONUserRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = true,
        };

        internal JSONUserRepository(string filePath)
        {
            this._filePath = filePath;
            this._users = this.LoadAll();
        }

        internal void AddUser(User user)
        {
            this._users.Add(user);
            this.WriteAll();
        }

        internal bool RemoveUser(User user)
        {
            if (this.IsUsersEmpty())
            {
                return false;
            }

            this._users.Remove(user);
            this.WriteAll();
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

            this.WriteAll();
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

        private void WriteAll()
        {
            string fileData = JsonSerializer.Serialize(this._users, this._options);
            File.WriteAllText(this._filePath, fileData);
        }

        private List<User> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<User>();
            }

            string fileData = File.ReadAllText(this._filePath);
            return JsonSerializer.Deserialize<List<User>>(fileData, this._options) ?? new List<User>();
        }
    }
}