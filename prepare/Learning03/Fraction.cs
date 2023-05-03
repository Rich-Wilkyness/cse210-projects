using System;

class Fraction
{
    private int _top;
    private int _bottom;
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public void GetTop()
    {
        Console.WriteLine(_top);
    }
    public int SetTop(int top)
    {
        _top = top;
        return _top;
    }
    public void GetBottom()
    {
        Console.WriteLine(_bottom);
    }
    public int SetBottom(int bottom)
    {
        _bottom = bottom;
        return _bottom;
    }
    public string GetFractionString()
    {
        // string topString = _top.ToString();
        // string bottomString = _bottom.ToString();
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        double decTop = _top;
        double decBottom = _bottom;
        // could have return (double)_top / (double)_bottom;
        return decTop / decBottom;
    }
}