// I added a feature to keep track of how many times activities were completed.
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        while (!exit)
        {
            Console.Clear();

            Console.WriteLine("Session Log:");
            Console.WriteLine($"Breathing sessions: {breathingCount}");
            Console.WriteLine($"Reflection sessions: {reflectionCount}");
            Console.WriteLine($"Listing sessions: {listingCount}");
            Console.WriteLine();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathingCount++;
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    reflectionCount++;
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;

                case "3":
                    listingCount++;
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter 1-4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}