namespace AssignmentBasics
{
    internal class Rectangle1 : IShapes
    {
        public Rectangle1() { }

        public Rectangle1(double Length, double Width)
        {
            this.Length = Length;
            this.Width = Width;
        }

        public double Length { get; set; }

        public double Width { get; set; }

        public string Name => "Rectangle";

        public string? Description { get; set; }

        public double CalculateArea()
        {
            return this.Length * this.Width;
        }

        public void Print()
        {
            Console.WriteLine($"Length: {this.Length} Width: {this.Width} Area: {CalculateArea()}");
        }
    }
}
