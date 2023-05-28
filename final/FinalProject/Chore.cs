using System;

abstract class Chore : Expense
{
    bool _isComplete;
    public Chore(decimal cost, string expenseName, string expenseType, bool recurrent, DateTime date) : base(cost, expenseName, expenseType, recurrent, date)
    {
    }
    public abstract void Update();
    public abstract void Display();
    public abstract void SaveToChild();
}