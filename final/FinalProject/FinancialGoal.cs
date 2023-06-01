using System;

class FinancialGoal
{
    private string _goalName;
    private decimal _targetAmount;
    public decimal _currentAmount = 0;
    public FinancialGoal(string goalName, decimal targetAmount)
    {
        _goalName = goalName;
        _targetAmount = targetAmount;
    }
    public void DisplayGoal()
    {
        Console.WriteLine($"{_goalName} ${_currentAmount.ToString("F2")}/${_targetAmount.ToString("F2")}");
    }
    public string SaveToFile()
    {
        return $"2 * {_goalName} * {_currentAmount} * {_targetAmount}";
    }
}