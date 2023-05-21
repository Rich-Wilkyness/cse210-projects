using System;

public class SingleGoal : Goal
{
    public SingleGoal(string goalName, string goalType, string description, int points) : base(goalName, goalType, description, points)
    {
    }
    public SingleGoal(string goalName, string goalType, string description, int points, int isComplete) : base(goalName, goalType, description, points)
    {
        _isComplete = isComplete;
    }
    public override void UpdateGoal()
    {
        _isComplete = 1;
    }
    public override void DisplayGoal()
    {
        string checkBox = "[ ]";

        if (_isComplete == 1)
        {
            checkBox = "[X]";
        }
        Console.WriteLine($"{checkBox} {_goalName} ({_description}) ");
    }
    public override string SaveToFile()
    {
        return $"{_goalType} * {_goalName} * {_description} * {_points} * {_isComplete}";
    }
}