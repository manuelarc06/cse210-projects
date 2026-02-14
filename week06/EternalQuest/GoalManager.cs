using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _playerLevel = 1;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("\nMenu options");
            Console.WriteLine("1. Create a new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a type of goal: ");
        string option = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (option == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (option == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (option == "3")
        {
            Console.Write("How many times are needed to complete it? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus for completing the goal: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailString()}");
            i++;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalDetails();
        Console.Write("Choose a number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"\nYou earned {earned} points!");

        CheckPlayerLevel(); 
    }

    private void CheckPlayerLevel()
    {
        int newLevel = (_score / 500) + 1;
        if (newLevel > _playerLevel)
        {
            _playerLevel = newLevel;
            Console.WriteLine($"\n You leveled up! You are now Level {_playerLevel}! ");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "Simple")
            {
                SimpleGoal g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "Eternal")
            {
                EternalGoal g = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                _goals.Add(g);
            }
            else if (type == "Checklist")
            {
                ChecklistGoal g = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5])
                );

                int timesCompleted = int.Parse(parts[6]);
                for (int k = 0; k < timesCompleted; k++)
                {
                    g.RecordEvent();
                }

                _goals.Add(g);
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}