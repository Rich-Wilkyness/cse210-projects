using System;

abstract class Family
{
    protected decimal _money = 0;
    protected string _name;
    protected string _filename;
    public Family(string name, string filename)
    {
        _name = name;
        _filename = filename;
    }

    public abstract void DisplayMoney();
    public abstract void Save();
}