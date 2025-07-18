using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Full_OOP_Project.Models;
using Lab_Full_OOP_Project.Service;

namespace Lab_Full_OOP_Project.Models
{
    public class Player : User
    {

        public double walletBalance { get; private set; }
        public Game[] ownedGames { get; private set; } = new Game[100];
        public PlayerStats stats { get; private set; }
        public int purchaseCnt = 0;

        public Player(int id, string name, string email, double wallet) : base(id,name,email)
        {

            walletBalance = wallet;
            stats = new PlayerStats(0,0,0);
        }

        public void UpdateInfo(String newName, string newEmail)
        {
            Username = newName;
            Email = newEmail;
            stats = new PlayerStats(0, 0, 0);
        }

        public void UpdateStats(int hours, int achievement)
        {
            stats = new PlayerStats(hours,purchaseCnt, achievement);
        }
            
        public void AddGame(Game game)
        {
            if (purchaseCnt < ownedGames.Length)
            {
                ownedGames[purchaseCnt++] = game;
                walletBalance -= game.Price;
            }

        }

        public bool HasGame(int id) 
        {
            foreach(Game game in ownedGames) if (game.Id == id) return true;
            return false;
        }

        public (String playerName, int ownedGames, double balance) GetSummary()
        {
            return (Username, purchaseCnt, walletBalance);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Player ID: {Id}, UserName: {Username}, Email : {Email}, Wallet Balance: {walletBalance}");
        }
    }
}
