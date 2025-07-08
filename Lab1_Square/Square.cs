using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Day1
{
    internal class Square
    {

        static void Main(string[] args)
        {

            int length, width;
            Console.Write("Enter the Length: ");
            length = int.Parse(Console.ReadLine());
            Console.Write("Enter the Width: ");
            width = int.Parse(Console.ReadLine());
            Console.Write(length == width ? "A Square" : "Not a Square");

        }
    }
}
