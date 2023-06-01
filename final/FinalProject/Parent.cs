using System;

class Parent : Family
{
    private List<Expense> _expenses = new List<Expense> { };
    private List<Child> _children = new List<Child> { };
    private List<FinancialGoal> _financialGoals = new List<FinancialGoal> { };
    private List<Chore> _chores = new List<Chore> { };

    public Parent(string name, string filename) : base(name, filename)
    {
    }
    public void AddMoney()
    {
        DisplayMoney();
        DisplayList("goals");
        Console.WriteLine("Add Money to:");
        Console.WriteLine("1. Financial Goal ");
        Console.WriteLine("2. Main Account ");
        string moneyChoice = Console.ReadLine();

        Console.WriteLine("How much would you like to add? ");
        string strAddMoney = Console.ReadLine();
        decimal addMoney = decimal.Parse(strAddMoney);

        if (moneyChoice == "1")
        {
            DisplayList("goals");
            Console.WriteLine("Which goal would you like to add to? ");
            string strGoalIndex = Console.ReadLine();
            int goalIndex = int.Parse(strGoalIndex);
            UpdateFinancialGoal(goalIndex, addMoney);
            _money -= addMoney;
        }
        else if (moneyChoice == "2")
        {
            _money += addMoney;
        }
    }
    public void AddChild()
    {
        Console.WriteLine("Child name: ");
        string childName = Console.ReadLine();
        string childFile = childName + ".txt";
        Child child = new Child(childName, childFile, _name);
        _children.Add(child);
        child.Save();
    }
    public void AddChore()
    {
        Console.WriteLine("Chore name: ");
        string expenseName = Console.ReadLine();
        Console.WriteLine("Recurrent (y/n): ");
        string strRecurrent = Console.ReadLine();
        strRecurrent = strRecurrent.ToLower();
        Console.WriteLine("Value: ");
        string strCost = Console.ReadLine();
        decimal cost = decimal.Parse(strCost);
        string currentDate = GetDateTime();

        if (strRecurrent == "y")
        {
            string expenseType = "eternal";
            EternalChore chore = new EternalChore(cost, expenseName, expenseType, strRecurrent, currentDate);
            _chores.Add(chore);
        }
        else if (strRecurrent == "n")
        {
            string expenseType = "single";
            SingleChore chore = new SingleChore(cost, expenseName, expenseType, strRecurrent, currentDate);
            _chores.Add(chore);
        }
        else
        {
            Console.WriteLine("Not a valid recurrent value (y/n) ");
        }
    }
    public void AddExpense()
    {
        Console.WriteLine("Expense name: ");
        string expenseName = Console.ReadLine();
        Console.WriteLine("Expense type (bill, entertainment, travel, etc.): ");
        string expenseType = Console.ReadLine();
        Console.WriteLine("Recurrent (y/n): ");
        string strRecurrent = Console.ReadLine();
        strRecurrent = strRecurrent.ToLower();
        Console.WriteLine("Cost: ");
        string strCost = Console.ReadLine();
        decimal cost = decimal.Parse(strCost);
        string currentDate = GetDateTime();

        Expense expense = new Expense(cost, expenseName, expenseType, strRecurrent, currentDate);
        _expenses.Add(expense);
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
    public Chore ChildGetChore()
    {
        Console.WriteLine("Which chore would you like to take? ");
        string strChoreIndex = Console.ReadLine();
        int choreIndex = int.Parse(strChoreIndex);
        _chores[choreIndex - 1]._taken = "y";
        return _chores[choreIndex - 1];
    }
    public void DisplayList(string listChoice)
    {
        int displayCount = 1;
        if (listChoice == "expenses")
        {
            foreach (Expense expense in _expenses)
            {
                Console.Write($"{displayCount}. ");
                expense.DisplayExpense();
                displayCount++;
            }
        }
        else if (listChoice == "children")
        {
            foreach (Child child in _children)
            {
                Console.Write($"{displayCount}. ");
                child.DisplayChild();
                displayCount++;
            }
        }
        else if (listChoice == "goals")
        {
            foreach (FinancialGoal goal in _financialGoals)
            {
                Console.Write($"{displayCount}. ");
                goal.DisplayGoal();
                displayCount++;
            }
        }
        else if (listChoice == "chores")
        {
            foreach (Chore chore in _chores)
            {
                Console.Write($"{displayCount}. ");
                chore.DisplayChore();
                displayCount++;
            }
        }
    }
    public override void DisplayMoney()
    {
        Console.WriteLine($"Bank: ${_money.ToString("F2")}");
    }
    public void UpdateChore(string goalName)
    {
        Chore foundItem = _chores.Find(item => item._expenseName == goalName);
        Console.WriteLine("Using Find method:");
        if (foundItem != null)
        {
            _money -= foundItem._cost;
        }
        else
        {
            Console.WriteLine("String not found.");
        }
    }
    public void UpdateFinancialGoal(int index, decimal money)
    {
        _financialGoals[index - 1]._currentAmount += money;
    }
    public string GetDateTime()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine($"{_money}");
            foreach (Expense expense in _expenses)
            {
                outputFile.WriteLine(expense.SaveToFile());
            }
            foreach (Chore chore in _chores)
            {
                outputFile.WriteLine(chore.SaveChoreToFile());
            }
            foreach (Child child in _children)
            {
                outputFile.WriteLine(child.SaveToFile());
            }
            foreach (FinancialGoal goal in _financialGoals)
            {
                outputFile.WriteLine(goal.SaveToFile());
            }
        }
    }
    public void Load()
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);

        string strLine1 = lines.First();
        decimal line1 = decimal.Parse(strLine1);
        _money = line1;

        foreach (string line in lines)
        {
            string[] splitLine = line.Split("*");
            string strFileType = splitLine[0];
            int fileType = int.Parse(strFileType);

            if (fileType == 1)
            {
                string name = splitLine[1].Trim();
                string filename = splitLine[2].Trim();

                Child child = new Child(name, filename);
                _children.Add(child);
            }
            else if (fileType == 2)
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
            else if (fileType == 3)
            {
                string date = splitLine[1].Trim();
                string expenseName = splitLine[2].Trim();
                string strCost = splitLine[3].Trim();
                decimal cost = decimal.Parse(strCost);
                string expenseType = splitLine[4].Trim();
                string recurrent = splitLine[5].Trim();
                string strCurrentAmount = splitLine[3].Trim();
                decimal currentAmount = decimal.Parse(strCurrentAmount);
                Expense expense = new Expense(cost, expenseName, expenseType, recurrent, date);
                expense._currentAmount = currentAmount;
                _expenses.Add(expense);
            }
            else if (fileType == 4)
            {
                string date = splitLine[1].Trim();
                string expenseName = splitLine[2].Trim();
                string strCost = splitLine[3].Trim();
                decimal cost = decimal.Parse(strCost);
                string expenseType = splitLine[4].Trim();
                string recurrent = splitLine[5].Trim();
                string strTimesCompleted = splitLine[6];
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
    }
}