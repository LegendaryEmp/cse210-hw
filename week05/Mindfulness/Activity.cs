using System;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        ClearScreen();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (_duration <= 0)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out _duration) || _duration <= 0)
            {
                _duration = 0;
                Console.WriteLine("Please enter a positive whole number.");
            }
        }

        ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write(new string('\b', i.ToString().Length));
            Console.Write(new string(' ', i.ToString().Length));
            Console.Write(new string('\b', i.ToString().Length));
        }
    }

    public static void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
        }
    }
}
