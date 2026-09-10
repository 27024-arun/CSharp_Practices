using System.Xml.Linq;

namespace LinqPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Student> students = new List<Student>();
                Student student1 = new Student();
                student1.FirstName = "Arun";
                student1.LastName = "Sekar";
                student1.Age = 24;
                student1.College = "KEC";
                students.Add(student1);

                Student student2 = new Student();
                student2.FirstName = "Peter";
                student2.LastName = "Parker";
                student2.Age = 25;
                student2.College = "KEC";
                students.Add(student2);

                Student student3 = new Student();
                student3.FirstName = "Ram";
                student3.LastName = "Kumar";
                student3.Age = 27;
                student3.College = "PSG";
                students.Add(student3);

                Student student4 = new Student();
                student4.FirstName = "Vijay";
                student4.LastName = "Kumar";
                student4.Age = 29;
                student4.College = "PSG";
                students.Add(student4);

                Student student5 = new Student();
                student5.FirstName = "Pravin";
                student5.LastName = "Raj";
                student5.Age = 27;
                student5.College = "PSG";
                students.Add(student5);

                Student student6 = new Student();
                student6.FirstName = "Raj";
                student6.LastName = "Ram";
                student6.Age = 21;
                student6.College = "KEC";
                students.Add(student6);

                List<Student> result = students.Where(student => student.Age > 20).GroupBy(student => student.College).SelectMany(stud => stud.OrderByDescending(s => s.FirstName)).ToList();
                foreach (Student student in result)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

    public class Student
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18 && value <= 35)
                {
                    age = value;
                }
                else
                {
                    throw new InvalidOperationException("Age should be greater than 20");
                }
            }
        }

        public string? College { get; set; }
    }
}
