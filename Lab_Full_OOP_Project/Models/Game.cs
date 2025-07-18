using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lab_Full_OOP_Project.Interfaces;
using Lab_Full_OOP_Project.Models.Enums;

namespace Lab_Full_OOP_Project.Models
{
    public class Game : Base,IPurchasable
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public GameType type { get; private set; }
        public PlatformType platform { get; private set; }
        public double Price { get; private set; }
        public InGameItems[] Dlcs { get; private set; } = new InGameItems[100];
        public GameStats Stats { get; private set; }
        public int DlcCnt = 0;

        public Game(int id, string title, GameType Type, PlatformType Platform, double price, InGameItems[] dlcs, int dlcCnt)
        {
            Id = id;
            Title = title;
            type = Type;
            platform = Platform;
            Price = price;
            Stats = new GameStats(0, 0);
            CreatedOn = DateTime.Now;
            CreatedBy = "Admin";
        }

        public Game(int id, string title, GameType Type, PlatformType Platform, double price)
        {
            Id = id;
            Title = title;
            type = Type;
            platform = Platform;
            Price = price;
            Stats = new GameStats(0, 0);
            CreatedOn = DateTime.Now;
            CreatedBy = "Admin";
        }

        public void UpdateStats(int downloads)
        {
            Stats = new GameStats(downloads, DlcCnt);
        }
        public void AddDLC(InGameItems dlc) 
        {
            if (DlcCnt < Dlcs.Length) { 
                
                Dlcs[DlcCnt++] = dlc;
                Stats = new GameStats(Stats.Downloads,DlcCnt);
                UpdatedOn = DateTime.Now;
                UpdatedBy = "Admin";
            }
            else Console.WriteLine("cannot add more DLCs");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Title} ({type}) - ${Price:F2} |  Created: {CreatedOn}, Deleted: {IsDeleted}");
            Stats.Display();
        }
    }
}
