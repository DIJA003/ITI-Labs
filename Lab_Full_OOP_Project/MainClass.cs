using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Full_OOP_Project.Service;

namespace Lab_Full_OOP_Project
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            GamesStore store = new GamesStore();
            int inputFromUser;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please write the number of the operation you want: ");
                Console.WriteLine(@"1 - Register a New Player
2 - View All Players
3 - Update Player Info
4 - View Player Details By ID
5 - Add a Game
6 - View All Games
7 - Player Purchases Game
8 - View Player Purchased Games
9 - Add In-Game Item to Game (Add DLC)
10 - View Games's In-Game Items (View DLCs)
11 - Exit");
                Console.Write("Your Answer: ");
                inputFromUser = int.Parse(Console.ReadLine());

                switch (inputFromUser)
                {

                    case 1: 
                        store.RegisterPlayer();
                        break;
                    case 2: 
                        store.ListAllPlayers(); 
                        break;
                    case 3:
                        store.UpdatePlayerInfo();
                        break;
                    case 4:
                        store.ViewPlayerDetails();
                        break;
                    case 5:
                        store.AddGame();
                        break;
                    case 6:
                        store.ListAllGames();
                        break;
                    case 7:
                        store.PurchaseGame();
                        break;
                    case 8:
                        store.ViewPlayerPurchases();
                        break;
                    case 9:
                        store.AddDLCToGame();
                        break;
                    case 10:
                        store.ViewDLCOfGame();
                        break;
                    case 11: return; 
                
                }
            }
        }
    }
}
