namespace AssignmentBasics
{
    internal interface IShapes
    {
        string Name { get; }

        string? Description { get; set;  }

        double CalculateArea();

        void Print();
    }
}