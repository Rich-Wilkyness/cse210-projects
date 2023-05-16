using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapesList = new List<Shape>();

        Square square = new Square("blue", 4);
        shapesList.Add(square);
        Rectangle rectangle = new Rectangle("green", 4, 2);
        shapesList.Add(rectangle);
        Circle circle = new Circle("red", 3);
        shapesList.Add(circle);
        foreach (Shape shape in shapesList)
        {
            string color = shape.GetColor();
            double area = shape.CalculateArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}