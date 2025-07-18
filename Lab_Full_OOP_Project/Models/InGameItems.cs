using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Full_OOP_Project.Interfaces;

namespace Lab_Full_OOP_Project.Models
{
    public class InGameItems : IPurchasable
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price{ get; private set; }
        public InGameItems(int id,string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} DLC - ${Price:F2}");
        }
    }
}
