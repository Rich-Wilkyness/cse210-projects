using System;

class Chore : Expense
{
    public int _timesCompleted = 0;
    public string _taken = "n";
    public Chore(decimal cost, string expenseName, string expenseType, string recurrent, string date) : base(cost, expenseName, expenseType, recurrent, date)
    {
    }
    public void DisplayChore()
    {
        Console.WriteLine($"{_date}, {_expenseName}, ${_cost.ToString("F2")}, {_expenseType}, Recurrent: {_recurrent}, Times Completed: {_timesCompleted}, Is Taken: {_taken}");
    }
    public string SaveChoreToFile()
    {
        return $"4 * {_date} * {_expenseName} * {_cost} * {_expenseType} * {_recurrent} * {_timesCompleted} * {_taken}";
    }
}