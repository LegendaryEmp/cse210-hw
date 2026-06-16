using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 6.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {GetLevelName()}");
    }

    private string GetLevelName()
    {
        if (_score >= 3000)
        {
            return "Legend";
        }
        else if (_score >= 1500)
        {
            return "Champion";
        }
        else if (_score >= 750)
        {
            return "Adventurer";
        }
        else if (_score >= 250)
        {
            return "Seeker";
        }

        return "Beginner";
    }

    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = ReadPositiveInt("What is the amount of points associated with this goal? ");

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            int target = ReadPositiveInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadPositiveInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("That goal type was not recognized.");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int goalNumber = ReadPositiveInt("Which goal did you accomplish? ");

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("That goal number was not found.");
            return;
        }

        Goal goal = _goals[goalNumber - 1];
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("That file is empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] typeAndData = line.Split(':', 2);

        if (typeAndData.Length != 2)
        {
            return null;
        }

        string goalType = typeAndData[0];
        string[] parts = typeAndData[1].Split('|');

        if (goalType == "SimpleGoal" && parts.Length == 4)
        {
            return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
        }
        else if (goalType == "EternalGoal" && parts.Length == 3)
        {
            return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
        else if (goalType == "ChecklistGoal" && parts.Length == 6)
        {
            return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
        }

        return null;
    }

    private int ReadPositiveInt(string prompt)
    {
        int number = 0;

        while (number <= 0)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number) || number <= 0)
            {
                number = 0;
                Console.WriteLine("Please enter a positive whole number.");
            }
        }

        return number;
    }
}
