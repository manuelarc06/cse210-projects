using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Welcome to the Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. You will recognize you power.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rnd = new Random();
        return _questions[rnd.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine("\nWhen you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
    }

    private void DisplayQuestions()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string q = GetRandomQuestion();
            Console.WriteLine($"> {q}");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}