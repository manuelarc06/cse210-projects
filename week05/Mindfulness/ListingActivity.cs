using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Welcome to the Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }

    private void GetListFromUser()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        Console.WriteLine("List as many responses as you can to the following prompt (press Enter after each):");

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
                ShowSpinner(1);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        GetListFromUser();
        DisplayEndingMessage();
    }
}