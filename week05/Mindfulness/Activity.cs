using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.WriteLine("How long, in seconds would you like for your session?");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get Ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!");
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name} activity.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}