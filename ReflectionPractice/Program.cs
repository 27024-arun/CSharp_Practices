using System.Reflection;

public class Person
{
    public string Name { get; set; }
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        this.age = age;
    }

    public void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {age} years old.");
    }

    private void SecretMethod()
    {
        Console.WriteLine("This is a private method!");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Person person = new Person("Alice", 30);

            Type type = typeof(Person);

            Console.WriteLine("=== Type Information ===");
            Console.WriteLine($"Full Name: {type.FullName}");
            Console.WriteLine($"Namespace: {type.Namespace}");

            Console.WriteLine("\n=== Public Properties ===");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
            }

            Console.WriteLine("\n=== Fields (All) ===");
            foreach (FieldInfo field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($"{field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine("\n=== Methods (All) ===");
            foreach (MethodInfo method in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($"{method.ReturnType.Name} {method.Name}()");
            }

            Console.WriteLine("\n=== Invoking Public Method ===");
            MethodInfo greetMethod = type.GetMethod("Greet");
            greetMethod.Invoke(person, null);

            Console.WriteLine("\n=== Invoking Private Method ===");
            MethodInfo secretMethod = type.GetMethod("SecretMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            secretMethod.Invoke(person, null);

            Console.WriteLine("\n=== Modifying Private Field ===");
            FieldInfo ageField = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            ageField.SetValue(person, 40);
            greetMethod.Invoke(person, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
