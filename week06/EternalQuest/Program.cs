// I added a player leveling system. The player levels up every 500 points. This adds gamification and motivation beyond the original assignment.
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}