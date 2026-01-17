using System;

// Improvement made: After writing a journal entry, the program counts the number of words in the entry and displays it to the user. This encourages the user to write more and adds extra functionality beyond the core requirements.

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("\nChoose an option (write a number): ");

            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("< ");
                string response = Console.ReadLine();

                int wordCount = response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Your entry has {wordCount} words!\n");

                Entry newEntry = new Entry
                {
                    _date = DateTime.Now.ToShortDateString(),
                    _promptText = prompt,
                    _entryText = response
                } ;

                myJournal.AddEntry(newEntry);
                Console.WriteLine("Your entry has been added!\n");
            }

            else if (choice == "2")
            {
                if (myJournal._entries.Count == 0)
                {
                    Console.WriteLine("The journal is empty.\n");
                }
                else
                {
                    myJournal.DisplayAll();
                }
            }

            else if (choice == "3")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();
                if (!filename.EndsWith(".txt")) filename += ".txt";

                myJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully!\n");
            }

            else if (choice == "4")
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();
                if (!filename.EndsWith(".txt")) filename += ".txt";

                myJournal.SaveToFile(filename);
                Console.WriteLine("You have saved your journal successfully!\n");
                
            }

            else if (choice == "5")
            {
                Console.WriteLine("You have quit the journaling program. See you next time!");
            }

            else
            {
                Console.WriteLine("Invalid choice, try it again!\n");
            }
        }
    }
}