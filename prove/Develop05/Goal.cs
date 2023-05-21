using System;

public abstract class Goal
{
    public int _isComplete = 0;
    protected string _goalName = "";
    protected string _goalType = "";
    protected string _description = "";
    public int _points = 0;
    public Goal()
    {

    }
    public Goal(string goalName, string goalType, string description, int points)
    {
        _goalName = goalName;
        _goalType = goalType;
        _description = description;
        _points = points;

    }
    public abstract void UpdateGoal();
    public abstract void DisplayGoal();
    public abstract string SaveToFile();
    public void DisplayGoalNames()
    {
        Console.WriteLine($"{_goalName}");
    }
}