using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video()
        {
            Title = "Easy Pasta Recipe in 15 Minutes",
            Author = "Home Cooking Channel",
            LengthSeconds = 500
        };

        v1.AddComment(new Comment("Monica", "I made this today and it was delicious!"));
        v1.AddComment(new Comment("Anna", "Love how easy this is to follow."));
        v1.AddComment(new Comment("Alexis", "Perfect recipe for busy days."));
        videos.Add(v1);

        Video v2 = new Video()
        {
            Title = "How to Study Effectively for Exams",
            Author = "Jose Carpenter",
            LengthSeconds = 840
        };

        v2.AddComment(new Comment("Maria", "These tips really helped me focus."));
        v2.AddComment(new Comment("Jennie", "I wish I had seen this earlier."));
        v2.AddComment(new Comment("Daniel", "Simple strategies but very effective."));
        videos.Add(v2);

        Video v3 = new Video()
        {
            Title = "Turning My Small Bedroom into a Cozy Workspace",
            Author = "Mia Lopez",
            LengthSeconds = 690
        };

        v3.AddComment(new Comment("Lucas", "I love how realistic this setup is."));
        v3.AddComment(new Comment("Carla", "Great ideas for small rooms."));
        v3.AddComment(new Comment("Lily", "This makes working from home feel possible."));
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine($"Comments:");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($" - {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine();
        }

    }
}