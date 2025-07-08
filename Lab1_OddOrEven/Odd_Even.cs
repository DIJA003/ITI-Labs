using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Day1
{
    internal class Odd_Even
    {
        static void Main(string[] args)
        {
            int x;
            Console.Write("Enter an integer: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine(x % 2 == 0 ? x + " is Even" : x + " is Odd");
        }
    }
}
