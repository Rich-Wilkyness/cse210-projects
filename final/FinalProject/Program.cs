using System;

class Program
{
    static void Main(string[] args)
    {
        void Menu()
        {
            while (true)
            {
                Console.WriteLine("Hello, would you like to create a NEW parent, LOAD a parent profile, access CHILD profile, or QUIT? ");
                string response1 = Console.ReadLine();
                response1 = response1.ToLower();
                if (response1 == "new")
                {
                    Console.Write("Desired username: ");
                    string username = Console.ReadLine();
                    string filename = username + ".txt";
                    Parent parent = new Parent(username, filename);
                    ParentMenu(parent);
                }
                else if (response1 == "load")
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    string filename = username + ".txt";

                    Parent parent = new Parent(username, filename);
                    parent.Load();
                    ParentMenu(parent);
                }
                else if (response1 == "child")
                {
                    Console.Write("Child username: ");
                    string username = Console.ReadLine();
                    string filename = username + ".txt";
                    Child child = new Child(username, filename);

                    string parentUsername = child.Load();
                    string parentFilename = parentUsername + ".txt";
                    Parent parent = new Parent(parentUsername, parentFilename);
                    parent.Load();
                    ChildMenu(child, parent);
                }
                else if (response1 == "quit")
                {
                    break;
                }
            }
        }
        void ParentMenu(Parent parent)
        {
            while (true)
            {
                Console.WriteLine("1. Add Child ");
                Console.WriteLine("2. Add Chore ");
                Console.WriteLine("3. Add Expense ");
                Console.WriteLine("4. Add Financial Goal ");
                Console.WriteLine("5. Add Money acc/goal ");
                Console.WriteLine("6. Display Children ");
                Console.WriteLine("7. Display Chores ");
                Console.WriteLine("8. Display Expenses ");
                Console.WriteLine("9. Display Financial Goals ");
                Console.WriteLine("10. Display Money ");
                Console.WriteLine("11. Save ");
                Console.WriteLine("12. Quit ");
                string parentResponse = Console.ReadLine();

                if (parentResponse == "1")
                {
                    parent.AddChild();
                }
                else if (parentResponse == "2")
                {
                    parent.AddChore();
                }
                else if (parentResponse == "3")
                {
                    parent.AddExpense();
                }
                else if (parentResponse == "4")
                {
                    parent.AddFinancialGoal();
                }
                else if (parentResponse == "5")
                {
                    parent.AddMoney();
                }
                else if (parentResponse == "6")
                {
                    parent.DisplayList("children");
                }
                else if (parentResponse == "7")
                {
                    parent.DisplayList("chores");
                }
                else if (parentResponse == "8")
                {
                    parent.DisplayList("expenses");
                }
                else if (parentResponse == "9")
                {
                    parent.DisplayList("goals");
                }
                else if (parentResponse == "10")
                {
                    parent.DisplayMoney();
                }
                else if (parentResponse == "11")
                {
                    parent.Save();
                }
                else if (parentResponse == "12")
                {
                    break;
                }
            }
        }
        void ChildMenu(Child child, Parent parent)
        {
            while (true)
            {
                Console.WriteLine("1. Get Chore ");
                Console.WriteLine("2. Update Chore ");
                Console.WriteLine("3. Add Financial Goal ");
                Console.WriteLine("4. Update Financial Goal ");
                Console.WriteLine("5. Display Chores ");
                Console.WriteLine("6. Display Financial Goals ");
                Console.WriteLine("7. Display Money");
                Console.WriteLine("8. Save ");
                Console.WriteLine("9. Quit ");
                string childResponse = Console.ReadLine();

                if (childResponse == "1")
                {
                    parent.DisplayList("chores");
                    Chore chore = parent.ChildGetChore();
                    child.AddChore(chore);
                }
                else if (childResponse == "2")
                {
                    child.DisplayChores();
                    string goalName = child.UpdateChore();
                    parent.UpdateChore(goalName);
                }
                else if (childResponse == "3")
                {
                    child.AddFinancialGoal();
                }
                else if (childResponse == "4")
                {
                    child.UpdateFinancialGoal();
                }
                else if (childResponse == "5")
                {
                    child.DisplayChores();
                }
                else if (childResponse == "6")
                {
                    child.DisplyFinancialGoal();
                }
                else if (childResponse == "7")
                {
                    child.DisplayMoney();
                }
                else if (childResponse == "8")
                {
                    child.Save();
                    parent.Save();
                }
                else if (childResponse == "9")
                {
                    break;
                }
            }
        }
        Menu();
    }
}