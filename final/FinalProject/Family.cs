using System;

abstract class Family
{
    protected decimal _money;
    protected string _name;
    public Family(string name, decimal money)
    {
        _name = name;
        _money = money;
    }
    public abstract void DisplayList();
    public abstract void DisplayMoney();
    public abstract void Save();
    public abstract void Load();
}