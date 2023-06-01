using System;

class Child : Family
{
    private string _parentName;
    private List<Chore> _chores = new List<Chore> { };
    private List<FinancialGoal> _financialGoals = new List<FinancialGoal> { };

    public Child(string name, string filename, string parentName) : base(name, filename)
    {
        _parentName = parentName;
    }
    public Child(string name, string filename) : base(name, filename)
    {
    }
    public void AddChore(Chore chore)
    {
        _chores.Add(chore);
    }
    public void AddFinancialGoal()
    {
        Console.WriteLine("Name of Financial Goal: ");
        string goalName = Console.ReadLine();
        Console.WriteLine("Money Goal: ");
        string strTargetAmount = Console.ReadLine();
        decimal targetAmount = decimal.Parse(strTargetAmount);
        FinancialGoal financialGoal = new FinancialGoal(goalName, targetAmount);
        _financialGoals.Add(financialGoal);
    }
    public string UpdateChore()
    {
        Console.WriteLine("Which chore would you like to update? ");
        string strChoreIndex = Console.ReadLine();
        int choreIndex = int.Parse(strChoreIndex) - 1;
        Console.WriteLine($"Did you finish the chore: {_chores[choreIndex]._expenseName}? (y/n) ");
        string isFinished = Console.ReadLine();
        if (isFinished == "y")
        {
            if (_chores[choreIndex]._recurrent == "y" || _chores[choreIndex]._timesCompleted == 0)
            {
                _chores[choreIndex]._timesCompleted += 1;
                _money += _chores[choreIndex]._cost;
                return _chores[choreIndex]._expenseName;
            }
            else
            {
                Console.WriteLine("You have already completed this single chore. ");
                return "";
            }
        }
        return "";
    }
    public void UpdateFinancialGoal()
    {
        DisplayMoney();
        DisplyFinancialGoal();
        Console.WriteLine("Add Money to which goal? ");
        string strGoalIndex = Console.ReadLine();
        int goalIndex = int.Parse(strGoalIndex);

        Console.WriteLine("How much would you like to add? ");
        string strAddMoney = Console.ReadLine();
        decimal addMoney = decimal.Parse(strAddMoney);
        _financialGoals[goalIndex - 1]._currentAmount += addMoney;
        _money -= addMoney;
    }
    public void DisplayChild()
    {
        Console.WriteLine($"{_name}");
    }
    public void DisplayChores()
    {
        int displayCount = 1;
        foreach (Chore chore in _chores)
        {
            Console.Write($"{displayCount}. ");
            chore.DisplayChore();
            displayCount++;
        }
    }
    public void DisplyFinancialGoal()
    {
        int displayCount = 1;
        foreach (FinancialGoal goal in _financialGoals)
        {
            Console.Write($"{displayCount}. ");
            goal.DisplayGoal();
            displayCount++;
        }
    }
    public override void DisplayMoney()
    {
        Console.WriteLine($"${_money}");
    }
    public string SaveToFile()
    {
        return $"1 * {_name} * {_filename}";
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine($"{_money} * {_parentName}");
            foreach (Chore chore in _chores)
            {
                outputFile.WriteLine(chore.SaveChoreToFile());
            }
            foreach (FinancialGoal goal in _financialGoals)
            {
                outputFile.WriteLine(goal.SaveToFile());
            }
        }
    }
    public string Load()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        string strLine1 = lines.First();
        string[] splitLine1 = strLine1.Split("*");
        string strMoney = splitLine1[0].Trim();
        decimal money = decimal.Parse(strMoney);
        _money = money;
        string parentName = splitLine1[1].Trim();
        _parentName = parentName;


        foreach (string line in lines)
        {
            string[] splitLine = line.Split("*");
            string strFileType = splitLine[0];
            int fileType = int.Parse(strFileType);

            if (fileType == 2)
            {
                string goalName = splitLine[1].Trim();
                string strCurrentAmount = splitLine[2].Trim();
                decimal currentAmount = decimal.Parse(strCurrentAmount);
                string strTargetAmount = splitLine[3].Trim();
                decimal targetAmount = decimal.Parse(strCurrentAmount);
                FinancialGoal goal = new FinancialGoal(goalName, targetAmount);
                goal._currentAmount = currentAmount;
                _financialGoals.Add(goal);
            }
            else if (fileType == 4)
            {
                string date = splitLine[1].Trim();
                string expenseName = splitLine[2].Trim();
                string strCost = splitLine[3].Trim();
                decimal cost = decimal.Parse(strCost);
                string expenseType = splitLine[4].Trim();
                string recurrent = splitLine[5].Trim();
                string strTimesCompleted = splitLine[6].Trim();
                int timesCompleted = int.Parse(strTimesCompleted);
                string taken = splitLine[7].Trim();
                if (recurrent == "y")
                {
                    EternalChore eternal = new EternalChore(cost, expenseName, expenseType, recurrent, date);
                    eternal._timesCompleted = timesCompleted;
                    eternal._taken = taken;
                    _chores.Add(eternal);
                }
                else if (recurrent == "n")
                {
                    SingleChore single = new SingleChore(cost, expenseName, expenseType, recurrent, date);
                    single._timesCompleted = timesCompleted;
                    single._taken = taken;
                    _chores.Add(single);
                }
            }
        }
        return parentName;
    }
}
