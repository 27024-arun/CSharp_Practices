namespace PracticeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    public class User
    {
        public string Name { get; set; } = "Anonymous"; // Initializer
        public int Age { get; set; }

        public User()
        {
            Name = "John Doe"; // Constructor initialization
            Age = 30;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string? Id { get; set; }

        public Person(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public Person(string name)
        {
            this.Name = name;
        }
    }
}
