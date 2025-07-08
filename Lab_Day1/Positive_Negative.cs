using System;
namespace Lab_Day1
{
    public class Positive_Negative
    {

        static void Main(string[] args)
        {
            int x;
            Console.Write("Enter an integer: ");
            x = int.Parse(Console.ReadLine());
            if (x == 0) Console.WriteLine(x + " is Neutral");
            else if (x < 0) Console.WriteLine(x + " is Negative");
            else Console.WriteLine(x + " is positive");
        }
    }
}