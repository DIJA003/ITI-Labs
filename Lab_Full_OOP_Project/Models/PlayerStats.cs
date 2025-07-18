using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Models
{
    public struct PlayerStats
    {
        public int HoursPLayed;
        public int GamesOwned;
        public int Achievements;
        public PlayerStats(int hoursplayed, int gamesowned, int achievements)
        {
            HoursPLayed = hoursplayed;
            GamesOwned = gamesowned;
            Achievements = achievements;
        }
        public void Display()
        {
            Console.WriteLine($"Hours Played: {HoursPLayed}, Games Owned: {GamesOwned}, Number of Achievements: {Achievements}");
        }
    }
}
