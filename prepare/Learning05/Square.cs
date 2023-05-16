using System;

public class Square : Shape
{
    private double _length;

    public Square(string color, double length) : base(color)
    {
        _length = length;
    }
    public override double CalculateArea()
    {
        return _length * _length;
    }
}