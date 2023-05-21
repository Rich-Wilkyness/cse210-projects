using System;

class Program
{
    static void Main(string[] args)
    {
        void Menu1()
        {
            while (true)
            {
                Console.WriteLine("Hello, would you like to create a NEW user, LOAD an old user, or QUIT? ");
                string response1 = Console.ReadLine();
                response1 = response1.ToLower();
                if (response1 == "new")
                {
                    Console.Write("Desired username: ");
                    string username = Console.ReadLine();
                    string filename = username + ".txt";
                    User user = new User(username, filename);
                    Menu2(user);
                }
                else if (response1 == "load")
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    string filename = username + ".txt";

                    User user = new User(username, filename);
                    user.Load();
                    Menu2(user);
                }
                else if (response1 == "quit")
                {
                    break;
                }
            }
        }
        void Menu2(User user)
        {
            while (true)
            {
                Console.WriteLine("1. Create New Goal ");
                Console.WriteLine("2. Update a Goal ");
                Console.WriteLine("3. Display Goals ");
                Console.WriteLine("4. Save Goals ");
                Console.WriteLine("5. Load Goals ");
                Console.WriteLine("6. Quit ");
                string response2 = Console.ReadLine();

                if (response2 == "1")
                {
                    Console.WriteLine("1. Simple Goal ");
                    Console.WriteLine("2. Eternal Goal ");
                    Console.WriteLine("3. Checklist Goal");
                    string goalType = Console.ReadLine();

                    Console.Write("Name of new goal: ");
                    string goalName = Console.ReadLine();

                    Console.Write("Description of new goal: ");
                    string description = Console.ReadLine();

                    Console.Write("Points: ");
                    string strPoints = Console.ReadLine();
                    int points = int.Parse(strPoints);

                    if (goalType == "3")
                    {
                        Console.Write("How many times accomplished for a bonus? ");
                        string strCompleteAt = Console.ReadLine();
                        int completeAt = int.Parse(strCompleteAt);

                        Console.Write("Points for bonus: ");
                        string strBonusPoints = Console.ReadLine();
                        int bonusPoints = int.Parse(strBonusPoints);
                        ChecklistGoal checklist = new ChecklistGoal(goalName, goalType, description, points, completeAt, bonusPoints);
                        user.AddToList(checklist);
                    }
                    else if (goalType == "1")
                    {
                        SingleGoal single = new SingleGoal(goalName, goalType, description, points);
                        user.AddToList(single);
                    }
                    else if (goalType == "2")
                    {
                        EternalGoal eternal = new EternalGoal(goalName, goalType, description, points);
                        user.AddToList(eternal);
                    }

                }
                else if (response2 == "2")
                {
                    user.DisplayGoalUpdateList();
                    Console.WriteLine("");
                    Console.Write("Which goal did you accomplish? ");
                    string strGoalIndex = Console.ReadLine();
                    int goalIndex = int.Parse(strGoalIndex);
                    user.CalcDisplayScore(goalIndex);
                }
                else if (response2 == "3")
                {
                    user.DisplayGoals();
                }
                else if (response2 == "4")
                {
                    user.Save();
                }
                else if (response2 == "5")
                {
                    user.Load();
                }
                else if (response2 == "6")
                {
                    Console.WriteLine("Thank you come again! ");
                    break;
                }
            }
        }
        Menu1();
    }
}