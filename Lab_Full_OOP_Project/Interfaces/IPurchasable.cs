using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Interfaces
{
    public interface IPurchasable
    {
        double Price { get; }
        void DisplayInfo();
    }
}
