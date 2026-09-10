using System.Drawing;
using AssignmentBasics;

namespace Assignments
{
    /// <summary>
    /// Program is a initialising class with Main function
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry function of the program
        /// </summary>
        public static void Main()
        {
            Rectangle1 rect = new Rectangle1();
            rect.Length = 20;
            rect.Width = 10;
            rect.Description = "Rectangle has 4 sides";
            rect.Print();

            IShapes shape = rect;
            shape.Description = "Description";
            Console.WriteLine(shape.Description);

            Rectangle1? prevRect = shape as Rectangle1;

            List<IShapes> shapes = new List<IShapes>();
            shapes.Add(new Rectangle1(5, 10));
            shapes.Add(new Square(5));

            Console.ReadLine();
        }
    }
}