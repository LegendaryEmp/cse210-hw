using System;
using System.Net.Security;

class Program
{
    static void Main(string[] args)
    {
       
       Console.WriteLine("What is your grade percentage? ");
         string gradePercentage = Console.ReadLine();
         int grade = int.Parse(gradePercentage);

        string letterGrade = "F";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("You did not pass this time, but keep working hard — you'll get it next time!");
        }
    }
}