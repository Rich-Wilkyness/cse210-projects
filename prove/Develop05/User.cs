using System;

public class User
{
    private string _userName;
    private string _fileName;
    private int _score = 0;
    private List<Goal> _userGoals = new List<Goal> { };
    public User(string userName, string filename)
    {
        _userName = userName;
        _fileName = filename;
    }
    public void CalcDisplayScore(int index)
    {
        int points = _userGoals[index - 1]._points;
        _userGoals[index - 1].UpdateGoal();
        Console.WriteLine($"Congratulations! You have earned {points} points! ");
        _score += points;
        Console.WriteLine($"You now have {_score} points. ");
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in _userGoals)
        {
            goal.DisplayGoal();
        }
    }
    public void DisplayGoalUpdateList()
    {
        int i = 1;
        foreach (Goal goal in _userGoals)
        {
            Console.Write($"{i}. ");
            goal.DisplayGoalNames();
            i++;
        }
    }
    public void AddToList(Goal userGoal)
    {
        _userGoals.Add(userGoal);
    }
    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            outputFile.WriteLine(_score);
            for (int i = 0; i < _userGoals.Count; i++)
            {
                string saveThis = _userGoals[i].SaveToFile();
                outputFile.WriteLine(saveThis);
            }
        }
    }
    public void Load()
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        string strLine1 = lines.First();
        int line1 = int.Parse(strLine1);
        _score = line1;

        foreach (string line in lines)
        {
            string[] splitLine = line.Split("*");
            string strGoalType = splitLine[0];
            int goalType = int.Parse(strGoalType);

            if (goalType == 1)
            {
                string goalName = splitLine[1];
                string description = splitLine[2];
                string strPoints = splitLine[3];
                int points = int.Parse(strPoints);
                string strIsComplete = splitLine[4];
                int isComplete = int.Parse(strIsComplete);

                SingleGoal singleGoal = new SingleGoal(goalName, strGoalType, description, points, isComplete);
                AddToList(singleGoal);
            }
            else if (goalType == 2)
            {
                string goalName = splitLine[1];
                string description = splitLine[2];
                string strPoints = splitLine[3];
                int points = int.Parse(strPoints);
                string strIsComplete = splitLine[4];
                int isComplete = int.Parse(strIsComplete);
                EternalGoal eternalGoal = new EternalGoal(goalName, strGoalType, description, points, isComplete);
                AddToList(eternalGoal);
            }
            else if (goalType == 3)
            {
                string goalName = splitLine[1];
                string description = splitLine[2];
                string strPoints = splitLine[3];
                int points = int.Parse(strPoints);
                string strIsComplete = splitLine[4];
                int isComplete = int.Parse(strIsComplete);
                string strBonusPoints = splitLine[5];
                int bonusPoints = int.Parse(strBonusPoints);
                string strCurrentProgress = splitLine[6];
                int currentProgress = int.Parse(strCurrentProgress);
                string strCompleteAt = splitLine[7];
                int completeAt = int.Parse(strCompleteAt);
                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, strGoalType, description, points, isComplete, currentProgress, completeAt, bonusPoints);
                AddToList(checklistGoal);
            }
        }
    }
}