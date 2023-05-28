using System;

class Expense
{
    protected decimal _cost;
    protected string _expenseName;
    protected string _expenseType; //Bill, Groceries, Chore, Entertainment, Transportation
    protected bool _recurrent;
    protected DateTime _date;
    protected string _formattedDate;
    public Expense(decimal cost, string expenseName, string expenseType, bool recurrent, DateTime date)
    {
        _cost = cost;
        _expenseName = expenseName;
        _expenseType = expenseType;
        _recurrent = recurrent;
        _date = date;
        _formattedDate = _date.ToString("yyyy-MM-dd");
    }
    public void DisplayExpense()
    {
        Console.WriteLine($"{_formattedDate}, {_expenseName}, {_cost}, {_expenseType} {_recurrent}");
    }
}