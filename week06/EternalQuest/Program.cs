using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements: the program displays a level title based on the
        // player's score, adding a simple gamification reward as points increase.
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
