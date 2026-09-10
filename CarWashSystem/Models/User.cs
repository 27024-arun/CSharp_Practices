namespace CarWashSystem.Models
{
    internal class User
    {
        public User()
        {
        }

        internal User(Guid id, string name, int phone, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phone;
            this.Email = email;
            this.Password = password;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
