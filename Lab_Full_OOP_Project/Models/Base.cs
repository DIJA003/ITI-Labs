using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Models
{
    public class Base
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public Base()
        {
            CreatedOn = DateTime.Now;
            CreatedBy = "Admin"; 
            IsDeleted = false;
        }
    }
}
