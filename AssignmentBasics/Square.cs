using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics
{
    internal class Square : IShapes
    {
        public Square() { }

        public Square(double Side) 
        {
            this.Side = Side;
        }

        public double Side { get; set; }

        public string Name => "Square";

        public string? Description { get; set; }

        public double CalculateArea()
        {
            return this.Side * this.Side;
        }

        public void Print()
        {
            Console.WriteLine($"Side: {this.Side} Area: {this.CalculateArea()}");
        }
    }
}
