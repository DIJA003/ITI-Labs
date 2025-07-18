using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Models
{
    public class Purchase
    {
        public Player buyer { get; private set; }
        public Game boughtGame { get; private set; }
        public Purchase(Player player, Game game) 
        {
            buyer = player;
            boughtGame = game;
        }
        public void DisplayPurchase()
        {
            Console.WriteLine($"{buyer.Username} purchased {boughtGame.Title}");
        }
    }
}
