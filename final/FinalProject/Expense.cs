using System;

class Expense
{
    public decimal _cost;
    public string _expenseName;
    protected string _expenseType; //Bill, Groceries, Chore, Entertainment, Transportation
    public string _recurrent;
    protected string _date;
    public decimal _currentAmount = 0;
    public Expense(decimal cost, string expenseName, string expenseType, string recurrent, string date)
    {
        _cost = cost;
        _expenseName = expenseName;
        _expenseType = expenseType;
        _recurrent = recurrent;
        _date = date;
    }
    public void DisplayExpense()
    {
        Console.WriteLine($"{_date} {_expenseName} ${_cost.ToString("F2")} {_expenseType} {_recurrent}");
    }
    public string SaveToFile()
    {
        return $"3 * {_date} * {_expenseName} * {_cost} * {_expenseType} * {_recurrent}";
    }
}