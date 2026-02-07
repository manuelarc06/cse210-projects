using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Welcome to the Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(4);

            Console.WriteLine("\nBreathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}