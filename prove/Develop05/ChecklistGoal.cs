using System;

public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _completeAt;
    private int _currentProgress = 0;
    public ChecklistGoal(string goalName, string goalType, string description, int points, int completeAt, int bonusPoints) : base(goalName, goalType, description, points)
    {
        _completeAt = completeAt;
        _bonusPoints = bonusPoints;
    }
    public ChecklistGoal(string goalName, string goalType, string description, int points, int isComplete, int currentProgress, int completeAt, int bonusPoints) : base(goalName, goalType, description, points)
    {
        _isComplete = isComplete;
        _currentProgress = currentProgress;
        _completeAt = completeAt;
        _bonusPoints = bonusPoints;
    }

    public override void UpdateGoal()
    {
        if (_currentProgress == _completeAt)
        {
            Console.WriteLine("This goal has already been completed. ");
        }
        _currentProgress += 1;
        if (_currentProgress == _completeAt)
        {
            Console.WriteLine("Congrats! You've completed this goal! ");
            _isComplete = 1;
        }
    }
    public override void DisplayGoal()
    {
        string checkBox = "[ ]";

        if (_isComplete == 1)
        {
            checkBox = "[X]";
        }
        Console.WriteLine($"{checkBox} {_goalName} ({_description}) -- Currently completed {_currentProgress}/{_completeAt} ");
    }
    public override string SaveToFile()
    {
        return $"{_goalType} * {_goalName} * {_description} * {_points} * {_isComplete} * {_bonusPoints} * {_currentProgress} * {_completeAt}";
    }

}