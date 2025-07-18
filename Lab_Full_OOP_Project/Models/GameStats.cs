using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Models
{
    public struct GameStats
    {
        public int Downloads;
        public int DLCCnt;
        public GameStats(int downloads, int dlccount)
        {
            Downloads = downloads;
            DLCCnt = dlccount;
        }
        public void Display()
        {
            Console.WriteLine($"Downloads: {Downloads}, DLCs number : {DLCCnt}");
        }
    }
}
